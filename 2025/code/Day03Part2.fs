namespace _2025

open System

module Day03Part2 =

    let getNextDigit(inputLine:string, currentValue, countOfDigits) =

        let digit =
            inputLine[ .. (String.length inputLine) - countOfDigits]
            |> Seq.max

        let index = inputLine.IndexOf (digit)

        let remainingString = inputLine[(index + 1) .. ]

        (remainingString, currentValue * 10L + int64(Char.GetNumericValue(digit)), countOfDigits - 1)

    let rec getDigits (inputLine:string, currentValue, countOfDigits) =

        if countOfDigits = 0 then
            currentValue
        else
            getDigits(getNextDigit (inputLine, currentValue, countOfDigits))

    let getJoltage(inputLine:string) =
    
        getDigits (inputLine, 0L, 12)

    let run(input) =

        input
        |> Seq.sumBy getJoltage

