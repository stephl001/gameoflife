namespace GameOfLife.Tests

open Xunit
open FsUnit.Xunit

module SampleTest =

    [<Fact>]
    let DoSomeMath() = 
        1 + 2 |> should equal 3