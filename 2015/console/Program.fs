open System.IO
open AoC2015

[<EntryPoint>]
let main argv =

    // printfn "Day  1 Part 1: %i" (Day01Part1.getFloor (File.ReadAllLines("../input/Day01/input.txt")))
    // printfn "Day  1 Part 2: %i" (Day01Part2.getFirstStepIntoBasement (File.ReadAllLines("../input/Day01/input.txt")))
    // printfn "Day  2 Part 1: %i" (Day02Part1.getTotalArea (File.ReadAllLines("../input/Day02/input.txt")))
    // printfn "Day  2 Part 1: %i" (Day02Part2.getTotalLength (File.ReadAllLines("../input/Day02/input.txt")))
    // printfn "Day  3 Part 1: %i" (Day03Part1.countLuckyHouses (File.ReadAllLines("../input/Day03/input.txt")))
    // printfn "Day  3 Part 2: %i" (Day03Part2.countLuckyHouses (File.ReadAllLines("../input/Day03/input.txt")))
    // printfn "Day  4 Part 1: %i" (Day04Part1.getAdventCoin (File.ReadAllLines("../input/Day04/input.txt")))
    // printfn "Day  4 Part 2: %i" (Day04Part2.getAdventCoin (File.ReadAllLines("../input/Day04/input.txt")))
    // printfn "Day  5 Part 1: %i" (Day05Part1.countNiceStrings (File.ReadAllLines("../input/Day05/input.txt")))
    // printfn "Day  5 Part 2: %i" (Day05Part2.countNiceStrings (File.ReadAllLines("../input/Day05/input.txt")))
    // printfn "Day  6 Part 1: %i" (Day06Part1.followInstructions (File.ReadAllLines("../input/Day06/input.txt")))
    // printfn "Day  6 Part 2: %i" (Day06Part2.followInstructions (File.ReadAllLines("../input/Day06/input.txt")))
    // printfn "Day  7 Part 1: %i" (Day07Part1.getSignalValueA (File.ReadAllLines("../input/Day07/input.txt")))
    // printfn "Day  7 Part 2: %i" (Day07Part2.getSignalValueA (File.ReadAllLines("../input/Day07/input.txt")))
    // // printfn "Day  7 Part 1: %i" (Day07Part1.getSignalValueA (File.ReadAllLines("../Code/aoC/2015/input/Day07/input.txt")))
    // printfn "Day  8 Part 1: %i" (Day08Part1.countCharacters (File.ReadAllLines("../input/Day08/input.txt")))
    // printfn "Day  8 Part 2: %i" (Day08Part2.countCharacters (File.ReadAllLines("../input/Day08/input.txt")))
    // printfn "Day  9 Part 1: %i" (Day09Part1.findShortestDistance (File.ReadAllLines("../input/Day09/input.txt")))
    // printfn "Day  9 Part 2: %i" (Day09Part2.findLongestDistance (File.ReadAllLines("../input/Day09/input.txt")))
    // printfn "Day 10 Part 1: %i" (Day10Part2.lookAndSayRepeat (40, File.ReadAllLines("../input/Day10/input.txt").[0]))
    // // printfn "Day 10 Part 1 Elapsed Milliseconds: %f " (PerformanceMeasure.measurePerformance(Day10Part1.lookAndSayRepeat, (25, File.ReadAllLines("../input/Day10/input.txt").[0])))
    // printfn "Day 10 Part 2: %i" (Day10Part2.lookAndSayRepeat (50, File.ReadAllLines("../input/Day10/input.txt").[0]))
    // printfn "Day 11 Part 1: %s" (Day11Part1.getNextPassword (File.ReadAllLines("../input/Day11/input.txt").[0]))
    // printfn "Day 11 Part 2: %s" (Day11Part2.getNextPassword (File.ReadAllLines("../input/Day11/input.txt").[0]))
    // printfn "Day 12 Part 1: %i" (Day12Part1.sumNumbers (File.ReadAllLines("../input/Day12/input.txt").[0]))
    // printfn "Day 12 Part 2: %i" (Day12Part2.sumNumbers (File.ReadAllLines("../input/Day12/input.txt").[0]))
    // printfn "Day 13 Part 1: %i" (Day13Part1.findHappiestSeatingPlan (File.ReadAllLines("../input/Day13/input.txt")))
    // printfn "Day 13 Part 2: %i" (Day13Part2.findHappiestSeatingPlan (File.ReadAllLines("../input/Day13/input.txt")))
    // printfn "Day 14 Part 1: %i" (Day14Part1.getWinningDistance (File.ReadAllLines("../input/Day14/input.txt")))
    // printfn "Day 14 Part 2: %i" (Day14Part2.getWinningScore (File.ReadAllLines("../input/Day14/input.txt")))
    // printfn "Day 15 Part 1: %i" (Day15Part1.getTotalScore ())
    // printfn "Day 15 Part 2: %i" (Day15Part2.getTotalScore ())
    // printfn "Day 16 Part 1: %i" (Day16Part1.findAuntSue (File.ReadAllLines("../input/Day16/input.txt")))
    // printfn "Day 16 Part 2: %i" (Day16Part2.findAuntSue (File.ReadAllLines("../input/Day16/input.txt")))
    // printfn "Day 17 Part 1: %i" (Day17Part1.countCombinationsOfContainers (File.ReadAllLines("../input/Day17/input.txt")))
    // printfn "Day 17 Part 2: %i" (Day17Part2.countCombinationsOfContainers (File.ReadAllLines("../input/Day17/input.txt")))
    // printfn "Day 18 Part 1: %i" (Day18Part1.countLights (File.ReadAllLines("../input/Day18/input.txt")))
    // printfn "Day 18 Part 2: %i" (Day18Part2.countLights (File.ReadAllLines("../input/Day18/input.txt")))
    // printfn "Day 19 Part 1: %i" (Day19Part1.countDistinctMolecules (File.ReadAllLines("../input/Day19/input.txt")))
    // //printfn "Day 19 Part 2: %i" (Day19Part2.countFewestReactionSteps (File.ReadAllLines("../input/Day19/input.txt")))
    // //printfn "Day 19 Part 1 Elapsed Milliseconds: %f " (PerformanceMeasure.measurePerformance(Day19Part2.countFewestReactionSteps, (File.ReadAllLines("../input/Day19/input.txt"))))

    // // printfn "Day 20 Part 1: %i" (Day20Part1.getFirstHouse(File.ReadAllLines("../input/Day20/input.txt").[0]))
    // // printfn "Day 20 Part 2: %i" (Day20Part2.getFirstHouse(File.ReadAllLines("../input/Day20/input.txt").[0]))
    
    // printfn "Day 21 Part 1: %i" (Day21Part1.findCheapestWinningOption())
    // printfn "Day 21 Part 2: %i" (Day21Part2.findDearestLosingOption())

    printfn "Day 22 Part 1: %A" (Day22Part1.findCheapestWinningOption())
    0 // return an integer exit code 