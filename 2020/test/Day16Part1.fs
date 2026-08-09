namespace AoC2020.Tests

open NUnit.Framework
open AoC2020

[<TestFixture>] 
type Day16Part1 () =

    [<Test>]
    member this.splitBlocks() = 
        let actual = Day16Part1.splitBlocks (seq {"a"; "b"; ""; "c"; "d"; "e"; ""; "f"; "g"; "h"})
        let expected = (seq {"b"}, seq {"d"; "e"}, seq {"g"; "h"})
        Assert.AreEqual(expected, actual)

    [<Test>]
    member this.parseValidityRule() = 
        let actual = Day16Part1.parseValidityRule ("class: 0-1 or 4-19")
        let expected = ( false, seq { (0, 1); (4, 19) } )
        Assert.AreEqual(expected, actual)

    [<Test>]
    member this.parseValidityRuleWithDeparture() = 
        let actual = Day16Part1.parseValidityRule ("point of departure: 4-8 or 15-16 or 23-42")
        let expected = ( true, seq { (4, 8); (15, 16); (23, 42) } )
        Assert.AreEqual(expected, actual)

    [<Test>]
    member this.parseValidityRules() =

        let input = seq {
            "class: 0-1 or 4-19";
            "row: 0-5 or 8-19";
            "seat: 0-13 or 16-19"
            }

        let expected = seq {
            (false, seq { (0, 1); (4, 19) });
            (false, seq { (0, 5); (8, 19) });
            (false, seq { (0, 13); (16, 19) });
            }

        Assert.AreEqual(expected, Day16Part1.parseValidityRules(input))

    [<Test>]
    member this.parseMyTicket() =
        let input = seq { "7,1,14" }
        let expected = seq { 7; 1; 14 }
        Assert.AreEqual(expected, Day16Part1.parseMyTicket(input))

