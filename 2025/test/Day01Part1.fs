namespace _2025.Tests

open NUnit.Framework
open _2025

[<TestFixture>]
type Day01Part1 () =

    [<Test>]
    member _.Example() =
        Assert.That(Day01Part1.run [|"World"; "ignore me"|], Is.EqualTo("Hello World!"))




