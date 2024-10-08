namespace AoC2020.Tests

open System.IO
open NUnit.Framework
open AoC2020

[<TestFixture>] 
type Day23Part2 () =

    [<Test>]
    member this.GetCircleOfCups() =
        Assert.AreEqual([|2; 4; 1; 3; 5; 6|], Day23Part2.getCircleOfCups("2413").[0..5])
        Assert.AreEqual(1000000, Day23Part2.getCircleOfCups("2413").[999999])
   
    [<Test>]
    member this.Play() = Assert.AreEqual(2000000000L, Day23Part2.play(1, [|30000; 80000; 90000; 1; 20000; 50000; 40000; 60000; 70000|]))
   
    [<Test>]
    [<Ignore("Too long. Don't run.")>]
    member this.Example10000000Rounds() = Assert.AreEqual(149245887792L, Day23Part2.play(10000000, Day23Part2.getCircleOfCups("389125467")))

