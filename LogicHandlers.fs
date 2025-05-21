module LogicHandlers

open DataTypes
open System
open GameStateUpdates

//to get current location
let private getCurrentLocation (gs: GameState) : Result<Location, ErrorType> =
    match Map.tryFind gs.Player.CurrentLocationId gs.Locations with
    | Some loc -> Ok loc
    | None -> Error (LocationNotFoundInWorldData gs.Player.CurrentLocationId)


// HELP command
let handleHelp (gs: GameState) : Result<GameState, ErrorType> = // error handling
    let helpText = """
        Available commands:
        - look (l): Look around your current location
        - go <direction> or just <direction>: Move in specified direction (east, west)
        - examine <item>: Look closely at an item in your inventory
        - take <item>: Pick up an item
        - drop <item>: Drop an item from your inventory
        - use <item>: Use an item in your inventory
        - inventory (i): Check what you're carrying
        - answer <riddle> <answer>: Try to solve a riddle
        - help (h): Show this help message
        - quit (q): Exit the game
        """
    Ok (addMessage helpText gs)

// INVENTORY command
let handleInventory (gs: GameState) : Result<GameState, ErrorType> =
    if List.isEmpty gs.Player.Inventory then
        Ok (addMessage "Your inventory is empty." gs)
    else
        let itemsList = 
            gs.Player.Inventory 
            |> List.map (fun item -> item.Name) // fun creates an anonym function aka lambda expression
            |> String.concat ", "
        
        Ok (addMessage(sprintf "You are carrying: %s" itemsList) gs)

// QUIT command
let handleQuit (gs: GameState) : Result<GameState, ErrorType> =
    let finalMessage = "Thank you for playing! Goodbye."
    Ok (addMessage finalMessage { gs with IsGameOver = true })

// ANSWER RIDDLE command 
let handleAnswerRiddle (riddleIdFromInput: string) (playerAnswer: string) (gs: GameState) : Result<GameState, ErrorType> =
    match getCurrentLocation gs with
    | Ok currentLoc ->
        let actualRiddleId = riddleIdFromInput.Trim().ToLower()

        match Map.tryFind actualRiddleId currentLoc.Riddles with
        | Some riddleInfo ->
            if riddleInfo.CurrentState = Solved then
                Error (RiddleAlreadySolved actualRiddleId) //already solved case
            else
                let playerAnswerNormalized = playerAnswer.Trim().ToLower()
                let solutionNormalized = riddleInfo.Solution.Trim().ToLower()

                if playerAnswerNormalized = solutionNormalized then //correct answer case
                    let locWithRiddleSolved = markRiddleAsSolved actualRiddleId currentLoc
                    let locWithItemAvailable = makeItemAvailable riddleInfo.RewardItemId locWithRiddleSolved
                    let finalGs = updateLocation locWithItemAvailable gs
                    Ok (addMessages [riddleInfo.SolvedMessage; riddleInfo.RewardAppearsMessage] finalGs)
                else
                    // incorrect answer case
                    Error IncorrectRiddleAnswer
        | None -> Error (RiddleNotFound actualRiddleId) // Player tried to answer a riddle ID that doesn't exist here
    | Error e -> Error e

// LOOK command 
let handleLook (gs:GameState): Result<GameState, ErrorType> =
    match getCurrentLocation gs with
    | Ok currentLoc ->
        let itemNames =
            if Map.isEmpty currentLoc.AvailableItems then ["no items"]
            else
                currentLoc.AvailableItems
                |> Map.values          
                |> Seq.toList           
                |> List.map (fun item -> item.Name) 

        let nexLocationDirections =
            if Map.isEmpty currentLoc.NextLocation then ["nothing in the orizon"] 
            else
                currentLoc.NextLocation        
                |> Map.keys             
                |> Seq.toList           
                |> List.map (sprintf "%A")
        
        let examinableRiddleObjects : list<string> = 
            currentLoc.Riddles 
            |> Map.filter (fun riddleId riddleInfo -> riddleInfo.CurrentState = NotSolved) // keep only unsolved riddles
            |> Map.keys           // get the IDs (string keys) of these unsolved riddles
            |> Seq.toList         // convert the collection of keys to a list<string>
            |> List.map (fun riddleId -> 
                riddleId.Replace("_riddle", "")
                        .Replace("_", " ")
            )
        let messages =
            [ sprintf "You are in %s." currentLoc.Name
              "--------------------"
              currentLoc.Description
              ""
              sprintf "You see available items: %s." (String.concat ", " itemNames)
              if not (List.isEmpty examinableRiddleObjects) then
                sprintf "You notice: %s." (String.concat ", " examinableRiddleObjects)
              else ""
              sprintf "Exits are to the: %s." (String.concat ", " nexLocationDirections)
            ] |> List.filter (fun s -> not (String.IsNullOrWhiteSpace s)) // Remove empty strings
        Ok (addMessages messages gs)
    | Error e -> Error e 
