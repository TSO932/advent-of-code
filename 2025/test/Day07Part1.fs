namespace _2025.Tests

open NUnit.Framework
open _2025

[<TestFixture>] 
type Day07Part1 () =

    [<Test>]
    member _.SplitBeams() =

        let inputBeamRow = "......|.|......" |> Array.ofSeq
        let inputdeflectorRow = "......^.^......" |> Array.ofSeq
        let expected = ".....|.|.|....." |> Array.ofSeq

        Assert.That(Day07Part1.splitBeams((1, inputBeamRow), inputdeflectorRow), Is.EqualTo((3, expected)))

    [<Test>]
    member _.Example() =
    
        let input = [
            ".......S.......";
            "...............";
            ".......^.......";
            "...............";
            "......^.^......";
            "...............";
            ".....^.^.^.....";
            "...............";
            "....^.^...^....";
            "...............";
            "...^.^...^.^...";
            "...............";
            "..^...^.....^..";
            "...............";
            ".^.^.^.^.^...^.";
            "..............."
            ]

        Assert.That(Day07Part1.run(input), Is.EqualTo(21))
