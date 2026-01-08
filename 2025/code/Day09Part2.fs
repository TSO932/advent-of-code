namespace _2025

open System
open System.Collections.Generic

module Day09Part2 =

    let run(input:seq<string>) =
        
        let lst =
            input
            |> Seq.map ((fun line -> line.Split ',' |> Seq.map Int64.Parse) >> (Array.ofSeq >> fun a -> a[0], a[1]))
            |> List.ofSeq

        let compress f =
            lst
            |> List.map f
            |> List.sort
            |> List.distinct
            |> List.mapi (fun i n -> ((n, i), (i, n)))
            |> List.unzip
            |> fun (fwd, rev) -> (dict fwd, dict rev)

        let (compressedX, revX) = compress fst
        let (compressedY, revY) = compress snd

        let compressedXY =
            lst
            |> List.map (fun (x, y) -> (compressedX[x], compressedY[y]))

        let getEdge (x1, y1) (x2, y2) =

            if x1 = x2 then
                if y1 = y2 then
                    [ (x1, y1) ]
                else
                    if y2 > y1 then
                        List.init (y2 - y1 + 1) (fun v -> (x1, y1 + v))
                    else
                        List.init (y1 - y2 + 1) (fun v -> (x1, y2 + v))
            else
                if x2 > x1 then
                    List.init (x2 - x1 + 1) (fun v -> (x1 + v, y1))
                else
                    List.init (x1 - x2 + 1) (fun v -> (x2 + v, y1))

        let init = ([], List.last compressedXY)
        
        let polygon =
            compressedXY
            |> List.fold (fun (edges, (x1, y1)) (x2, y2) -> (List.append edges (getEdge (x1, y1) (x2, y2)), (x2, y2))) init
            |> fst
            |> List.distinct

        // removes cells which are in the middle of a horizonal line
        // this approach doesn't work correctly
        let polygonWithBitsGone =
            polygon
            |> List.filter (fun (x, y) -> not (List.contains (x + 1, y) polygon))

        let getPairs(lst) =
            lst |> List.mapi (fun i a -> lst |> List.mapi (fun j b -> if i < j then [a; b] else []))
                |> List.concat
                |> List.filter (fun a -> List.length a = 2)
                |> List.map (fun a -> a[0], a[1])

        let getSquare (x1, y1) (x2, y2) =
            
            let vert =
                if y2 > y1 then
                    List.init (y2 - y1 + 1) (fun v -> y1 + v)
                        else
                    List.init (y1 - y2 + 1) (fun v -> y2 + v)           
            let horiz =
                if x2 > x1 then
                    List.init (x2 - x1 + 1) (fun v -> x1 + v)
                else
                    List.init (x1 - x2 + 1) (fun v -> x2 + v)

            let top = horiz |> List.map (fun x -> (x, y1))
            let bottom = horiz |> List.map (fun x -> (x, y2))
            let left = vert |> List.map (fun y -> (x1, y))
            let right = vert |> List.map (fun y -> (x2, y))
            
            top
            |> List.append bottom
            |> List.append left
            |> List.append right
            |> List.distinct

        let maxX = Seq.length compressedX
        let cache = Dictionary<_,_>()

        let pointInPolygon x y =
            match cache.TryGetValue((x, y)) with
            | true, memorisedAnswer -> memorisedAnswer
            | _ -> 

                if List.contains (x, y) polygon then
                    true
                else
                    let inPolygon =
                        polygonWithBitsGone
                        |> List.filter (fun (_, y1) -> y1 = y)
                        |> List.map fst
                        |> List.filter (fun x1 -> x1 > x)
                        |> List.length
                        |> fun n -> n % 2 = 1    

                    cache.Add((x,y), inPolygon)
                    inPolygon

        let squareInPolygon square =

            let sample =
                List.randomChoices ((List.length square) / 10) square

            if sample
                |> List.map (fun (x, y) -> pointInPolygon x y)
                |> List.contains false then false
            else
                square
                |> List.map (fun (x, y) -> pointInPolygon x y)
                |> List.contains false
                |> not

        let convertBack square =
            let x1 = square |> List.map fst |> List.min
            let x2 = square |> List.map fst |> List.max
            let y1 = square |> List.map snd |> List.min
            let y2 = square |> List.map snd |> List.max
            ((revX[x1], revY[y1]), (revX[x2], revY[y2]))

        getPairs compressedXY
        |> List.map (fun (a, b) -> getSquare a b)
        |> List.filter squareInPolygon
        |> List.map convertBack
        |> List.map (fun ((x1, y1), (x2, y2)) -> ((1L + Math.Abs(x2 - x1)) * (1L + Math.Abs(y2 - y1))))
        |> List.max

