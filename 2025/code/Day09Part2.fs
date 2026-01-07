namespace _2025

open System

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

        let init = ([], List.head compressedXY)
        
        let polygon =
            compressedXY
            |> List.fold (fun (edges, (x1, y1)) (x2, y2) -> (List.append edges (getEdge (x1, y1) (x2, y2)), (x2, y2))) init
            |> fst
            |> List.distinct
            |> Set.ofList

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

            List.map (fun y -> List.map (fun x -> (x, y)) horiz) vert
            |> List.concat


        let maxX = Seq.length compressedX

// memorise this one?
        let pointInPolygon x y =

            if Set.contains (x, y) polygon then
                printfn "YES %i %i" x y
                true
            else
                printfn "NOT %i %i" x y
                let rayCast =
                    List.init (maxX - x) (fun v -> (x + v, y))
                    |> Set.ofList

                (polygon, rayCast)
                ||> Set.intersect
                |> Set.count
                |> fun n -> n % 2 = 1            

        let squareInPolygon square =
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
