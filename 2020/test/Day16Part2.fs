namespace AoC2020.Tests

open NUnit.Framework
open AoC2020
open AoC2020.Day16Part2

[<TestFixture>] 
type Day16Part2 () =

    [<Test>]
    member _.parseMyTicket() =
        let input = seq { "7,1,14" }
        let expected = seq { 7L; 1L; 14L }
        Assert.AreEqual(expected, parseMyTicket(input))
        
    [<Test>]
    member _.calculate() =


        let input = seq {
            "departure class: 0-1 or 4-19";
            "row: 0-5 or 8-19";
            "departure seat: 0-13 or 16-19";
            "";
            "your ticket:";
            "11,12,13";
            "";
            "nearby tickets:";
            "3,9,18";
            "15,1,5";
            "5,14,9";
            "7,3,47";
            "40,4,50";
            "55,2,20";
            "38,6,12" }
        
        Assert.AreEqual(156L, calculate(input))