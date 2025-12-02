namespace _2025.Tests

open NUnit.Framework
open _2025

[<TestFixture>]
type Day02Part1 () =

    [<Test>]
    member _.ParseLine() =
        Assert.That(Day02Part1.parseLine "11-22,95-115,998-1012,1188511880-1188511890", Is.EqualTo([[11L;22L];[95L;115L];[998L;1012L];[1188511880L;1188511890L]]))

    [<Test>]
    member _.ExpandRange() =
        Assert.That(Day02Part1.expandRange [11L;22L], Is.EqualTo([11L;12L;13L;14L;15L;16L;17L;18L;19L;20L;21L;22L]))
    
    [<Test>]
    member _.IsValidisInvalidTrue() =
        Assert.That(Day02Part1.isInvalid 11L, Is.EqualTo(true))

    [<Test>]
    member _.IsValidisInvalidFalse() =
        Assert.That(Day02Part1.isInvalid 12L, Is.EqualTo(false))

    [<Test>]
    member _.IsValidisInvalidBigTrue() =
        Assert.That(Day02Part1.isInvalid 38593859L, Is.EqualTo(true))

    [<Test>]
    member _.IsValidisInvalidBigFalse() =
        Assert.That(Day02Part1.isInvalid 38593862L, Is.EqualTo(false))

    [<Test>]
    member _.IsValidisInvalidOddDigitsFalse() =
        Assert.That(Day02Part1.isInvalid 333L, Is.EqualTo(false))

    [<Test>]
    member _.Run() =
        let input = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124"
        Assert.That(Day02Part1.run input, Is.EqualTo(1227775554L))