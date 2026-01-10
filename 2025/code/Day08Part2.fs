namespace _2025

open System
open System.Collections.Generic

module Day08Part2 =

    let getDistance((x1:int64,y1:int64,z1:int64), (x2:int64,y2:int64,z2:int64)) =

        let square n = n * n

        square (x1 - x2) + square (y1 - y2) + square (z1 - z2)
    

    let parseLine(inputLine:string) =
        
        inputLine.Split ','
        |> Seq.map Int64.Parse
        |> Array.ofSeq
        |> fun a -> (a[0], a[1], a[2])

    let backToText(a,b,c) =

        a.ToString() + "," + b.ToString() + c.ToString()

    let getGroups(pairs:(string*string)[]) =

        let nodes =
            pairs
            |> Array.collect (fun (a, b) -> [| a; b |])
            |> Array.distinct

        let parent = Dictionary<string,string>()
        let rank = Dictionary<string,int>()
        for node in nodes do
            parent.Add(node, node)
            rank.Add(node, 0)

        let rec find (x:string) =
            if parent[x] <> x then
                parent[x] <- find parent[x]
            parent[x]

        let isOnlyOne() =

            let firstOne = find nodes[0]
            nodes
            |> Array.exists (fun node -> find node <> firstOne)
            |> not

        let union (x:string, y:string) =
            let xRoot = find x
            let yRoot = find y
            if xRoot <> yRoot then
                if rank[xRoot] < rank[yRoot] then
                    parent[xRoot] <- yRoot
                elif rank[xRoot] > rank[yRoot] then
                    parent[yRoot] <- xRoot
                else
                    parent[yRoot] <- xRoot
                    rank[xRoot] <- rank[xRoot] + 1

        let rec unionise(ps:(string*string)[]) =

            let pair = ps[0]

            union pair

            if isOnlyOne() then
                let getX(coords:string) =
                    coords.Split ','
                    |> fun a -> Int64.Parse a.[0]

                getX(fst pair) * getX(snd pair)
            else
                ps
                |> Array.tail
                |> unionise
        
        unionise(pairs)

    let run(input:seq<string>) =

        let getPairs(lst) =
            lst |> List.mapi (fun i a -> lst |> List.mapi (fun j b -> if i < j then [a; b] else []))
                |> List.concat
                |> List.filter (fun a -> List.length a = 2)
 
        input
        |> Seq.map parseLine
        |> List.ofSeq
        |> getPairs
        |> List.map ( (fun a -> (a[0], a[1])) >> (fun a -> (a, getDistance a)) )
        |> List.sortBy snd        
        |> List.map (fun ((a, b), _) -> (backToText a, backToText b))
        |> List.toArray
        |> getGroups




   