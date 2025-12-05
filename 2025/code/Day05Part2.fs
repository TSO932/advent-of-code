namespace _2025

open System

module Day05Part2 =

    let isContiguous(a:int64[], b:int64[]) =

        not (a[0] > b[1] + 1L || b[0] > a[1] + 1L)

    let getCombinedRange(ranges:seq<int64>) =

            [|Seq.min ranges; Seq.max ranges|]

    let run (input:seq<string>) =

        let freshRanges =
            input
            |> Seq.filter (fun inputLine -> inputLine.Contains "-")
            |> Seq.map (fun s -> s.Split '-' |> Seq.map Int64.Parse |> Array.ofSeq)

        let rec combineRanges(ranges) =
            let initialCount = Seq.length ranges

            let combinedRanges =

                let combine(ranges) =
                    ranges
                    |> Seq.map (fun r1 -> freshRanges |> Seq.filter (fun r2 -> isContiguous(r1, r2)))
                    |> Seq.map (Seq.concat >> getCombinedRange)
                
                ranges            
                |> combine
                |> combine
                |> Seq.distinct

            if Seq.length combinedRanges = initialCount then
                ranges
            else
                combineRanges(combinedRanges)

        freshRanges
        |> combineRanges
        |> Seq.sumBy (fun r -> 1L + r[1] - r[0]) 


    
