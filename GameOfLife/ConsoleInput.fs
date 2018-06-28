namespace GameOfLife

module ConsoleInput =
    open GameOfLife.Domain

    let readConsoleInputArguments (argv:ConsoleArguments) = 
        match argv with 
        | [||] -> Error Missing
        | [|arg|] -> Ok (PathArgument arg)
        | args -> Error (TooManyArguments args.Length)

