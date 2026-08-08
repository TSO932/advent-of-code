open AoC.Input
open _2024

let readInput day = AoC.Input.readLines 2024 day
let readInputLine day = (readInput day)[0]

printfn "Day  1 Part 1: %i" (Day01Part1.run (readInput 1))
printfn "Day  1 Part 2: %i" (Day01Part2.run (readInput 1))
printfn "Day  2 Part 1: %i" (Day02Part1.run (readInput 2))
printfn "Day  2 Part 2: %i" (Day02Part2.run (readInput 2))
printfn "Day  3 Part 1: %i" (Day03Part1.run (readInput 3))
//printfn "Day  3 Part 2: %i" (Day03Part2.run (readInput 3))
printfn "Day  4 Part 1: %i" (Day04Part1.run (readInput 4))
printfn "Day  4 Part 2: %i" (Day04Part2.run (readInput 4))
printfn "Day  5 Part 1: %i" (Day05Part1.run (readInput 5))
printfn "Day  7 Part 1: %i" (Day07Part1.run (readInput 7))
// printfn "Day  7 Part 2: %i" (Day07Part2.run (readInput 7))
printfn "Day  9 Part 1: %i" (Day09Part1.run (readInputLine 9))
printfn "Day  9 Part 2: %i" (Day09Part2.run (readInputLine 9))
printfn "Day 11 Part 1: %i" (Day11Part1.run (readInputLine 11))
printfn "Day 11 Part 2: %i" (Day11Part2.run (readInputLine 11))
printfn "Day 14 Part 1: %i" (Day14Part1.run (readInput 14))
printfn "Day 14 Part 2: %i" (Day14Part2.run (readInput 14))