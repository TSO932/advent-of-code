namespace _2025.Tests

open NUnit.Framework
open _2025

[<TestFixture>]
type Day03Part1 () =

    [<Test>]
    member _.GetFirstDigitExample1() =
        Assert.That(Day03Part1.getFirstDigit "987654321111111", Is.EqualTo('9'))

    [<Test>]
    member _.GetFirstDigitExample2() =
        Assert.That(Day03Part1.getFirstDigit "811111111111119", Is.EqualTo('8'))

    [<Test>]
    member _.GetFirstDigitExample3() =
        Assert.That(Day03Part1.getFirstDigit "234234234234278", Is.EqualTo('7'))

    [<Test>]
    member _.GetFirstDigitExample4() =
        Assert.That(Day03Part1.getFirstDigit "818181911112111", Is.EqualTo('9'))

    [<Test>]
    member _.getSecondDigitExample1() =
        Assert.That(Day03Part1.getSecondDigit ("987654321111111", '9'), Is.EqualTo('8'))

    [<Test>]
    member _.getSecondDigitExample2() =
        Assert.That(Day03Part1.getSecondDigit ("811111111111119", '8'), Is.EqualTo('9'))

    [<Test>]
    member _.getSecondDigitExample3() =
        Assert.That(Day03Part1.getSecondDigit ("234234234234278", '7'), Is.EqualTo('8'))

    [<Test>]
    member _.getSecondDigitExample4() =
        Assert.That(Day03Part1.getSecondDigit ("818181911112111", '9'), Is.EqualTo('2'))

    [<Test>]
    member _.Example1() =
        Assert.That(Day03Part1.getJoltage "987654321111111", Is.EqualTo(98))

    [<Test>]
    member _.Example2() =
        Assert.That(Day03Part1.getJoltage "811111111111119", Is.EqualTo(89))

    [<Test>]
    member _.Example3() =
        Assert.That(Day03Part1.getJoltage "234234234234278", Is.EqualTo(78))

    [<Test>]
    member _.Example4() =
        Assert.That(Day03Part1.getJoltage "818181911112111", Is.EqualTo(92))

    [<Test>]
    member _.Example() =
        let input = [| "987654321111111"; "811111111111119"; "234234234234278"; "818181911112111" |]
        Assert.That(Day03Part1.run input, Is.EqualTo(357))

        

