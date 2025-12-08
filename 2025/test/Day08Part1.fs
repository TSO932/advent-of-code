namespace _2025.Tests

open NUnit.Framework
open _2025

[<TestFixture>] 
type Day08Part1 () =

    [<Test>]
    member _.GetDistance() =

        Assert.That(Day08Part1.getDistance(((162L,817L,812L),(425L,690L,689L))), Is.EqualTo(100427L))

    [<Test>]
    member _.ParseLine() =

        Assert.That(Day08Part1.parseLine("162,817,812"), Is.EqualTo((162L,817L,812L)))

    [<Test>]
    member _.BackToText() =

        Assert.That(Day08Part1.backToText((162.0,817.0,812.0)), Is.EqualTo(("162817812")))

    [<Test>]
    member _.Example() =
    
        let input = [
            "162,817,812";
            "57,618,57";
            "906,360,560";
            "592,479,940";
            "352,342,300";
            "466,668,158";
            "542,29,236";
            "431,825,988";
            "739,650,466";
            "52,470,668";
            "216,146,977";
            "819,987,18";
            "117,168,530";
            "805,96,715";
            "346,949,466";
            "970,615,88";
            "941,993,340";
            "862,61,35";
            "984,92,344";
            "425,690,689"
            ]

        Assert.That(Day08Part1.runCount(input, 10), Is.EqualTo(40))

    [<Test>]
    member _.GroupThat() =
    
        let input = [
            ("425690689", "162817812");
            ("431825988", "162817812");
            ("80596715", "906360560");
            ("425690689", "431825988");
            ("98492344", "8626135");
            ("117168530", "52470668");
            ("941993340", "81998718");
            ("739650466", "906360560");
            ("425690689", "346949466");
            ("98492344", "906360560")
            ]

        Assert.That(Day08Part1.getGroups(input), Is.EqualTo(40))
       
       
        