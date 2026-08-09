namespace AoC2020.Tests

open NUnit.Framework
open AoC2020
open AoC2020.Day16Part1

[<TestFixture>] 
type Day16Part1 () =

    [<DefaultValue>] val mutable ruleSet : seq<int*int>

    [<SetUp>]
    member this.SetUp() =
        this.ruleSet <- seq { (1, 3); (5, 7) ; (6, 11); (33, 44) ; (13, 40); (45, 50) }

    [<Test>]
    member _.splitBlocks() = 
        let actual = splitBlocks (seq {"a"; "b"; ""; "c"; "d"; "e"; ""; "f"; "g"; "h"})
        let expected = (seq {"a"; "b"}, seq {"d"; "e"}, seq {"g"; "h"})
        Assert.AreEqual(expected, actual)

    [<Test>]
    member _.parseValidityRule() = 
        let actual = parseValidityRule ("class: 0-1 or 4-19")
        let expected = { IsDeparture = false; Ranges = seq { (0, 1); (4, 19) } }
        Assert.AreEqual(expected, actual)

    [<Test>]
    member _.``parseValidityRule sets IsDeparture to true if test contains the work departure``() = 
        let actual = parseValidityRule ("point of departure: 4-8 or 15-16 or 23-42")
        let expected = { IsDeparture = true; Ranges = seq { (4, 8); (15, 16); (23, 42) } }
        Assert.AreEqual(expected, actual)

    [<Test>]
    member _.``parseValidityRule throws when a range contains non-numeric values``() =
        let input = "class: 1-3 or invalid-range"
        let ex = Assert.Throws<System.Exception>(fun () -> parseValidityRule(input) |> ignore)
        Assert.AreEqual("Expected numeric values.", ex.Message)

    [<Test>]
    member _.``parseValidityRule throws when a range missing a hyphen``() =
        let input = "class: 1-3 or 13"
        let ex = Assert.Throws<System.Exception>(fun () -> parseValidityRule(input) |> ignore)
        Assert.AreEqual("Expected hyphen-seperated pairs of values.", ex.Message)

    [<Test>]
    member _.parseValidityRules() =

        let input = seq {
            "class: 1-3 or 5-7";
            "row: 6-11 or 33-44";
            "seat: 13-40 or 45-50"
            }

        let expected = seq {
            { IsDeparture = false; Ranges = seq { (1, 3); (5, 7) } };
            { IsDeparture = false; Ranges = seq { (6, 11); (33, 44) } };
            { IsDeparture = false; Ranges = seq { (13, 40); (45, 50) } }
            }

        Assert.AreEqual(expected, parseValidityRules(input))

    [<Test>]
    member _.parseMyTicket() =
        let input = seq { "7,1,14" }
        let expected = seq { 7; 1; 14 }
        Assert.AreEqual(expected, parseMyTicket(input))

    [<Test>]
    member this.``ErrorRate Example 0 is valid``() =
        Assert.AreEqual(0, errorRate (seq { 7; 1; 14 }) this.ruleSet)

    [<Test>]
    member this.``ErrorRate Example 1 is valid``() =
        Assert.AreEqual(0, errorRate (seq { 7; 13; 47 }) this.ruleSet)
        
    [<Test>]
    member this.``ErrorRate Example 2 is invalid``() =
        Assert.AreEqual(4, errorRate (seq { 40; 4; 50 }) this.ruleSet)
        
    [<Test>]
    member this.``ErrorRate Example 3 is invalid``() =
        Assert.AreEqual(55, errorRate (seq { 55; 2; 20 }) this.ruleSet)
        
    [<Test>]
    member this.``ErrorRate Example 4 is invalid``() =
        Assert.AreEqual(12, errorRate (seq { 38; 6; 12 }) this.ruleSet)

    [<Test>]
    member _.Example() =

        let input = seq {
            "class: 1-3 or 5-7";
            "row: 6-11 or 33-44";
            "seat: 13-40 or 45-50";
            "";
            "your ticket:";
            "7,1,14";
            "";
            "nearby tickets:";
            "7,3,47";
            "40,4,50";
            "55,2,20";
            "38,6,12" }
        
        Assert.AreEqual(71, sumErrors(input))

    [<Test>]
    member _.``parseValidityRule throws error if too few sections of data``() =
        let input = seq { "class: 1-3 or 5-7"; "row: 6-11 or 33-44" }
        let ex = Assert.Throws<System.Exception>(fun () -> splitBlocks(input) |> ignore)
        Assert.AreEqual("Expected three sections of input data.", ex.Message)

