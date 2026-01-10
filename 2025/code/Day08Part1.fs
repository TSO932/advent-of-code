namespace _2025

open System
open System.Collections.Generic

module Day08Part1 =

    let getDistance((x1:int64,y1:int64,z1:int64), (x2:int64,y2:int64,z2:int64)) =

        let square n = n * n

        square (x1 - x2) + square (y1 - y2) + square (z1 - z2)
    

    let parseLine(inputLine:string) =
        
        inputLine.Split ','
        |> Seq.map Int64.Parse
        |> Array.ofSeq
        |> fun a -> (a[0], a[1], a[2])

    let backToText(a,b,c) =

        a.ToString() + b.ToString() + c.ToString()


    let getGroups(pairs:seq<string*string>) =
    
        let nodes =
            pairs
            |> Seq.collect (fun (a, b) -> [a; b])
            |> Seq.distinct
            |> Seq.toArray

        let parent =
            nodes
            |> Seq.map (fun node -> (node, node))
            |> dict
            |> Dictionary
        
        let rank =
            nodes
            |> Seq.map (fun node -> (node, 0))
            |> dict
            |> Dictionary

        let rec find (x:string) =
            if parent[x] <> x then
                parent[x] <- find parent[x]
            parent[x]

        let union (x:string) (y:string) =
            let xRoot = find x
            let yRoot = find y
            if xRoot <> yRoot then
                if rank[xRoot] < rank[yRoot] then
                    parent.[xRoot] <- yRoot
                elif rank[xRoot] > rank[yRoot] then
                    parent[yRoot] <- xRoot
                else
                    parent[yRoot] <- xRoot
                    rank[xRoot] <- rank[xRoot] + 1

        for (a, b) in pairs do
            union a b
        
        nodes
        |> Seq.groupBy (fun node -> find node)
        |> Seq.map (snd >> Seq.length)
        |> Seq.sortDescending
        |> Seq.chunkBySize 3
        |> Seq.head
        |> Seq.fold (fun a x -> a * x) 1

    let runCount(input:seq<string>, pairCount) =

        let getPairs(lst) =
            lst |> List.mapi (fun i a -> lst |> List.mapi (fun j b -> if i < j then [a; b] else []))
                |> List.concat
                |> List.filter (fun a -> List.length a = 2)
    
        input
        |> Seq.map parseLine
        |> List.ofSeq
        |> getPairs
        |> List.map (fun a -> (a[0], a[1]))
        |> List.map (fun a -> (a, getDistance a))
        |> List.sortBy snd
        |> List.mapi (fun i a -> (fst a, i))
        |> List.filter (fun (_, i) -> i < pairCount)
        |> List.map fst
        |> List.map (fun (a, b) -> (backToText a, backToText b))
        |> getGroups

    let run(input:seq<string>) =

        runCount(input, 1000)



   