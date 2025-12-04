namespace _2025.Tests

open NUnit.Framework
open _2025

[<TestFixture>] 
type Day04Part2 () =

    [<Test>]
    member _.Example() =
    
        let input = [
            "..@@.@@@@.";
            "@@@.@.@.@@";
            "@@@@@.@.@@";
            "@.@@@@..@.";
            "@@.@@@@.@@";
            ".@@@@@@@.@";
            ".@.@.@.@@@";
            "@.@@@.@@@@";
            ".@@@@@@@@.";
            "@.@.@@@.@."            
            ]

        Assert.That(Day04Part2.run(input), Is.EqualTo(43))
