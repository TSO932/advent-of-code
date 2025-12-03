namespace _2025.Tests

open NUnit.Framework
open _2025

[<TestFixture>]
type Day03Part2 () =

    [<Test>]
    member _.GetFirstDigitExample1() =
        Assert.That(Day03Part2.getNextDigit ("987654321111111", 0, 2), Is.EqualTo(("87654321111111", 9, 1)))

    [<Test>]
    member _.GetFirstDigitExample2() =
        Assert.That(Day03Part2.getNextDigit ("811111111111119", 0, 2), Is.EqualTo(("11111111111119", 8, 1)))

    [<Test>]
    member _.GetFirstDigitExample3() =
        Assert.That(Day03Part2.getNextDigit ("234234234234278", 0, 2), Is.EqualTo(("8", 7, 1)))

    [<Test>]
    member _.GetFirstDigitExample4() =
        Assert.That(Day03Part2.getNextDigit ("818181911112111", 0, 2), Is.EqualTo(("11112111", 9, 1)))

    [<Test>]
    member _.Example1() =
        Assert.That(Day03Part2.getJoltage ("987654321111111"), Is.EqualTo(987654321111L))

    [<Test>]
    member _.Example2() =
        Assert.That(Day03Part2.getJoltage ("811111111111119"), Is.EqualTo(811111111119L))

    [<Test>]
    member _.Example3() =
        Assert.That(Day03Part2.getJoltage ("234234234234278"), Is.EqualTo(434234234278L))

    [<Test>]
    member _.Example4() =
        Assert.That(Day03Part2.getJoltage ("818181911112111"), Is.EqualTo(888911112111L))

    [<Test>]
    member _.Example() =
        let input = [| "987654321111111"; "811111111111119"; "234234234234278"; "818181911112111" |]
        Assert.That(Day03Part2.run input, Is.EqualTo(3121910778619L))

        

