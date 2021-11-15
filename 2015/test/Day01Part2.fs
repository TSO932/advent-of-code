namespace AoC2015.Tests

open NUnit.Framework
open AoC2015

[<TestFixture>] 
type Day01Part2 () =

    [<Test>]
    member _.Example1() = Assert.AreEqual(1, Day01Part2.getFirstStepIntoBasement ([|")"|]))

    [<Test>]
    member _.Example2() = Assert.AreEqual(5, Day01Part2.getFirstStepIntoBasement ([|"()())"|]))