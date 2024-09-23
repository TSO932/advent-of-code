namespace _2023.Tests

open System
open NUnit.Framework
open _2023

[<TestFixture>]
type Day18Part1 () =

    [<Test>]
    member _.DigRight() = 
        let expected = [|(1, 1, "paint it black"); (2, 1, "70c710"); (3, 1, "70c710"); (4, 1, "70c710")|]
        Assert.AreEqual(expected, Day18Part1.dig([|(1, 1, "paint it black")|], 'R', 3, "70c710"))

    [<Test>]
    member _.DigUp() = 
        let input = [|(3, 1, "70c710"); (4, 1, "70c710")|]
        let expected = [|(3, 1, "70c710"); (4, 1, "70c710"); (4, 2, "0dc571"); (4, 3, "0dc571")|]
        Assert.AreEqual(expected, Day18Part1.dig(input, 'U', 2, "0dc571"))

    [<Test>]
    member _.Parse() = 
        Assert.AreEqual(('R', 6, "70c710"), Day18Part1.parse("R 6 (#70c710)"))

    [<Test>]
    member _.GetPath() =
        let input = seq { "R 6 (#70c710)"; "D 5 (#0dc571)"; "L 2 (#5713f0)"; "D 2 (#d2c081)"; "R 2 (#59c680)"; "D 2 (#411b91)"; "L 5 (#8ceee2)"; "U 2 (#caa173)"; "L 1 (#1b58a2)"; "U 2 (#caa171)"; "R 2 (#7807d2)"; "U 3 (#a77fa3)"; "L 2 (#015232)"; "U 2 (#7a21e3)"}
        let actual = Day18Part1.getPath(input)
        Assert.AreEqual(39, Seq.length actual, "count")
        Assert.AreEqual((0, 0, String.Empty), Seq.head actual, "first")
        Assert.AreEqual((0, 0, "7a21e3"), actual |> Seq.rev |> Seq.head, "last")

        Assert.AreEqual(6, actual |> Seq.map (fun (x, _, _) -> x) |> Seq.max, "x max")
        Assert.AreEqual(0, actual |> Seq.map (fun (x, _, _) -> x) |> Seq.min, "x min")
        Assert.AreEqual(0, actual |> Seq.map (fun (_, y, _) -> y) |> Seq.max, "y max")
        Assert.AreEqual(-9, actual |> Seq.map (fun (_, y, _) -> y) |> Seq.min, "y min")


    [<Test>]
    member _.getArea() =
        let input = seq { "R 6 (#70c710)"; "D 5 (#0dc571)"; "L 2 (#5713f0)"; "D 2 (#d2c081)"; "R 2 (#59c680)"; "D 2 (#411b91)"; "L 5 (#8ceee2)"; "U 2 (#caa173)"; "L 1 (#1b58a2)"; "U 2 (#caa171)"; "R 2 (#7807d2)"; "U 3 (#a77fa3)"; "L 2 (#015232)"; "U 2 (#7a21e3)"}
        Assert.AreEqual(62, Day18Part1.getArea(input))


// 22870 too low
// 39147 too high
