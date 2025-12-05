namespace _2025.Tests

open NUnit.Framework
open _2025

[<TestFixture>] 
type Day05Part2 () =

    [<Test>]
    member _.Example() =
    
        let input = [
            "3-5";
            "10-14";
            "16-20";
            "12-18";
            "";
            "1";
            "5";
            "8";
            "11";
            "17";
            "32"
            ]

        Assert.That(Day05Part2.run(input), Is.EqualTo(14))

    [<Test>]
    member _.isContiguousAspaceB() =
            Assert.That(Day05Part2.isContiguous([|100L; 150L|], [|200L; 250L|]), Is.EqualTo(false))

    [<Test>]
    member _.isContiguousBspaceA() =
            Assert.That(Day05Part2.isContiguous([|100L; 150L|], [|20L; 25L|]), Is.EqualTo(false))

    [<Test>]
    member _.isContiguousAtouchingB() =
            Assert.That(Day05Part2.isContiguous([|100L; 150L|], [|150L; 200L|]), Is.EqualTo(true))

    [<Test>]
    member _.isContiguousBtouchingA() =
            Assert.That(Day05Part2.isContiguous([|200L; 1500L|], [|150L; 200L|]), Is.EqualTo(true))

    [<Test>]
    member _.isContiguousAinB() =
            Assert.That(Day05Part2.isContiguous([|55L; 66L|], [|44L; 77L|]), Is.EqualTo(true))

    [<Test>]
    member _.isContiguousBinA() =
            Assert.That(Day05Part2.isContiguous([|55L; 66L|], [|60L; 65L|]), Is.EqualTo(true))

    [<Test>]
    member _.isContiguoussame() =
            Assert.That(Day05Part2.isContiguous([|99L; 123L|], [|99L; 123L|]), Is.EqualTo(true))

    [<Test>]
    member _.isContiguousAB() =
            Assert.That(Day05Part2.isContiguous([|99L; 123L|], [|101L; 200L|]), Is.EqualTo(true))

    [<Test>]
    member _.isContiguousBA() =
            Assert.That(Day05Part2.isContiguous([|150L; 1234L|], [|101L; 200L|]), Is.EqualTo(true))
