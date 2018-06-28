namespace GameOfLife.Tests

module PureTerminalInterpreter =
    open GameOfLife.Domain

    let interpret terminal =
        let rec step l = function
        | WriteLine (line,t) -> step (line::l) t
        | EndProgram -> l

        step [] terminal |> List.rev

