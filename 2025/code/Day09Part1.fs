namespace _2025

open System

module Day09Part1 =

    let run(input:seq<string>) =
        
        let lst =
            input
            |> Seq.map ((fun line -> line.Split ',' |> Seq.map Int64.Parse) >> (Array.ofSeq >> fun a -> a[0], a[1]))
            |> List.ofSeq

        let getPairs(lst) =
            lst |> List.mapi (fun i a -> lst |> List.mapi (fun j b -> if i < j then [a; b] else []))
                |> List.concat
                |> List.filter (fun a -> List.length a = 2)
                |> List.map (fun a -> a[0], a[1])
https://adventofcode.com/2025/day/9
        getPairs lst
        |> List.map (fun ((x1, y1), (x2, y2)) -> ((1L + Math.Abs(x2 - x1)) * (1L + Math.Abs(y2 - y1))))
        |> List.max
