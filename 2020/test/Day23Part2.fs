namespace AoC2020.Tests

open NUnit.Framework
open AoC2020

[<TestFixture>] 
type Day23Part2 () =

    [<Test>]
    member this.Example() = Assert.AreEqual(149245887792L, Day23Part2.playGame("389125467"))

