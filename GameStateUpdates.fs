module GameStateUpdates

open DataTypes

//messages handling------
let addMessage (message:string) (gs: GameState): GameState = 
    {gs with MessagesToDisplay = message ::gs.MessagesToDisplay} 

let addMessages (newMessages: list<string>) (gs: GameState) : GameState =
    { gs with MessagesToDisplay = newMessages @ gs.MessagesToDisplay } // adds multiple messages, new ones are at the top

let clearMessages (gs: GameState) : GameState =
    { gs with MessagesToDisplay = [] }

//player updates-----
let updatePlayerLocation (newLocationId: string) (gs: GameState) : GameState =
    { gs with Player = { gs.Player with CurrentLocationId = newLocationId } }

let addItemInventory (newItem: Item) (gs: GameState): GameState=
   {gs with Player = {  gs.Player with Inventory = Set.add newItem gs.Player.Inventory} }

let deleteItemInventory (itemId: string) (gs: GameState): GameState =
    let updatedInventory = gs.Player.Inventory |> Set.filter (fun invItem -> invItem.Id <> itemId)
    { gs with Player = { gs.Player with Inventory = updatedInventory } }

//location state updates-----
let updateLocation (updatedLocation: Location) (gs: GameState): GameState = 
    { gs with Locations = Map.add updatedLocation.Id updatedLocation gs.Locations} //updates a location within the gs 

let makeItemAvailable (itemId: string) (loc: Location) : Location =
    match Map.tryFind itemId loc.UnavailableItems with
    | Some itemToMove ->
        { loc with
            UnavailableItems = Map.remove itemId loc.UnavailableItems
            AvailableItems = Map.add itemToMove.Id itemToMove loc.AvailableItems 
        }// makes an item from a location's UnavailableItems to AvailableItem
    | None -> loc //item was not in UnavailableItems list

let markRiddleAsSolved (riddleId: string) (loc: Location) : Location =
    match Map.tryFind riddleId loc.Riddles with
    | Some riddle ->
        let solvedRiddle = { riddle with CurrentState = Solved }
        { loc with Riddles = Map.add riddleId solvedRiddle loc.Riddles } // updates a riddle to solved within a location
    | None -> loc // riddle not found, unchanged

let addItemToLocation (item: Item) (loc: Location) : Location =
    { loc with AvailableItems = Map.add item.Id item loc.AvailableItems } // adds a dropped item to a location's AvailableItems

let removeItemFromLocationAvailable (itemId: string) (loc: Location) : Location =
    { loc with AvailableItems = Map.remove itemId loc.AvailableItems } // removes an item from a location's AvailableItems (when taken)
