namespace _2025

open System
open System.Collections.Generic

module Day11Part2 =

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
                |> Seq.map (fun ((pos, fft, dac), qty) -> connections[pos] |> Seq.map (fun p -> ((p, fft || p = "fft", dac || p = "dac"), qty)))
                |> Seq.concat
                |> Seq.groupBy fst
                |> Seq.map (fun (pos, grp) -> (pos, grp |> Seq.map snd |> Seq.sum))
                |> Seq.filter (fun (pos, _) -> not (pos = ("out", false, true) || pos = ("out", true, false) || pos = ("out", false, false)))

            if Seq.length newPositions  = 1 && (newPositions |> Seq.head |> fun ((pos, _, _), _) -> pos = "out") then
                newPositions
                |> Seq.head
                |> snd
            else
                getPaths(newPositions)

        getPaths ([| (("svr", false, false), 1L) |])

        