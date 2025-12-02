namespace _2025.Tests

open NUnit.Framework
open _2025

[<TestFixture>]
type Day02Part2 () =

  
    [<Test>]
    member _.IsValidisInvalidTrue() =
        Assert.That(Day02Part2.isInvalid 11L, Is.EqualTo(true))

    [<Test>]
    member _.IsValidisInvalidFalse() =
        Assert.That(Day02Part2.isInvalid 12L, Is.EqualTo(false))

    [<Test>]
    member _.IsValidisInvalidBigTrue() =
        Assert.That(Day02Part2.isInvalid 38593859L, Is.EqualTo(true))

    [<Test>]
    member _.IsValidisInvalidBigFalse() =
        Assert.That(Day02Part2.isInvalid 38593862L, Is.EqualTo(false))

    [<Test>]
    member _.IsValidisInvalidOddDigitsTrue() =
        Assert.That(Day02Part2.isInvalid 333L, Is.EqualTo(true))

    [<Test>]
    member _.IsValidisInvalidOneTwoCheckOneTwoTrue() =
        Assert.That(Day02Part2.isInvalid 2121212121L, Is.EqualTo(true))

    [<Test>]
    member _.Run() =
        let input = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124"
        Assert.That(Day02Part2.run input, Is.EqualTo(4174379265L))