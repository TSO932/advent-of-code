namespace _2025.Tests

open NUnit.Framework
open _2025

[<TestFixture>] 
type Day06Part2 () =

    [<Test>]
    member _.Example() =
    
        let input = [
            "123 328  51 64 ";
            " 45 64  387 23 ";
            "  6 98  215 314";
            "*   +   *   +  "
            ]

        Assert.That(Day06Part2.run(input), Is.EqualTo(3263827L))
