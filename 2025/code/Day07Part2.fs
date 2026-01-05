namespace _2025

open System

module Day07Part2 =

    let processRow(row:string, values:int64[]) =

        let r = Seq.toArray row

        let f i c =
            match c with
            | 'S' -> 1L
            | '^' -> 0L
            | _ ->
                values[i]
                + if i > 0 && r[i - 1] = '^' then
                    values[i - 1]
                    else 0L
                + if i < Array.length r - 1 && r[i + 1] = '^' then
                    values[i + 1]
                    else 0L

        r
        |> Array.mapi f

    let run(input:seq<string>) =

        let inp =
            input
            |> Seq.toArray
        
        inp
        |> Array.fold (fun vals row -> processRow(row, vals)) (Array.zeroCreate<int64> inp[0].Length)
        |> Array.sum

