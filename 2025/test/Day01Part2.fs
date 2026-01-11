namespace _2025.Tests

open NUnit.Framework
open _2025

[<TestFixture>]
type Day01Part2 () =

    [<Test>]
    member _.RotationLeft() =
        Assert.That(Day01Part2.rotation "L68", Is.EqualTo((0, -68)))

    [<Test>]
    member _.RotationRight() =
        Assert.That(Day01Part2.rotation "R48", Is.EqualTo((0, 48)))

    [<Test>]
    member _.RotationLarge() =
        Assert.That(Day01Part2.rotation "R767", Is.EqualTo((7, 67)))

    [<Test>]
    member _.NewPosition() =
        Assert.That(Day01Part2.newPosition (4, 7), Is.EqualTo((0, 11)))

    [<Test>]
    member _.NewPositionLessThanZero() =
        Assert.That(Day01Part2.newPosition (2, -7), Is.EqualTo((1, 95)))

    [<Test>]
    member _.NewPositionMoreThanFlake() =
        Assert.That(Day01Part2.newPosition (99, 3), Is.EqualTo((1, 2)))

    [<Test>]
    member _.Run() =

        let input = ["L68"; "L30"; "R48"; "L5"; "R60"; "L55"; "L1"; "L99"; "R14"; "L82"]

        Assert.That(Day01Part2.run(input), Is.EqualTo(6))

    [<Test>]
    member _.RunLarge() =

        let input = ["R767"]

        Assert.That(Day01Part2.run(input), Is.EqualTo(8))