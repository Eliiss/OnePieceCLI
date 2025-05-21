module LogicHandlers

open DataTypes
open System
open GameStateUpdates

//to get current location from the game state
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

// DROP command 
let handleDrop (itemName: string) (gs: GameState) : Result<GameState, ErrorType> =
    match getCurrentLocation gs with
    | Ok currentLoc ->
        let normalizedItemName = itemName.Trim().ToLower()
        match gs.Player.Inventory |> List.tryFind (fun item -> item.Name.ToLower() = normalizedItemName) with
        | Some itemToDrop ->
            let gsWithItemRemovedFromInv = deleteItemInventory itemToDrop.Id gs
            let locWithItemAdded = addItemToLocation itemToDrop currentLoc // add to current location's available items 
            //shouldnt it be added ti its origianl loc 
            let finalGs = updateLocation locWithItemAdded gsWithItemRemovedFromInv
            Ok (addMessage (sprintf "You drop the %s." itemToDrop.Name) finalGs)
        | None -> Error (ItemNotInInventory itemName)
    | Error e -> Error e

// TAKE command 
let handleTake (itemName: string) (gs: GameState): Result<GameState, ErrorType> = 
    match getCurrentLocation gs with
    | Ok currentLoc ->
        let normalizedItemName = itemName.Trim().ToLower()
        match currentLoc.AvailableItems |> Map.tryPick (fun _ item -> if item.Name.ToLower() = itemName.ToLower()  = normalizedItemName then Some item else None) with
            | Some itemToTake ->
                let proceedWithTake =
                    if itemToTake.IsKeyPathItem then
                        match itemToTake.OriginLocation with
                        | Some itemOriginLocId ->
                            not (gs.Player.Inventory |> List.exists (fun invItem -> invItem.IsKeyPathItem && invItem.OriginLocation = Some itemOriginLocId))
                        | None -> false // Data error: KeyPathItem should have an origin
                    else true // Not a key path item, can always take if available

                if proceedWithTake then
                    let gsWithItemInInv = addItemInventory itemToTake gs
                    let locWithItemRemoved = removeItemFromLocationAvailable itemToTake.Id currentLoc
                    let finalGs = updateLocation locWithItemRemoved gsWithItemInInv
                    Ok (addMessage (sprintf "You take the %s." itemToTake.Name) finalGs)
                else
                    // Error message depends on why proceedWithTake is false
                    if itemToTake.IsKeyPathItem && itemToTake.OriginLocation.IsSome then
                        let originLocName = (Map.find itemToTake.OriginLocation.Value gs.Locations).Name
                        Error (CannotCarryMoreKeyPathItems originLocName)
                    else if itemToTake.IsKeyPathItem && itemToTake.OriginLocation.IsNone then
                         Error (InternalLogicError (sprintf "KeyPathItem %s missing Originating Location Id" itemToTake.Name))
                    else // Should not be reached if logic is correct
                        Error (ItemNotTakeable itemToTake.Name)
            | None -> Error (ItemNotFound itemName)
        | Error e -> Error e

    