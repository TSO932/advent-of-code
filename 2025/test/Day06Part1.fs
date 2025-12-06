namespace _2025.Tests

open NUnit.Framework
open _2025

[<TestFixture>] 
type Day06Part1 () =

    [<Test>]
    member _.Example() =
    
        let input = [
            "123 328  51 64 ";
            " 45 64  387 23 ";
            "  6 98  215 314";
            "*   +   *   +  "
            ]

        Assert.That(Day06Part1.run(input), Is.EqualTo(4277556L))
