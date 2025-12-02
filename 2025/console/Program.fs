open System.IO
open _2025

printfn "Day  1 Part 1: %i" (Day01Part1.run (File.ReadAllLines("../input/Day01/input.txt")))
printfn "Day  1 Part 2: %i" (Day01Part2.run (File.ReadAllLines("../input/Day01/input.txt")))
printfn "Day  2 Part 1: %i" (Day02Part1.run (File.ReadAllLines("../input/Day02/input.txt")).[0])
printfn "Day  2 Part 2: %i" (Day02Part2.run (File.ReadAllLines("../input/Day02/input.txt")).[0])