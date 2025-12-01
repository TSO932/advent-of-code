namespace _2025

open System

module Day01Part2 =

    let rotation(input:string) =
        
        let direction =
            match Seq.head input with
            | 'L' -> -1
            | _ -> 1

        let clicks = Int32.Parse input[1..]

        (clicks / 100, direction * clicks % 100)

    let newPosition(position, clicks) =

        let newPosition = position + clicks

        let partialTurn = if position = 0 || newPosition = 100 then 0 else 1
     
        if newPosition > 99 then
            (partialTurn, newPosition - 100)
        elif newPosition < 0 then
            (partialTurn, newPosition + 100)
        else
            (0, newPosition)

    let run (input: seq<string>) =

        let instructions = input |> Seq.map rotation

        let fullTurns = instructions |> Seq.sumBy fst

        let positions =
            instructions
            |> Seq.scan (fun position instruction -> newPosition(snd position, snd instruction)) (0, 50)

        let zeroPositions =
            positions
            |> Seq.map snd
            |> Seq.filter ((=) 0)
            |> Seq.length
        
        let rotationsPastZero =
            positions
            |> Seq.sumBy fst

        fullTurns + zeroPositions + rotationsPastZero