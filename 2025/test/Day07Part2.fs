namespace _2025.Tests

open NUnit.Framework
open _2025

[<TestFixture>] 
type Day07Part2 () =

    [<Test>]
    member _.SplitBeams() =

        let inputBeamRow = "......|.|......" |> Array.ofSeq
        let inputdeflectorRow = "......^.^......" |> Array.ofSeq
        let expected = [
            (3, ".....|.|......." |> Array.ofSeq);
            (3, ".....|...|....." |> Array.ofSeq);
            (3, ".......|......." |> Array.ofSeq);
            (3, ".......|.|....." |> Array.ofSeq)
            ]

        Assert.That(Day07Part2.splitBeams((1, inputBeamRow), inputdeflectorRow), Is.EqualTo(expected))

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
