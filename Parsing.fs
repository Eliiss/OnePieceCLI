module Parsing

open DataTypes
open System


let private normalize (input: string) : string =
    input.Trim().ToLower() // this trims white spaces in users input and lowers the cases for easier matching with commands and answers 

let private parseDirection (directionStr: string) : Direction option =
    match directionStr with
    | "east"  | "e" -> Some East
    | "west"  | "w" -> Some West
    | _ -> None // Not a recognized direction string



// --- Main Parsing Function ---

// TOTAL and PURE: it always returns a Command case (InvalidCommand for errors);given the same input string, it always returns the same Command
let parsePlayerInput (playersInput: string) : Command =
    let normalized = normalize playersInput
    
    let partsList : list<string> =
        normalized.Split([|' '|], StringSplitOptions.RemoveEmptyEntries)
        |> Array.toList 

    match partsList with
    // --- Commands with 1 word ---
    | ["look"] | ["l"] -> Look
    | ["inventory"] | ["i"] -> CheckInventory
    | ["help"] | ["h"] -> Help
    | ["quit"] | ["q"] -> Quit

    // --- GO: "go <direction>" or "<direction>" ---
    | ["go"; directionStr] -> // "go west"
        match parseDirection directionStr with
        | Some dir -> Go dir
        | None -> InvalidCommand playersInput //"go left"

    | [singleWordDirectionStr] -> //"west"
        match parseDirection singleWordDirectionStr with
        | Some dir -> Go dir // single word will be treated as a go command
        | None -> InvalidCommand playersInput // if something that is not a direction is typed

    // --- TAKE command: followed by one or more words for the item name
    | "take" :: itemNameParts -> // "take weatheredLogPose" -> itemNameParts = ["weathered"; "LogPose"]
        let itemName = String.concat " " itemNameParts
        if String.IsNullOrWhiteSpace(itemName) then
            InvalidCommand playersInput // Player typed "take" with nothing after it
        else
            Take itemName

    // Synonym "get"
    | "get" :: itemNameParts ->
        let itemName = String.concat " " itemNameParts
        if String.IsNullOrWhiteSpace(itemName) then
            InvalidCommand playersInput
        else
            Take itemName

    // --- DROP command (as take it can have multi-word item names) ---
    | "drop" :: itemNameParts ->
        let itemName = String.concat " " itemNameParts
        if String.IsNullOrWhiteSpace(itemName) then
            InvalidCommand playersInput
        else
            Drop itemName

    // --- EXAMINE command ---
    | "examine" :: targetParts ->
        let targetName = String.concat " " targetParts
        if String.IsNullOrWhiteSpace(targetName) then
            InvalidCommand playersInput
        else
            Examine targetName

    // --- ANSWER command ("answer western_tablet_riddle map") ---
    | "answer" :: partsWhenAnswer ->
        match partsWhenAnswer with
        | [] -> InvalidCommand playersInput // Just "answer"
        | [riddleTargetId] -> InvalidCommand playersInput // "answer tablet_name" (missing the answer)
        | riddleTargetId :: playerAnswerParts -> // riddleTargetId is first word, rest are the answer
            let playerAnswer = String.concat " " playerAnswerParts
            Answer (riddleTargetId, playerAnswer) // riddleTargetId is also normalized

    // --- USE command ---
    | "use" :: itemNameParts ->
        let itemName = String.concat " " itemNameParts
        if String.IsNullOrWhiteSpace(itemName) then
            InvalidCommand playersInput
        else
            Use itemName

    // --- Catch for anything not matched above ---
    | _ -> InvalidCommand playersInput // If input doesn't match any known command structure
