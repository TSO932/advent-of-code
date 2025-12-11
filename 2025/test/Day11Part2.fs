namespace _2025.Tests

open NUnit.Framework
open _2025

[<TestFixture>] 
type Day11Part2() =

    [<Test>]
    member _.Example() =
    
        let input = [
            "svr: aaa bbb";
            "aaa: fft";
            "fft: ccc";
            "bbb: tty";
            "tty: ccc";
            "ccc: ddd eee";
            "ddd: hub";
            "hub: fff";
            "eee: dac";
            "dac: fff";
            "fff: ggg hhh";
            "ggg: out";
            "hhh: out"
            ]

        Assert.That(Day11Part2.run(input), Is.EqualTo(2))
