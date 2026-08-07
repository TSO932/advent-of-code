open AoC
open AoC2019

let readInput day = AoC.Input.readLines 2019 day

[<EntryPoint>]
let main argv =

    let getInputLine day = (readInput day).[0]

    printfn "Day  1 Part 1: %i" (Day01Part1.sumFuel (readInput 1))
    printfn "Day  1 Part 2: %i" (Day01Part2.sumFuel (readInput 1))

    printfn "Day  2 Part 1: %i" (Day02Part1.getFirstIntCode (getInputLine 2))
    printfn "Day  2 Part 2: %i" (Day02Part2.runProgram (getInputLine 2))

    let input03 = readInput 3
    printfn "Day  3 Part 1: %i" (Day03Part1.getIntersection (input03.[0], input03.[1]))
    printfn "Day  3 Part 2: %i" (Day03Part2.getIntersection (input03.[0], input03.[1]))

    printfn "Day  4 Part 1: %i" (Day04Part1.runProgram (getInputLine 4))
    printfn "Day  4 Part 2: %i" (Day04Part2.runProgram (getInputLine 4))

    printfn "Day  5 Part 1: %i" (Day05Part1.runProgram (getInputLine 5, 1))
    printfn "Day  5 Part 2: %i" (Day05Part2.runProgram (getInputLine 5, 5))

    printfn "Day  6 Part 1: %i" (Day06Part1.getTotalOrbitCount (readInput 6))
    printfn "Day  6 Part 2: %i" (Day06Part2.getShortestTransfer (readInput 6))

    printfn "Day  7 Part 1: %i" (Day07Part1.findHighestSignal (getInputLine 7))
    printfn "Day  7 Part 2: %i" (Day07Part2.findHighestSignal (getInputLine 7))

    printfn "Day  8 Part 1: %i" (Day08Part1.runProgram (getInputLine 8))
    printfn "Day  8 Part 2:"
    Day08Part2.runProgram (getInputLine 8) |> Seq.iter (fun s -> printfn "%s" s)

    printfn "Day  9 Part 1: %i" (Day09Part1.runProgram (getInputLine 9, [|1L|]))
    printfn "Day  9 Part 2: %i" (Day09Part1.runProgram (getInputLine 9, [|2L|]))

    let asteroid = Day10Part1.findBestAsteroid (readInput 10)
    printfn "Day 10 Part 1: %i" (snd asteroid)
    printfn "Day 10 Part 2: %i" (Day10Part2.vaporise (readInput 10, fst asteroid))

    printfn "Day 11 Part 1: %i" (Day11Part2.runProgram1 (getInputLine 11))
    printfn "Day 11 Part 2:"
    Day11Part2.runProgram2 (getInputLine 11) |> Seq.iter (fun s -> printfn "%s" s)

    printfn "Day 12 Part 1: %i" (Day12Part1.runSimulation (Day12Part1.readCoordinates (readInput 12), 1000))
    printfn "Day 12 Part 2: %A" (Day12Part2.runSimulationThrice (Day12Part1.readCoordinates (readInput 12)))

    printfn "Day 13 Part 1: %i" (Day13Part1.runProgram (getInputLine 13))
    printfn "Day 13 Part 2: %i" (Day13Part2.runProgram (getInputLine 13))

    printfn "Day 14 Part 1: %i" (Day14Part1.tcaer("FUEL", 1, Day14Part1.getProductDic(readInput 14), true))
    printfn "Day 14 Part 2: %i" (Day14Part2.findOneTrillion(readInput 14))

    0 // return an integer exit code

