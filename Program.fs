open DataTypes


[<EntryPoint>]
let main argv =
    let startDirection = North // Uses Direction DU from DomainTypes
    let testItem : Item = { Id="test001"; Name="Test Item"; Description="A simple test."; IsKeyPathItem=false; RiddleId=None }

    printfn "Direction: %A" startDirection
    printfn "Item Name: %s" testItem.Name
    0 