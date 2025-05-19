module DataTypes


type Direction = North | East | West 

type Item =
    { Id: string          
      Name: string         
      Description: string   
      IsKeyPathItem: bool 
      RiddleId: string option // (Set of Riddle Identifiers ∪ {None})
    }


type RiddleState = NotSolved | Solved

type Riddle =
    { RiddleText: string
      Solution: string         
      RewardItemId: string     
      CurrentState: RiddleState
    }

type NextLocationRequirement =
    { RequiredItemId: string option
    }

type Location =
    { Id: string
      Name: string
      Description: string
      UnavailableItems: Map<string, Item> 
      AvailableItems: Map<string, Item>   
      NextLocation: Map<Direction, string>  
      Riddles: Map<string, Riddle>       
      NextLocationUnlockRequirements: Map<Direction, NextLocationRequirement>
    }

type Player =
    { CurrentLocationId: string
      Inventory: list<Item>
    }

