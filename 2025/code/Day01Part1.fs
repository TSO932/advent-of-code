namespace _2025

open System

module Day01Part1 =

    let rotation(input:string) =
        
        let direction =
            match Seq.head input with
            | 'L' -> -1
            | _ -> 1

        let clicks = Int32.Parse input[1..]

        direction * clicks % 100


    let newPosition(position, clicks) =

        let newPosition = position + clicks
    
        if newPosition > 99 then
            newPosition - 100
        elif newPosition < 0 then
            newPosition + 100
        else
            newPosition


    let run (input: seq<string>) =

        input
        |> Seq.map rotation
        |> Seq.scan (fun position instruction -> newPosition(position, instruction)) 50
        |> Seq.filter ((=) 0)
        |> Seq.length
