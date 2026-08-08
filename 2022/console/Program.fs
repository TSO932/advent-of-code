open AoC.Input
open AoC2022

[<EntryPoint>]
let main argv =

    let readInput day = AoC.Input.readLines 2022 day
    let readInputLine day = (readInput day)[0]

    printfn "Day  1 Part 1: %A" (Day01Part1.FindElfCarryingMostCalories (readInput 1))
    printfn "Day  1 Part 2: %A" (Day01Part2.FindElvesCarryingMostCalories (readInput 1))
    printfn "Day  2 Part 1: %A" (Day02Part1.GetTotal (readInput 2))
    printfn "Day  2 Part 2: %A" (Day02Part2.GetTotal (readInput 2))
    printfn "Day  3 Part 1: %A" (Day03Part1.GetSumOfPriorities (readInput 3))
    printfn "Day  3 Part 2: %A" (Day03Part2.GetSumOfPriorities (readInput 3))
    printfn "Day  4 Part 1: %A" (Day04Part1.GetNumberOfPairsWhereOneRangeFullyContainsTheOther (readInput 4))
    printfn "Day  6 Part 1: %A" (Day06Part1.FindPosition (readInputLine 6))
    printfn "Day  6 Part 2: %A" (Day06Part2.FindPosition (readInputLine 6))
    printfn "Day  7 Part 1: %A" (Day07Part1.runProgram (readInput 7))
    printfn "Day  7 Part 2: %A" (Day07Part2.runProgram (readInput 7))
    printfn "Day  8 Part 1: %A" (Day08Part1.countVisibleTrees (readInput 8))
    printfn "Day  8 Part 2: %A" (Day08Part2.getMostScenicScore (readInput 8))

    0 // return an integer exit code 