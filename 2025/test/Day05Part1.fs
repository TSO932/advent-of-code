namespace _2025.Tests

open NUnit.Framework
open _2025

[<TestFixture>] 
type Day05Part1 () =

    [<Test>]
    member _.Example() =
    
        let input = [
            "3-5";
            "10-14";
            "16-20";
            "12-18";
            "";
            "1";
            "5";
            "8";
            "11";
            "17";
            "32"
            ]

        Assert.That(Day05Part1.run(input), Is.EqualTo(3))
