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
    member this.IsAccessibleFalse() =
        Assert.That(Day04Part1.isAccessible(this.inputGrid, 2, 2), Is.EqualTo(false))

    [<Test>]
    member this.IsAccessibleTrue() =
          Assert.That(Day04Part1.isAccessible(this.inputGrid, 1, 1), Is.EqualTo(true))

    [<Test>]
    member this.IsAccessibleEdge() =
        Assert.That(Day04Part1.isAccessible(this.inputGrid, 3, 3), Is.EqualTo(true))

    [<Test>]
    member this.IsAccessibleNotAtSymbol() =
        Assert.That(Day04Part1.isAccessible(this.inputGrid, 0, 0), Is.EqualTo(false))

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
