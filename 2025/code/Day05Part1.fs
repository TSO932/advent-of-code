namespace _2025

open System

module Day05Part1 =

    let run (input:seq<string>) =

        let freshRanges =
            input
            |> Seq.filter (fun inputLine -> inputLine.Contains "-")
            |> Seq.map (fun s -> s.Split '-' |> Seq.map Int64.Parse |> Array.ofSeq)
        
        let availableIngredients =
            input
            |> Seq.filter (fun inputLine -> not (inputLine = "" || inputLine.Contains "-"))
            |> Seq.map Int64.Parse

        let isFresh(ingredient) =
            freshRanges
            |> Seq.exists (fun range -> ingredient >= range[0] && ingredient <= range[1])

        availableIngredients
        |> Seq.filter isFresh
        |> Seq.length


        