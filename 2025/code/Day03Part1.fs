namespace _2025

open System

module Day03Part1 =

    let getFirstDigit(inputLine:string) =

        inputLine[ .. (String.length inputLine) - 2]
        |> Seq.max

    let getSecondDigit(inputLine:string, firstDigit:char) = 

        let firstIndex = inputLine.IndexOf (firstDigit)

        inputLine[(firstIndex + 1) .. ]
        |> Seq.max

    let getJoltage(inputLine:string) =

        let firstDigit = getFirstDigit inputLine    
        let secondDigit = getSecondDigit (inputLine, firstDigit)

        int(Char.GetNumericValue(firstDigit)) * 10 + int(Char.GetNumericValue(secondDigit))

    let run(input) =

        input
        |> Seq.sumBy getJoltage

