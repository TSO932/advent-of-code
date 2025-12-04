namespace _2025.Tests

open NUnit.Framework
open _2025

[<TestFixture>] 
type Day04Part1 () =

    [<DefaultValue>]
    val mutable inputGrid:char[,]

    [<SetUp>]
    member this.SetUp() =
        this.inputGrid <- array2D [
            ['.';'.';'@';'.';];
            ['@';'@';'.';'@';];
            ['.';'@';'.';'.';];
            ['@';'@';'@';'@';]
            ]
        
    [<Test>]
    member this.IsAccessableFalse() =
        Assert.That(Day04Part1.isAccessable(this.inputGrid, 2, 2), Is.EqualTo(false))

    [<Test>]
    member this.IsAccessableTrue() =
          Assert.That(Day04Part1.isAccessable(this.inputGrid, 1, 1), Is.EqualTo(true))

    [<Test>]
    member this.IsAccessableEdge() =
        Assert.That(Day04Part1.isAccessable(this.inputGrid, 3, 3), Is.EqualTo(true))

    [<Test>]
    member this.IsAccessableNotAtSymbol() =
        Assert.That(Day04Part1.isAccessable(this.inputGrid, 0, 0), Is.EqualTo(false))

    [<Test>]
    member _.Example() =
    
        let input = [
            "..@@.@@@@.";
            "@@@.@.@.@@";
            "@@@@@.@.@@";
            "@.@@@@..@.";
            "@@.@@@@.@@";
            ".@@@@@@@.@";
            ".@.@.@.@@@";
            "@.@@@.@@@@";
            ".@@@@@@@@.";
            "@.@.@@@.@."            
            ]

        Assert.That(Day04Part1.run(input), Is.EqualTo(13))
