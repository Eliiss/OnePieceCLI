module Display

open System
open DataTypes

let private formatItemList (items: Map<string, Item>) (prefix: string) : string =
    if Map.isEmpty items then
        sprintf "%s nothing special." prefix 
    else
        items
        |> Map.values
        |> Seq.map (fun item -> item.Name)
        |> String.concat ", "
        |> sprintf "%s %s." prefix

let private formatRiddle (riddles: Map<string, Riddle>) : string =
    if Map.isEmpty riddles then
        "" 
    else
        riddles
        |> Map.filter (fun _ rData -> rData.CurrentState = NotSolved) // Only list unsolved
        |> Map.keys
        |> Seq.map (fun rId -> rId.Replace("_riddle", "").Replace("_", " ")) // Make more readable
        |> String.concat ", "
        |> fun str -> if String.IsNullOrWhiteSpace str then "" else sprintf "You notice things you could examine: %s." str


let private formatNextLocation (exits: Map<Direction, string>) : string =
    if Map.isEmpty exits then
        "There are no exits."
    else
        exits
        |> Map.keys
        |> Seq.map (sprintf "%A")
        |> String.concat ", "
        |> sprintf "Exits are to the: %s."

// Main function to display information for the current location
let getLocationDisplayInfo (gs: GameState) : list<string> =
    match Map.tryFind gs.Player.CurrentLocationId gs.Locations with
    | Some loc ->
        [ sprintf "--- %s ---" loc.Name // Location Name header
          loc.Description
          "" // Blank line for spacing
          formatItemList loc.AvailableItems "You see available:"
          formatRiddle loc.Riddles
          formatNextLocation loc.NextLocation
        ]
        |> List.filter (fun s -> not (String.IsNullOrWhiteSpace s)) 
    | None ->
        [ "ERROR: You are lost in an unknown seas!" ]

let formatPlayerInventory (gs: GameState) : string =
    if Set.isEmpty gs.Player.Inventory then
        "Your inventory is empty."
    else
        let itemsStr = gs.Player.Inventory |> Set.map (fun item -> item.Name) |> String.concat ", "
        sprintf "You are carrying: %s." itemsStr

//printing all messages accumulated in GameState.MessagesToDisplay
let displayAndClearPendingMessages (gs: GameState) : GameState * bool = 
    if not (List.isEmpty gs.MessagesToDisplay) then
        printfn "\n--- Messages ---" 
        gs.MessagesToDisplay
        |> List.rev // Display oldest messages first, newest last
        |> List.iter (printfn "%s")
        printfn "----------------"
        ({ gs with MessagesToDisplay = [] }, true) // Clear messages for the next turn
    else
        (gs, false) // No messages to display

