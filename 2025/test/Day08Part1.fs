namespace _2025.Tests

open NUnit.Framework
open _2025

[<TestFixture>] 
type Day08Part1 () =

    [<Test>]
    member _.GetDistance() =

        Assert.That(Day08Part1.getDistance(((162.0,817.0,812.0),(425.0,690.0,689.0))), Is.EqualTo(316.902).Within(0.001))

    [<Test>]
    member _.ParseLine() =

        Assert.That(Day08Part1.parseLine("162,817,812"), Is.EqualTo((162.0,817.0,812.0)))

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

        Assert.That(Day08Part1.run(input), Is.EqualTo(40))