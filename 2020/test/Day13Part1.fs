namespace AoC2020.Tests

open NUnit.Framework
open AoC2020

[<TestFixture>] 
type Day13Part1 () =

    [<Test>]
    member this.Example() = 
        let input = seq {
            "939";
            "7,13,x,x,59,x,31,19" } 

        Assert.AreEqual(295L, Day13Part1.nextBus (input))