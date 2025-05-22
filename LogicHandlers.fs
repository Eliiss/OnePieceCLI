module LogicHandlers

open DataTypes
open System
open GameStateUpdates
open WorldData

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
        | None -> Error (RiddleNotFound actualRiddleId) // player tried to answer a riddle ID that doesn't exist here
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
            |> Map.keys           
            |> Seq.toList         
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
            ] |> List.filter (fun s -> not (String.IsNullOrWhiteSpace s))
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
            let finalGs = updateLocation locWithItemAdded gsWithItemRemovedFromInv
            Ok (addMessage (sprintf "You drop the %s." itemToDrop.Name) finalGs)
        | None -> Error (ItemNotInInventory itemName)
    | Error e -> Error e

// TAKE command 
let handleTake (itemName: string) (gs: GameState): Result<GameState, ErrorType> = 
    match getCurrentLocation gs with
    | Ok currentLoc ->
        let normalizedItemName = itemName.Trim().ToLower()
        match currentLoc.AvailableItems |> Map.tryPick (fun _ item -> 
            if item.Name.ToLower() = normalizedItemName then Some item else None) with
            | Some itemToTake ->
                let proceedWithTake =
                    if itemToTake.IsKeyPathItem then
                        match itemToTake.OriginLocation with
                        | Some itemOriginLocId ->
                            not (gs.Player.Inventory |> List.exists (fun invItem -> invItem.IsKeyPathItem && invItem.OriginLocation = Some itemOriginLocId))
                        | None -> false 
                    else true // Not a key path item, can always take if available

                if proceedWithTake then
                    let gsWithItemInInv = addItemInventory itemToTake gs
                    let locWithItemRemoved = removeItemFromLocationAvailable itemToTake.Id currentLoc
                    let finalGs = updateLocation locWithItemRemoved gsWithItemInInv
                    Ok (addMessage (sprintf "You take the %s." itemToTake.Name) finalGs)
                else
                    if itemToTake.IsKeyPathItem then
                        match itemToTake.OriginLocation with
                        | Some itemOriginLocId ->
                            Error (CannotCarryMoreKeyPathItems itemOriginLocId)
                        | None ->
                            Error (InternalLogicError (sprintf "KeyPathItem %s missing Originating Location Id" itemToTake.Name))
                    else // Should not be reached
                        Error (ItemNotTakeable itemToTake.Name)
            | None -> Error (ItemNotFound itemName)
        | Error e -> Error e

// USE command
let handleUse (itemName: string) (gs: GameState) : Result<GameState, ErrorType> =
    match getCurrentLocation gs with
    | Ok currentLoc ->
        let normalizedItemName = itemName.Trim().ToLower()        
        match gs.Player.Inventory |> List.tryFind (fun item -> item.Name.ToLower() = normalizedItemName) with
        | Some itemToUse -> //check if this item is required for any exit in the current location
            let isKeyForExit = 
                currentLoc.NextLocationUnlockRequirements
                |> Map.exists (fun dir req -> 
                    match req.RequiredItemId with
                    | Some reqId -> reqId = itemToUse.Id
                    | None -> false)
            
            if isKeyForExit then // successful item or happy path
                let directions = 
                    currentLoc.NextLocationUnlockRequirements
                    |> Map.filter (fun dir req -> 
                        match req.RequiredItemId with
                        | Some reqId -> reqId = itemToUse.Id
                        | None -> false)
                    |> Map.keys
                    |> Seq.map (sprintf "%A")
                    |> String.concat " or "
                
                let useMessage = sprintf "You use %s. It allows you to travel to %s." itemToUse.Name directions
                Ok (addMessage useMessage gs)
            else
                Ok (addMessage (sprintf "You try to use the %s, but nothing particularly interesting happens." itemToUse.Name) gs)
        | None ->
            Error (ItemNotInInventory itemName) // player doesn't have the item
    | Error e -> Error e
 
