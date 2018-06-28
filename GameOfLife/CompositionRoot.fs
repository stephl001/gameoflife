namespace GameOfLife

module CompositionRoot =
    open GameOfLife.Domain
    
    let executeApplication imp (argv:ConsoleArguments) : Terminal =
        match imp argv with
        | Error Missing -> WriteLine ("Missing required argument: path", EndProgram)
        | Error (TooManyArguments argCount) -> 
            WriteLine ((sprintf "Expected one argument but got %d instead." argCount), EndProgram)
        | Error (NotFound path) -> 
            WriteLine ((sprintf "The path '%s' must point to an existing file." path), EndProgram)
        | Error (IOError (path,ex)) -> 
            WriteLine ((sprintf "An exception was caught while loading '%s'." path), 
                WriteLine ((sprintf "%A" ex), EndProgram))