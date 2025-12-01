namespace _2025.Tests

open NUnit.Framework
open _2025

[<TestFixture>]
type Day01Part1 () =

    [<Test>]
    member _.RotationLeft() =
        Assert.That(Day01Part1.rotation "L68", Is.EqualTo(-68))

    [<Test>]
    member _.RotationRight() =
        Assert.That(Day01Part1.rotation "R48", Is.EqualTo(48))

    [<Test>]
    member _.RotationLarge() =
        Assert.That(Day01Part1.rotation "R767", Is.EqualTo(67))

    [<Test>]
    member _.NewPosition() =
        Assert.That(Day01Part1.newPosition (4, 7), Is.EqualTo(11))

    [<Test>]
    member _.NewPositionLessThanZero() =
        Assert.That(Day01Part1.newPosition (2, -7), Is.EqualTo(95))

    [<Test>]
    member _.NewPositionMoreThanFlake() =
        Assert.That(Day01Part1.newPosition (99, 3), Is.EqualTo(2))

    [<Test>]
    member _.Run() =

        let input = ["L68"; "L30"; "R48"; "L5"; "R60"; "L55"; "L1"; "L99"; "R14"; "L82"]

        Assert.That(Day01Part1.run(input), Is.EqualTo(3))

    [<Test>]
    member _.RunLarge() =

        let input = ["R767"]

        Assert.That(Day01Part1.run(input), Is.EqualTo(0))