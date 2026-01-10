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
            |> List.mapi (fun i n -> ((n, 2 * i), (2 * i, n)))
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

        let polygonWithBitsGone =
            polygon
            |> List.filter (fun (x, y) -> not (List.contains (x + 1, y) polygon))

        let getPairs(lst) =
            lst |> List.mapi (fun i a -> lst |> List.mapi (fun j b -> if i < j then [a; b] else []))
                |> List.concat
                |> List.filter (fun a -> List.length a = 2)
                |> List.map (fun a -> a[0], a[1])

        let getSquare (x1, y1) (x2, y2) =
            
            let minX = min x1 x2
            let maxX = max x1 x2
            let minY = min y1 y2
            let maxY = max y1 y2

            let vert =  Array.init (maxY - minY + 1) (fun v -> minY + v) // incl. corner squares
            let horiz = Array.init (max 0 (maxX - minX - 2)) (fun v -> minX + 1 + v) // excl. corner squares

            let top = horiz |> Array.map (fun x -> (x, minY))
            let bottom = horiz |> Array.map (fun x -> (x, maxY))
            let left = vert |> Array.map (fun y -> (minX, y))
            let right = vert |> Array.map (fun y -> (maxX, y))
            
            top
            |> Array.append bottom
            |> Array.append left
            |> Array.append right

        let maxX = Seq.length compressedX
        let cache = Dictionary<_,_>()

        let pointOutsidePolygon x y =
            match cache.TryGetValue((x, y)) with
            | true, memorisedAnswer -> memorisedAnswer
            | _ -> 

                if List.contains (x, y) polygon then
                    false
                else
                    let notInPolygon =
                        polygonWithBitsGone
                        |> List.filter (fun (_, y1) -> y1 = y)
                        |> List.map fst
                        |> List.filter (fun x1 -> x1 > x)
                        |> List.length
                        |> fun n -> n % 2 = 0    

                    cache.Add((x,y), notInPolygon)
                    notInPolygon

        let squareInPolygon square =

            let sample =
                Array.randomChoices ((Array.length square) / 10) square

            if sample
                |> Array.exists (fun (x, y) -> pointOutsidePolygon x y) then false
            else
                square
                |> Array.exists (fun (x, y) -> pointOutsidePolygon x y)
                |> not

        let convertBack square =
            square
            |> Array.fold (
                fun ((minX, minY), (minx, maxY)) (x, y) ->
                    ((min x minX, min y minY), (max x maxX, max y maxY))) ((99999999,9999999), (-1,-1))
            |> fun ((x1, y1), (x2, y2)) -> ((revX[x1], revY[y1]), (revX[x2], revY[y2]))

        getPairs compressedXY
        |> List.map (fun (a, b) -> getSquare a b)
        |> List.filter squareInPolygon
        |> List.map (convertBack >> (fun ((x1, y1), (x2, y2)) -> ((1L + Math.Abs(x2 - x1)) * (1L + Math.Abs(y2 - y1)))))
        |> List.max
