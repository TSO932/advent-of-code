namespace AoC2020.Tests

open NUnit.Framework
open AoC2020
open AoC2020.Day16Part1

[<TestFixture>] 
type Day16Part1 () =

    [<DefaultValue>] val mutable ruleSet : seq<int64*int64>

    [<SetUp>]
    member this.SetUp() =
        this.ruleSet <- seq { (1L, 3L); (5L, 7L) ; (6L, 11L); (33L, 44L) ; (13L, 40L); (45L, 50L) }

    [<Test>]
    member _.splitBlocks() = 
        let actual = splitBlocks (seq {"a"; "b"; ""; "c"; "d"; "e"; ""; "f"; "g"; "h"})
        let expected = (seq {"a"; "b"}, seq {"d"; "e"}, seq {"g"; "h"})
        Assert.AreEqual(expected, actual)

    [<Test>]
    member _.parseValidityRule() = 
        let actual = parseValidityRule ("class: 0-1 or 4-19")
        let expected = { IsDeparture = false; Ranges = seq { (0L, 1L); (4L, 19L) } }
        Assert.AreEqual(expected, actual)

    [<Test>]
    member _.``parseValidityRule sets IsDeparture to true if test contains the work departure``() = 
        let actual = parseValidityRule ("point of departure: 4-8 or 15-16 or 23-42")
        let expected = { IsDeparture = true; Ranges = seq { (4L, 8L); (15L, 16L); (23L, 42L) } }
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
            { IsDeparture = false; Ranges = seq { (1L, 3L); (5L, 7L) } };
            { IsDeparture = false; Ranges = seq { (6L, 11L); (33L, 44L) } };
            { IsDeparture = false; Ranges = seq { (13L, 40L); (45L, 50L) } }
            }

        Assert.AreEqual(expected, parseValidityRules(input))

    [<Test>]
    member this.``ErrorRate Example 0 is valid``() =
        Assert.AreEqual(0L, errorRate (seq { 7L; 1L; 14L }) this.ruleSet)

    [<Test>]
    member this.``ErrorRate Example 1 is valid``() =
        Assert.AreEqual(0L, errorRate (seq { 7L; 13L; 47L }) this.ruleSet)
        
    [<Test>]
    member this.``ErrorRate Example 2 is invalid``() =
        Assert.AreEqual(4L, errorRate (seq { 40L; 4L; 50L }) this.ruleSet)
        
    [<Test>]
    member this.``ErrorRate Example 3 is invalid``() =
        Assert.AreEqual(55L, errorRate (seq { 55L; 2L; 20L }) this.ruleSet)
        
    [<Test>]
    member this.``ErrorRate Example 4 is invalid``() =
        Assert.AreEqual(12L, errorRate (seq { 38L; 6L; 12L }) this.ruleSet)

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
        
        Assert.AreEqual(71L, sumErrors(input))

    [<Test>]
    member _.``parseValidityRule throws error if too few sections of data``() =
        let input = seq { "class: 1-3 or 5-7"; "row: 6-11 or 33-44" }
        let ex = Assert.Throws<System.Exception>(fun () -> splitBlocks(input) |> ignore)
        Assert.AreEqual("Expected three sections of input data.", ex.Message)

