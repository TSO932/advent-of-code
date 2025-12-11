namespace _2025

open System
open System.Collections.Generic

module Day11Part1 =

    let run(input:seq<string>) =
        
        let connections =
            input
            |> Seq.map (fun line -> line.Split([|':'; ' '|], StringSplitOptions.RemoveEmptyEntries))
            |> Seq.map (fun a -> (Seq.head a, Seq.tail a))
            |> Seq.append [| ( "out", [|"out"|] ) |]
            |> dict
            |> Dictionary

        let rec getPaths(positions) =

            let newPositions =
                positions
                |> Seq.map (fun (pos, qty) -> connections[pos] |> Seq.map (fun p -> (p, qty)))
                |> Seq.concat
                |> Seq.groupBy fst
                |> Seq.map (fun (pos, grp) -> (pos, grp |> Seq.map snd |> Seq.sum))

            if Seq.length newPositions  = 1 then
                newPositions
                |> Seq.head
                |> snd
            else
                getPaths(newPositions)

        getPaths ([| ("you", 1) |])

        