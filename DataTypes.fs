module DataTypes

type Direction = North | East | West // discriminated union (DU)

type Item = //record
    { Id: string          
      Name: string         
      Description: string   // shown only after riddle solved
      IsKeyPathItem: bool 
      RiddleId: string option // (Set of Riddle Identifiers UNION {None})
    }


type RiddleState = NotSolved | Solved // DU

type Riddle = //record
    { RiddleText: string
      Solution: string         
      RewardItemId: string     
      CurrentState: RiddleState
      SolvedMessage: string
      RewardAppearsMessage: string
    }

type NextLocationRequirement = //record
    { RequiredItemId: string option
    }

type Location = //record
    { Id: string
      Name: string
      Description: string
      UnavailableItems: Map<string, Item> // items present but hidden 
      AvailableItems: Map<string, Item>   // items that are present and takeable (riddle has been solved)
      NextLocation: Map<Direction, string>  
      Riddles: Map<string, Riddle>       
      NextLocationUnlockRequirements: Map<Direction, NextLocationRequirement> //item.id that must be in inventory
    }

type Player = // record
    { CurrentLocationId: string
      Inventory: list<Item>
    }

type Command = //DU
| Go of Direction
| Look
| Examine of target:string
| Answer of riddleTarget:string * playerAnswer:string
| Take of itemName:string
| Drop of itemName:string
| Use of itemName:string 
| CheckInventory
| Help
| Quit

type GameState = // record 
    { Locations: Map<string, Location>  
      Player: Player                    
      MessagesToDisplay: list<string>   
      IsGameOver: bool                  
    }

type ErrorType = // DU
    | InvalidUserCommand of originalInput: string // parser can't make sense of input
    | TargetNotFound of targetName: string       // For examine, use if item isn't in location/inventory
    | ItemNotTakeable of itemName: string         // Attempt to take an item flagged as not takeable
    | ItemNotInInventory of itemName: string      // For drop, use if player doesn't have it in their inventory
    | CannotCarryMoreKeyPathItems               // one key path - only carry one item of each location
    | ExitIsBlocked of reason: string             // if riddle not solved 
    | RiddleAlreadySolved of riddleTargetId: string
    | IncorrectRiddleAnswer
    | CannotUseItemHere of itemName: string       // Item is not valid in current location
    | InternalLogicError of debugMessage: string // A catch-all for unexpected situations

