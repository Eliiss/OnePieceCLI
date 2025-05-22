module Program

open System // For Console.ReadLine, Console.Clear (optional)
open DataTypes
open WorldData // Contains initialGameState
open Parsing
open LogicHandlers
open GameStateUpdates // For addMessage, clearMessages etc. if not directly in Program
open Display // For formatting functions

// Clears the console (optional, for a cleaner look each turn)
let private clearConsole() =
    // This works on Windows, macOS, Linux if terminal supports ANSI escape codes
    // For a simpler cross-platform approach without special chars, just print many new lines.
    if System.Environment.OSVersion.Platform = PlatformID.Win32NT then
        System.Console.Clear()
    else
        printf "\u001b[2J\u001b[H" // ANSI escape code to clear screen and move cursor to top-left

// Main recursive game loop
let rec gameLoop (currentState: GameState) : unit =
    clearConsole() // Optional: Clears screen each turn

    // 1. Display accumulated messages from the previous turn
    let gsAfterMessagesDisplayed, _ = displayAndClearPendingMessages currentState

    // 2. Display current location information (if not game over)
    if not gsAfterMessagesDisplayed.IsGameOver then
        let locationInfoLines = getLocationDisplayInfo gsAfterMessagesDisplayed
        locationInfoLines |> List.iter (printfn "%s")
        printfn "--------------------" // Separator

    // 3. Check if game is over
    if gsAfterMessagesDisplayed.IsGameOver then
        printfn "\nGame Over. Thank you for playing!"
        // gsAfterMessagesDisplayed.MessagesToDisplay will likely contain the "Goodbye" message from handleQuit
        // We already printed messages above.
    else
        // 4. Get player input
        printf "\n> " // Prompt
        let userInput = Console.ReadLine()

        // 5. Parse input
        let command = Parsing.parsePlayerInput userInput

        // 6. Process command using LogicHandlers
        let resultOfAction =
            match command with
            | Look -> LogicHandlers.handleLook gsAfterMessagesDisplayed
            | Go direction -> LogicHandlers.handleGo direction gsAfterMessagesDisplayed
            | Take itemName -> LogicHandlers.handleTake itemName gsAfterMessagesDisplayed
            | Drop itemName -> LogicHandlers.handleDrop itemName gsAfterMessagesDisplayed
            | Examine targetName -> LogicHandlers.handleExamine targetName gsAfterMessagesDisplayed
            | Answer (riddleId, answer) -> LogicHandlers.handleAnswerRiddle riddleId answer gsAfterMessagesDisplayed
            | Use itemName -> LogicHandlers.handleUse itemName gsAfterMessagesDisplayed
            | CheckInventory -> LogicHandlers.handleInventory gsAfterMessagesDisplayed
            | Help -> LogicHandlers.handleHelp gsAfterMessagesDisplayed
            | Quit -> LogicHandlers.handleQuit gsAfterMessagesDisplayed
            | InvalidCommand originalInput ->
                let msg = sprintf "I don't understand '%s'. Type 'help' for available commands." originalInput
                Ok (GameStateUpdates.addMessage msg gsAfterMessagesDisplayed) // Return Ok with the message added

        // 7. Handle the result (Ok with new state, or Error with error type)
        match resultOfAction with
        | Ok newGameState ->
            gameLoop newGameState // Recurse with the new state
        | Error errorType ->
            let errorMsgString = // Convert ErrorType to a user-friendly string
                match errorType with
                | InvalidUserCommand o -> sprintf "Sorry, '%s' isn't a valid command structure." o
                | TargetNotFound t -> sprintf "You don't see any '%s' here to examine." t
                | ItemNotFound i -> sprintf "You can't find any '%s'." i
                | ItemNotTakeable i -> sprintf "You can't take the %s." i
                | ItemNotInInventory i -> sprintf "You aren't carrying a %s." i
                | CannotCarryMoreKeyPathItems locName -> sprintf "You're already focused on a key item from %s. Drop it first to take another from here." locName
                | ExitIsBlocked reason -> reason // reason should be user-friendly
                | RiddleNotFound rId -> sprintf "There's no riddle associated with '%s' here." (rId.Replace("_riddle","").Replace("_"," "))
                | RiddleAlreadySolved rId -> sprintf "You've already solved the riddle of the %s." (rId.Replace("_riddle","").Replace("_"," "))
                | IncorrectRiddleAnswer -> "That's not the right answer to the riddle."
                | CannotUseItemHere i -> sprintf "You can't use the %s in this way here." i
                | LocationNotFoundInWorldData locId -> sprintf "Critical Error: Location '%s' is missing from game data!" locId
                | InternalLogicError debugMsg -> sprintf "A strange glitch occurs in the fabric of reality (%s). Try something else." debugMsg

            // Loop again with the *previous* state (gsAfterMessagesDisplayed), but with the new error message added
            let gsWithError = GameStateUpdates.addMessage (sprintf "Error: %s" errorMsgString) gsAfterMessagesDisplayed
            gameLoop gsWithError

[<EntryPoint>]
let main argv =
    printfn "--- Welcome to the One Piece Text Adventure! ---"
    // initialGameState is defined in WorldData.fs and opened
    gameLoop WorldData.initialGameState
    0 // Return an integer exit code
 