// GO command
let handleGo (direction: Direction) (gs: GameState) : Result<GameState, ErrorType> =
    match getCurrentLocation gs with
    | Ok currentLoc ->
        match Map.tryFind direction currentLoc.NextLocation with
        | Some nextLocationId ->
            match Map.tryFind direction currentLoc.NextLocationUnlockRequirements with // check if there's a requirement to go in this direction
            | Some requirement ->
                match requirement.RequiredItemId with
                | Some requiredItemId ->
                    if gs.Player.Inventory |> List.exists (fun item -> item.Id = requiredItemId) then
                        let nextGs = updatePlayerLocation nextLocationId gs // player has the required item, proceed to next location
                        match Map.tryFind nextLocationId gs.Locations with
                        | Some nextLoc -> 
                            let arrivalMessage = sprintf "You go %A and arrive at %s." direction nextLoc.Name
                            Ok (addMessage arrivalMessage nextGs)
                        | None -> 
                            Error (LocationNotFoundInWorldData nextLocationId)
                    else
                        // player doesnt have the required item
                        Error (ExitIsBlocked (sprintf "You need the '%s' to go %A."
                            (match Map.tryFind requiredItemId WorldData.allItemsMap with
                                | Some item -> item.Name
                                | None -> "specific item") // Fallback name
                            direction))
                | None ->
                    // there's an requirement entry: blocked by a riddle in the loc
                    let gsWithNewLoc = updatePlayerLocation nextLocationId gs
                    match handleLook gsWithNewLoc with
                    | Ok lookedGs -> Ok lookedGs
                    | Error e -> Error e

            | None -> // No specific requirements entry for this exit, so it's considered open
                let gsWithNewLoc = updatePlayerLocation nextLocationId gs
                match handleLook gsWithNewLoc with
                | Ok lookedGs -> Ok lookedGs
                | Error e -> Error e
        | None ->
            // Direction is not a valid exit
            Error (ExitIsBlocked (sprintf "You cannot go %A from here." direction))
    | Error e -> Error e

// EXAMINE command
let handleExamine (targetNameFromInput: string) (gs: GameState) : Result<GameState, ErrorType> =
    match getCurrentLocation gs with
    | Ok currentLoc ->
        let normalizedTarget = targetNameFromInput.Trim().ToLower()

        //examine item in the current location which triggers the riddle to be displayed 
        let foundRiddleOpt = // check if riddle in the current
            currentLoc.Riddles
            |> Map.tryPick (fun riddleId riddleData ->
                //check if the normalized target contain parts of the riddleId
                let friendlyRiddleId = riddleId.Replace("_riddle", "").Replace("_", " ")
                if normalizedTarget.Contains(friendlyRiddleId) || friendlyRiddleId.Contains(normalizedTarget) then
                    Some (riddleId, riddleData)
                else
                    None)

        match foundRiddleOpt with
        | Some (riddleId, riddleData) ->
            let message =
                if riddleData.CurrentState = NotSolved then
                    sprintf "%s\n(To answer, type: answer %s <your_answer>)" riddleData.RiddleText riddleId
                else
                    let rewardItemName =
                        match Map.tryFind riddleData.RewardItemId WorldData.allItemsMap with
                        | Some item -> item.Name
                        | None -> "a revealed item"
                    sprintf "You look at the %s. Its riddle is solved, revealing the %s." (riddleId.Replace("_riddle", "").Replace("_", " ")) rewardItemName
            Ok (addMessage message gs)

        | None -> // not a riddle

            // examine an Item in the player's inventory
            let inventoryItemOpt =
                gs.Player.Inventory
                |> List.tryFind (fun item -> item.Name.ToLower() = normalizedTarget)

            match inventoryItemOpt with
            | Some invItem ->
                Ok (addMessage (sprintf "%s: %s" invItem.Name invItem.Description) gs)

            | None ->

                //examine item in the current location's AvailableItems
                let locAvailableItemOpt =
                    currentLoc.AvailableItems
                    |> Map.values
                    |> Seq.tryFind (fun item -> item.Name.ToLower() = normalizedTarget)

                match locAvailableItemOpt with
                | Some locItem ->
                    Ok (addMessage (sprintf "%s: %s" locItem.Name locItem.Description) gs)
                | None ->

                    // examine an Item in the current location's UnavailableItems
                    let locUnavailableItemOpt =
                        currentLoc.UnavailableItems
                        |> Map.values
                        |> Seq.tryFind (fun item -> item.Name.ToLower() = normalizedTarget)

                    match locUnavailableItemOpt with
                    | Some locUnavailItem ->
                        // for items that are just scenery
                        let examineMessage =
                            match locUnavailItem.RiddleId with
                            | Some rId when (Map.find rId currentLoc.Riddles).CurrentState = NotSolved ->
                                sprintf "The %s is here, but it seems protected or locked. Perhaps examining the %s would help?"
                                    locUnavailItem.Name
                                    (rId.Replace("_riddle","").Replace("_"," "))
                            | _ ->
                                sprintf "%s: %s It seems you can't interact with it further right now." locUnavailItem.Name locUnavailItem.Description
                        Ok (addMessage examineMessage gs)
                    | None ->
                        Error (TargetNotFound targetNameFromInput)
    | Error e -> Error e // Error from getCurrentLocation