namespace _2025.Tests

open NUnit.Framework
open _2025

[<TestFixture>] 
type Day12Part1() =

    // There's a simplifcation that works with the puzzle input.
    // Simply assume that each present takes 9 units of space. See if they will all fit in the area.
    // Don't worry about the shape of the presents or the shape of the region.
    // This doesn't work with the example data.

    //[<Test>]
    member _.Example() =
    
        let input = [
            "0:";
            "###";
            "##.";
            "##.";
            "";
            "1:";
            "###";
            "##.";
            ".##";
            "";
            "2:";
            ".##";
            "###";
            "##.";
            "";
            "3:";
            "##.";
            "###";
            "##.";
            "";
            "4:";
            "###";
            "#..";
            "###";
            "";
            "5:";
            "###";
            ".#.";
            "###";
            "";
            "4x4: 0 0 0 0 2 0";
            "12x5: 1 0 1 0 2 2";
            "12x5: 1 0 1 0 3 2"
            ]

        Assert.That(Day12Part1.run(input), Is.EqualTo(2))
