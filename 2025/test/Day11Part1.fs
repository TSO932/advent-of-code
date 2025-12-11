namespace _2025.Tests

open NUnit.Framework
open _2025

[<TestFixture>] 
type Day11Part1 () =

    [<Test>]
    member _.Example() =
    
        let input = [
            "aaa: you hhh";
            "you: bbb ccc";
            "bbb: ddd eee";
            "ccc: ddd eee fff";
            "ddd: ggg";
            "eee: out";
            "fff: out";
            "ggg: out";
            "hhh: ccc fff iii";
            "iii: out"
            ]

        Assert.That(Day11Part1.run(input), Is.EqualTo(5))
