open AoC
open _2025

let readInput day = AoC.Input.readLines 2025 day
let readInputLine day = (readInput day)[0]

printfn "Day  1 Part 1: %i" (Day01Part1.run (readInput 1))
printfn "Day  1 Part 2: %i" (Day01Part2.run (readInput 1))
printfn "Day  2 Part 1: %i" (Day02Part1.run (readInputLine 2))
printfn "Day  2 Part 2: %i" (Day02Part2.run (readInputLine 2))
printfn "Day  3 Part 1: %i" (Day03Part1.run (readInput 3))
printfn "Day  3 Part 2: %i" (Day03Part2.run (readInput 3))
printfn "Day  4 Part 1: %i" (Day04Part1.run (readInput 4))
printfn "Day  4 Part 2: %i" (Day04Part2.run (readInput 4))
printfn "Day  5 Part 1: %i" (Day05Part1.run (readInput 5))
printfn "Day  5 Part 2: %i" (Day05Part2.run (readInput 5))
printfn "Day  6 Part 1: %i" (Day06Part1.run (readInput 6))
printfn "Day  6 Part 2: %i" (Day06Part2.run (readInput 6))
printfn "Day  7 Part 1: %i" (Day07Part1.run (readInput 7))
printfn "Day  7 Part 2: %i" (Day07Part2.run (readInput 7))
printfn "Day  8 Part 1: %i" (Day08Part1.run (readInput 8))
printfn "Day  8 Part 2: %i" (Day08Part2.run (readInput 8))
printfn "Day  9 Part 1: %i" (Day09Part1.run (readInput 9))
printfn "Day  9 Part 2: %i" (Day09Part2.run (readInput 9))
printfn "Day 10 Part 1: %i" (Day10Part1.run (readInput 10))
printfn "Day 10 Part 2: %i" (Day10Part2.run (readInput 10))
printfn "Day 11 Part 1: %i" (Day11Part1.run (readInput 11))
printfn "Day 11 Part 2: %i" (Day11Part2.run (readInput 11))
printfn "Day 12 Part 1: %i" (Day12Part1.run (readInput 12))