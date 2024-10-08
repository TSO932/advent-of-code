﻿open System.IO
open AoC2017

[<EntryPoint>]
let main argv =

    printfn "Day  1 Part 1: %i" (Day01Part1.solveCaptha (File.ReadAllLines("../input/Day01/input.txt")[0]))
    printfn "Day  1 Part 2: %i" (Day01Part2.solveCaptha (File.ReadAllLines("../input/Day01/input.txt")[0]))
    printfn "Day  2 Part 1: %i" (Day02Part1.checkSum (File.ReadAllLines("../input/Day02/input.txt")))
    printfn "Day  2 Part 2: %i" (Day02Part2.getSum (File.ReadAllLines("../input/Day02/input.txt")))
    printfn "Day  3 Part 1: %i" (Day03Part1.getDistance (File.ReadAllLines("../input/Day03/input.txt")))
    printfn "Day  3 Part 2: %i" (Day03Part2.getValue (File.ReadAllLines("../input/Day03/input.txt")))
    printfn "Day  4 Part 1: %i" (Day04Part1.countValidPasswords (File.ReadAllLines("../input/Day04/input.txt")))
    printfn "Day  4 Part 2: %i" (Day04Part2.countValidPasswords (File.ReadAllLines("../input/Day04/input.txt")))
    printfn "Day  5 Part 1: %i" (Day05Part1.escapeMaze (File.ReadAllLines("../input/Day05/input.txt")))
    printfn "Day  5 Part 2: %i" (Day05Part2.escapeMaze (File.ReadAllLines("../input/Day05/input.txt")))
    printfn "Day  6 Part 1: %i" (Day06Part1.getAnswer (File.ReadAllLines("../input/Day06/input.txt")))
    printfn "Day  6 Part 2: %i" (Day06Part2.getAnswer (File.ReadAllLines("../input/Day06/input.txt")))
    printfn "Day  7 Part 1: %s" (Day07Part1.getBase (File.ReadAllLines("../input/Day07/input.txt")))

    0 // return an integer exit code 