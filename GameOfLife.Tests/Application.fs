namespace GameOfLife.Tests

open Xunit
open FsUnit.Xunit

module Application =
    open GameOfLife
    open GameOfLife.Domain
    open GameOfLife.CompositionRoot
    open FsCheck
    open FsCheck.Xunit
    open FsCheck

    [<Fact>]
    let ``Make sure we get a valid error message if not argument is provided``() = 
        let imp _ = Error Missing
        let terminal = executeApplication imp [||] 
        PureTerminalInterpreter.interpret terminal
        |> should equal ["Missing required argument: path"]

    [<Property>]
    let ``Make sure we get a valid error message if too many arguments are provided`` 
        argCount = 
        (argCount > 1) ==> lazy

        let imp _ = Error (TooManyArguments argCount)
        let terminal = executeApplication imp [||] 
        PureTerminalInterpreter.interpret terminal
        |> should equal [sprintf "Expected one argument but got %d instead." argCount]

    [<Property>]
    let ``Make sure we get a valid error message if a path to a Gen.nonEmptyListOf-existing file is provided`` (id:System.Guid) = 
        let filePath = sprintf @"c:\%A\input.txt" id
        let imp _ = Error (NotFound filePath)
        let terminal = executeApplication imp [||] 
        PureTerminalInterpreter.interpret terminal
        |> should equal [sprintf "The path '%s' must point to an existing file." filePath]

    [<Fact>]
    let ``Make sure we get a valid error message when an IO exception is raised.`` () = 
        let ex = new System.IO.FileLoadException("some message")
        let imp _ = Error (IOError ("some path",ex))
        let terminal = executeApplication imp [||] 
        PureTerminalInterpreter.interpret terminal
        |> should equal 
            [
                sprintf "An exception was caught while loading 'some path'."
                sprintf "%A" ex
            ]