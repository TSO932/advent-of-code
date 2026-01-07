namespace _2025.Tests

open NUnit.Framework
open _2025

[<TestFixture>] 
type Day09Part2 () =

    [<Test>]
    member _.Example() =
    
        let input = [
            "7,1";
            "11,1";
            "11,7";
            "9,7";
            "9,5";
            "2,5";
            "2,3";
            "7,3"
            ]

        Assert.That(Day09Part2.run(input), Is.EqualTo(24))

       
        