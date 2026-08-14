namespace AoC2020.Tests

open System.IO
open NUnit.Framework
open AoC2020
open AoC2020.Day20Part2

[<TestFixture>] 
type Day20Part2 () =

    [<Test>]
    member this.Example() = Assert.AreEqual(273, calculateSeaRoughness (File.ReadAllLines("../../../data/Day20/test1.txt")))

    // [<Test>]
    // member this.FourTiles() = Assert.AreEqual(132, calculateSeaRoughness (File.ReadAllLines("../../../data/Day20/test2.txt")))

    [<Test>]
    member this.IsSeaMonster() =
    
        let input = array2D [
            [| '_'; '.'; ' '; ' '; ' '; ' '; ' '; ' '; ' '; ' '; ' '; ' '; ' '; ' '; ' '; ' '; ' '; ' '; '#'; ' ' |];
            [| '#'; ' '; ' '; ' '; ' '; '#'; '#'; ' '; ' '; ' '; ' '; '#'; '#'; ' '; ' '; ' '; ' '; '#'; '#'; '#' |];
            [| ' '; '#'; ' '; ' '; '#'; ' '; ' '; '#'; ' '; ' '; '#'; ' '; ' '; '#'; ' '; ' '; '#'; ' '; ' '; ' ' |] ]

        Assert.AreEqual(true, isSeaMonster input)

    [<Test>]
    member this.IsNotSeaMonster() =
    
        let input = array2D [
            [| '_'; '.'; ' '; ' '; ' '; ' '; ' '; ' '; ' '; ' '; ' '; ' '; ' '; ' '; ' '; ' '; ' '; ' '; '#'; ' ' |];
            [| '#'; ' '; ' '; ' '; ' '; '#'; '#'; ' '; ' '; ' '; ' '; '#'; '#'; ' '; ' '; ' '; ' '; '#'; '#'; '#' |];
            [| ' '; '?'; ' '; ' '; '#'; ' '; ' '; '#'; ' '; ' '; '#'; ' '; ' '; '#'; ' '; ' '; '#'; ' '; ' '; ' ' |] ]

        Assert.AreEqual(false, isSeaMonster input)