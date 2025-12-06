namespace _2025

open System

module Day06Part1 =

    let run (input:seq<string>) =

        let parsedInput =
            input
            |> Seq.map (fun inputLine -> inputLine.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            |> Seq.rev

        let numbers =
            parsedInput
            |> Seq.tail
            |> Seq.map (Seq.map Int64.Parse)
            |> Seq.map (Array.ofSeq)
            |> Array.ofSeq
        
        let matrix = Array2D.init numbers.Length numbers.[0].Length (fun i j -> numbers.[i].[j])

        let getColumn(i) =
            matrix.[*, i..i]
            |> Seq.cast<Int64>

        let operate(i, o) =

            let c = getColumn(i)

            if o = "*" then
                Seq.fold (fun a b -> a * b) 1L c
            else
                Seq.fold (fun a b -> a + b) 0L c


        parsedInput
        |> Seq.head
        |> Seq.mapi (fun i o -> operate(i, o))
        |> Seq.sum
