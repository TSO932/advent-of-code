open AoC2020

[<EntryPoint>]
let main argv =

    let readInput day = AoC.Input.readLines 2020 day

    // printfn "Day  1 Part 1: %i" (Day01Part1.fixExpenses (readInput 01))
    // printfn "Day  1 Part 2: %i" (Day01Part2.fixExpenses (readInput 01))

    // printfn "Day  2 Part 1: %i" (Day02Part1.checkPasswords (readInput 02))
    // printfn "Day  2 Part 2: %i" (Day02Part2.checkPasswords (readInput 02))

    // printfn "Day  3 Part 1: %i" (Day03Part1.countTrees (readInput 03))
    // printfn "Day  3 Part 2: %i" (Day03Part2.countTrees (readInput 03))

    // printfn "Day  4 Part 1: %i" (Day04Part1.validateCredentials(Day04Part1.formatCredentials (readInput 04)))
    // printfn "Day  4 Part 2: %i" (Day04Part2.validateCredentials(Day04Part1.formatCredentials (readInput 04)))

    // printfn "Day  5 Part 1: %i" (Day05Part1.findHighestSeatId(readInput 05))
    // printfn "Day  5 Part 1: %i" (Day05Part2.findMySeat(readInput 05))

    // printfn "Day  6 Part 1: %i" (Day06Part1.countYeses(readInput 06))
    // printfn "Day  6 Part 2: %i" (Day06Part2.countYeses(readInput 06))

    // printfn "Day  7 Part 1: %i" (Day07Part1.myPrecious(readInput 07))
    // printfn "Day  7 Part 2: %i" (Day07Part2.myPrecious(readInput 07))

    // printfn "Day  8 Part 1: %i" (Day08Part1.runProgram(readInput 08))
    // printfn "Day  8 Part 2: %i" (Day08Part2.fixAndRun(readInput 08))

    // printfn "Day  3 Part 1 Elapsed Milliseconds: %f " (PerformanceMeasure.measurePerformance(Day03Part1.countTrees, readInput 03))
    // printfn "Day  3 Part 2 Elapsed Milliseconds: %f " (PerformanceMeasure.measurePerformance(Day03Part2.countTrees, readInput 03))

    // printfn "Day  9 Part 1: %i" (Day09Part1.findInvalidNumber(readInput 09))
    // printfn "Day  9 Part 2: %i" (Day09Part2.findEncryptionWeakness(readInput 09))

    // printfn "Day  9 Part 1 Elapsed Milliseconds: %f " (PerformanceMeasure.measurePerformance(Day09Part1.findInvalidNumber, readInput 09))
    // printfn "Day  9 Part 2 Elapsed Milliseconds: %f " (PerformanceMeasure.measurePerformance(Day09Part2.findEncryptionWeakness, readInput 09))

    // printfn "Day 10 Part 1: %i" (Day10Part1.calculate(readInput 10))
    // printfn "Day 10 Part 2: %i" (Day10Part2.calculate(readInput 10))

    // printfn "Day 10 Part 2 Elapsed Milliseconds: %f " (PerformanceMeasure.measurePerformance(Day10Part2.calculate, readInput 10))

    // printfn "Day 11 Part 1: %i" (Day11Part1.countSeats(readInput 11))
    // printfn "Day 11 Part 1: %i" (Day11Part2.countSeats(readInput 11))

    // printfn "Day 12 Part 1: %i" (Day12Part1.navigate(readInput 12))
    // printfn "Day 12 Part 2: %i" (Day12Part2.navigate(readInput 12))

    printfn "Day 13 Part 1: %i" (Day13Part1.nextBus(readInput 13))
    printfn "Day 13 Part 2: %i" (Day13Part2.nextBus(readInput 13))

    // printfn "Day 14 Part 1: %i" (Day14Part1.initializeFerryDockingProgram(readInput 14))
    // printfn "Day 14 Part 2: %i" (Day14Part2.initializeFerryDockingProgram(readInput 14))

    // let startingNumbers = Day15Part1.getStartingNumbers(readInput 15)
    // printfn "Day 15 Part 1: %i" (Day15Part1.playMemoryGame(startingNumbers))
    // printfn "Day 15 Part 1: %i" (Day15Part2.playMemoryGame(startingNumbers))
    // printfn "Day 15 Part 2 Elapsed Milliseconds: %f " (PerformanceMeasure.measurePerformance(Day15Part2.playMemoryGame, startingNumbers))
    
    printfn "Day 16 Part 1: %i" (Day16Part1.sumErrors (readInput 16))
    printfn "Day 16 Part 2: %i" (Day16Part2.calculate (readInput 16))

    // printfn "Day 17 Part 1: %i" (Day17Part1.countActiveCells(readInput 17))
    // printfn "Day 17 Part 2: %i" (Day17Part2.countActiveCells(readInput 17))

    // printfn "Day 18 Part 1: %i" (Day18Part1.sumValues(readInput 18))
    // printfn "Day 18 Part 2: %i" (Day18Part2.sumValues(readInput 18))

    // printfn "Day 19 Part 1: %i" (Day19Part1.countValidMessages(readInput 19))
    // printfn "Day 19 Part 2: %i" (Day19Part2.countValidMessages(readInput 19))   

    // printfn "Day 20 Part 1: %i" (Day20Part1.findCorners(readInput 20))
    // printfn "Day 20 Part 1 Elapsed Milliseconds: %f " (PerformanceMeasure.measurePerformance(Day20Part1.findCorners, readInput 20))

    printfn "Day 21 Part 1: %i" (Day21Part1.countSafeIngredients (readInput 21))
    printfn "Day 21 Part 2: %s" (Day21Part2.listDangerousIngredients (readInput 21))

    // printfn "Day 22 Part 1: %i" (Day22Part1.playCombat(readInput 22))
    // printfn "Day 22 Part 2: %i" (Day22Part2.playCombat(readInput 22))

    // printfn "Day 23 Part 1: %A" (Day23Part1.playGame(readInput 23))
    // printfn "Day 23 Part 2: %A" (Day23Part2.playGame(readInput 23))
    // printfn "Day 23 Part 2 Elapsed Milliseconds: %f " (PerformanceMeasure.measurePerformance(Day23Part2.playGame, readInput 23))

    // printfn "Day 24 Part 1: %i" (Day24Part1.countTiles(readInput 24))
    // // printfn "Day 24 Part 2: %i" (Day24Part2.countTiles(readInput 24))

    // printfn "Day 25 Part 1: %i" (Day25Part1.merryChristmas(readInput 25))

    0 // return an integer exit code
