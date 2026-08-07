namespace AoC2019.Tests

open NUnit.Framework
open AoC2019

[<TestFixture>] 
type Day11Part2 () =

    [<Test>]
    member this.Example() =

        let expected = seq {
            "  #";
            "  #";
            "## " }

        let instructions = [1L;0L;0L;0L;1L;0L;1L;0L;0L;1L;1L;0L;1L;0L]
        let mutable isPaintOutput = true
        let mutable currentLocation = ((0, 0), 0)
        let mutable locationsPainted = Map.empty

        for outputValue in instructions do
            if isPaintOutput then          
                locationsPainted <- locationsPainted |> Map.add (fst currentLocation) outputValue
            else
                currentLocation <- Day11Part1.rotate(currentLocation, int outputValue)

            isPaintOutput <- not isPaintOutput

        Assert.AreEqual(expected,Day11Part2.printOutput(locationsPainted))
    
    [<Test>]
    member this.ML() =

        let expected = seq {
            "#     # #   # ";
            "##   ## ##  # ";
            "# # # # # # # ";
            "#  #  # #  ## ";
            "#     # #   # ";
            "              "  } 

        let instructions = [(1L,1) ; (0L,0) ; (0L,0) ; (1L,1) ; (1L,1) ; (0L,0) ; (0L,0) ; (1L,1) ; (1L,1) ; (0L,1) ; (1L,0) ; (0L,1) ; (1L,0) ; (0L,1) ; (1L,0) ; (0L,0) ; (1L,1) ; (0L,0) ; (1L,1) ; (0L,0) ; (1L,1)  ; (0L,1) ; (0L,1) ; (1L,0) ; (1L,1) ; (0L,0) ; (0L,0) ; (1L,1) ; (1L,0) ; (0L,1) ; (0L,0); (0L,0); (1L,1) ; (0L,0); (0L,0); (1L,1); (1L,1); (0L,0); (0L,0); (1L,1); (1L,1); (0L,1) ; (1L,0); (0L,1) ; (1L,0); (0L,1) ; (1L,0); (0L,1) ; (1L,0); (0L,0); (0L,0);(1L,1);(1L,1);(0L,0); (0L,0);(1L,1);(1L,1)]
        let mutable currentLocation = ((0, 0), 0)
        let mutable locationsPainted = Map.empty

        for instruction in instructions do
            locationsPainted <- locationsPainted |> Map.add (fst currentLocation) (fst instruction)
            currentLocation <- Day11Part1.rotate(currentLocation, snd instruction)

        Assert.AreEqual(expected,Day11Part2.printOutput(locationsPainted))
