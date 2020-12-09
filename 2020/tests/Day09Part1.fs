namespace AoC2020.Tests

open System.IO
open NUnit.Framework
open AoC2020

[<TestFixture>] 
type Day09Part1 () =

    [<Test>]
    member this.Example1() = Assert.AreEqual(127, Day09Part1.findInvalidNum (File.ReadAllLines("../../../data/Day09/test1.txt"), 5))