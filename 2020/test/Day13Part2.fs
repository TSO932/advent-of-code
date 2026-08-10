namespace AoC2020.Tests

open NUnit.Framework
open AoC2020
open AoC2020.Day13Part2

[<TestFixture>] 
type Day13Part2 () =

    [<Test>]
    member _.Example1() = 
        let input = seq {
            "939";
            "7,13,x,x,59,x,31,19" } 

        Assert.AreEqual(1068781L, nextBus (input))

    [<Test>]
    member _.Example2() = 
        let input = seq {
            "";
            "17,x,13,19" } 

        Assert.AreEqual(3417L, nextBus (input))

    [<Test>]
    member _.Example3() = 
        let input = seq {
            "";
            "67,7,59,61" } 

        Assert.AreEqual(754018L, nextBus (input))

    [<Test>]
    member _.Example4() = 
        let input = seq {
            "";
            "67,x,7,59,61" } 

        Assert.AreEqual(779210L, nextBus (input))

    [<Test>]
    member _.Example5() = 
        let input = seq {
            "";
            "67,7,x,59,61" } 

        Assert.AreEqual(1261476L, nextBus (input))

    [<Test>]
    member _.Example6() = 
        let input = seq {
            "";
            "1789,37,47,1889" } 

        Assert.AreEqual(1202161486L, nextBus (input))


    [<Test>]
    member _.RecursiveLoop() =
        let input = seq {
            "0";
            "x,20011" }

        let ex = Assert.Throws<System.Exception>(fun () -> nextBus(input) |> ignore)
        Assert.AreEqual("recursive loop with 10,000 itterations", ex.Message)