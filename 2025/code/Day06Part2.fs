namespace _2025

open System

module Day06Part2 =

    let run (input:seq<string>) =

        let reversedInput = Seq.rev input

        let digitise(digits:seq<char>) =
            let rec digi(value, remainingDigits:seq<char>) =
                if Seq.isEmpty remainingDigits then
                    value
                else
                    let digit = Seq.head remainingDigits

                    let newValue =
                        if digit = ' ' then
                            value
                        else
                            10L * value + (Int64.Parse (String.Concat digit))

                    digi(newValue, Seq.tail remainingDigits)

            digi(0L, digits)

        let numbers  =
            reversedInput
            |> Seq.tail
            |> Seq.map Seq.toArray
            |> Array.ofSeq
        
        let matrix = Array2D.init numbers.Length numbers.[0].Length (fun i j -> numbers.[i].[j])

        let operators = Seq.head reversedInput

        let terms(i) =
            matrix.[*, i..i]
            |> Seq.cast<char>
            |> Seq.rev
            |> String.Concat
            |> digitise

        let terms = Seq.mapi (fun i _ -> terms i) operators

        let accumulate ((bigAcc, littleAcc, op), (newOp, newValue)) =
            match (newOp, op) with
            | ('*', _) | ('+', _) -> (bigAcc + littleAcc, newValue, newOp)
            | (_, '*') -> (bigAcc, littleAcc * newValue, op)
            | _ -> (bigAcc, littleAcc + newValue, op)
    
        (operators, terms)
        ||> Seq.zip
        |> Seq.filter (fun (_, n) -> n <> 0L)
        |> Seq.fold (fun acc entry -> accumulate (acc, entry)) (0L, 0L, ' ')
        |> fun (a, b, _) -> a + b

