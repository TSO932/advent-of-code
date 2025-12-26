namespace _2025.Tests

open NUnit.Framework
open _2025

[<TestFixture>] 
type Day10Part2 () =

    [<Test>]
    member _.parseLine1() =
    
        let input = "[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}"

        Assert.That(Day10Part2.parseLine(input), Is.EqualTo(10))

       
    [<Test>]
    member _.parseLine2() =
    
        let input = "[...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}"

        Assert.That(Day10Part2.parseLine(input), Is.EqualTo(12))

    [<Test>]
    member _.parseLine3() =
    
        let input = "[.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}"

        Assert.That(Day10Part2.parseLine(input), Is.EqualTo(11))

    [<Test>]
    member _.Example() =
    
        let input = [
            "[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}";
            "[...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}";
            "[.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}"
            ]

        Assert.That(Day10Part2.run(input), Is.EqualTo(33))


    [<Test>]
    member _.GetParity() =
        Assert.That(Day10Part2.getParities("3547"), Is.EqualTo([|true; true; false; true|]))

    [<Test>]
    member _.parseLine2_1() =
    
        let input = "[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}"

        Assert.That(Day10Part2.parseLine2(input), Is.EqualTo(10))