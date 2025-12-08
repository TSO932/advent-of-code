namespace _2025

open System

module Day08Part1 =

    let getDistance((x1:float,y1:float,z1:float), (x2:float,y2:float,z2:float)) =

        sqrt ((x1 - x2) ** 2 + (y1 - y2) ** 2 + (z1 - z2) ** 2)
    

    let parseLine(inputLine:string) =
        
        inputLine.Split ','
        |> Seq.map Double.Parse
        |> Array.ofSeq
        |> fun a -> (a[0], a[1], a[2])


    let run(input:seq<string>) =

        let pairCount = 10

        input
        |> Seq.map parseLine
        |> List.ofSeq
        |> CommonFunctions.allCombinations
        |> List.filter (fun a -> List.length a = 2)
        |> List.map (fun a -> (a[0], a[1]))
        |> List.map (fun a -> (a, getDistance a))
        |> List.sortBy snd
        |> List.mapi (fun i a -> (fst a, i))
        |> List.filter (fun (_, i) -> i < pairCount)
        |> List.map fst

        