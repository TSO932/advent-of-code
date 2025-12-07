namespace _2025.Tests

open NUnit.Framework
open _2025

[<TestFixture>] 
type Day07Part2 () =

    [<Test>]
    member _.SplitBeams() =

        let inputBeamRow = ("......|.|......" |> Array.ofSeq, 1)
        let inputdeflectorRow = "......^.^......" |> Array.ofSeq
        let expected = [
            (".....|.|......." |> Array.ofSeq, 1);
            (".....|...|....." |> Array.ofSeq, 1);
            (".......|......." |> Array.ofSeq, 1);
            (".......|.|....." |> Array.ofSeq, 1)
            ]

        Assert.That(Day07Part2.splitBeams(inputBeamRow, inputdeflectorRow), Is.EqualTo(expected))

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

        Assert.That(Day07Part2.run(input), Is.EqualTo(40))
