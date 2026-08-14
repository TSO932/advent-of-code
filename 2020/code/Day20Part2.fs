namespace AoC2020

open System.Collections.Generic

module Day20Part2 =

    type Face = 
        | Obverse 
        | Reverse

    type Direction = 
        | Left 
        | Right
        | Top 
        | Bottom 

    let isSeaMonster (grid: char[,]) : bool =
        let monsterCoords = [
            (0, 18)
            (1, 0); (1, 5); (1, 6); (1, 11); (1, 12); (1, 17); (1, 18); (1, 19)
            (2, 1); (2, 4); (2, 7); (2, 10); (2, 13); (2, 16)
        ]
        monsterCoords |> List.forall (fun (r, c) -> grid.[r, c] = '#')

    let flipVertical (tile: char[,]) : char[,] =
        let rows = Array2D.length1 tile
        let cols = Array2D.length2 tile
        Array2D.init rows cols (fun r c -> tile.[rows - 1 - r, c])

    let flipHorizontal (tile: char[,]) : char[,] =
        let rows = Array2D.length1 tile
        let cols = Array2D.length2 tile
        Array2D.init rows cols (fun r c -> tile.[r, cols - 1 - c])

    let rotateClockwise (tile: char[,]) : char[,] =
        let rows = Array2D.length1 tile
        let cols = Array2D.length2 tile
        Array2D.init rows cols (fun r c -> tile.[cols - 1 - c, r])

    let rotateAntilockwise (tile: char[,]) : char[,] =
        let rows = Array2D.length1 tile
        let cols = Array2D.length2 tile
        Array2D.init rows cols (fun r c -> tile.[c, rows - 1 - r])

    let rotateClockAndflipHoriz (tile: char[,]) : char[,] =
        tile |> rotateClockwise |> flipHorizontal

    let orientations (grid: char[,]) =
        let r1 = rotateClockwise grid
        let r2 = rotateClockwise r1
        let r3 = rotateClockwise r2
        let flipped = flipVertical grid
        let f1 = rotateClockwise flipped
        let f2 = rotateClockwise f1
        let f3 = rotateClockwise f2
        [ grid; r1; r2; r3; flipped; f1; f2; f3 ]

    let getEdgesSeq (pixel: char[,]) =
            seq {
                pixel.[0, 0..9]
                pixel.[9, 0..9]
                pixel.[0..9, 0]
                pixel.[0..9, 9]
            }

    let calculateSeaRoughness (pixels: seq<string>) =

        // Section 1 - Parse Data

        let tileRows =
            pixels
            |> Seq.filter (fun x -> x.Length > 0)
            |> Seq.chunkBySize 11
            |> Seq.map (fun x -> (Seq.head x, Seq.tail x))

        let parsedTiles =
            tileRows
            |> Seq.map (fun x ->
                let tileId = int64 (fst x).[5..8]
                let grid = Array2D.init 10 10 (fun i j -> (snd x |> Array.ofSeq).[i].[j])
                (tileId, grid))

        let getEdges (pixel: char[,]) =
            let edges = getEdgesSeq pixel
            Seq.concat (seq { edges; edges |> Seq.map (Array.rev) })
            |> Seq.map System.String.Concat

        // Section 2 - Get Edges

        let pixelsEdges =
            parsedTiles
            |> Seq.map (fun (tileNumber, pixel) -> (tileNumber, getEdges pixel))

        let matchedSquares (tile1, edges1) =
            let edgeSet1 = Set.ofSeq edges1

            let matchedTiles =
                pixelsEdges
                |> Seq.choose (fun (tile2, edges2) ->
                    if tile1 <> tile2 && Seq.exists edgeSet1.Contains edges2 then
                        Some tile2
                    else
                        None)

            tile1, matchedTiles

        // Section 3 - Put tiles into a sequence

        let unselectedTiles = Dictionary<int64, list<int64>>()

        pixelsEdges
        |> Seq.map matchedSquares
        |> Seq.iter (fun (tile, neighbours) -> unselectedTiles.Add(tile, List.ofSeq neighbours))

        let allTiles = unselectedTiles |> Seq.toList

        let mutable linksList = []

        let rec ringPath startSquare =

            let outerRing = Dictionary<int64, list<int64>>()
            let innerRings = Dictionary<int64, list<int64>>()

            unselectedTiles
            |> Seq.iter (fun (KeyValue(tile, neighbours)) ->
                if Seq.length neighbours = 4 then
                    innerRings.Add(tile, List.ofSeq neighbours)
                else
                    outerRing.Add(tile, List.ofSeq neighbours))

            outerRing
            |> Seq.iter (fun (KeyValue(tile, neighbours)) ->
                outerRing.[tile] <- neighbours |> List.filter (fun n -> not (innerRings.Keys |> Seq.contains n)))

            innerRings
            |> Seq.iter (fun (KeyValue(tile, neighbours)) ->
                innerRings.[tile] <- neighbours |> List.filter (fun n -> not (outerRing.Keys |> Seq.contains n)))

            let secondSquare = Seq.head unselectedTiles[startSquare]

            unselectedTiles.Remove(startSquare) |> ignore
            outerRing.Remove(startSquare) |> ignore

            let addLink tileA tileB =
                unselectedTiles.Remove(tileB) |> ignore
                outerRing.Remove(tileB) |> ignore

                let removeNeighbours (tiles: Dictionary<int64, list<int64>>) =
                    tiles
                    |> Seq.iter (fun (KeyValue(tile, neighbours)) ->
                        tiles[tile] <- neighbours |> List.filter (fun n -> n <> tileB))

                removeNeighbours outerRing
                removeNeighbours unselectedTiles

                linksList <- (tileA, tileB) :: linksList

            addLink startSquare secondSquare

            let rec nextTile previousTile =
                if outerRing.Count = 0 then
                    ()
                else
                    let nextOne =
                        outerRing
                        |> Seq.choose (fun (KeyValue(tile, neighbours)) ->
                            if Seq.length neighbours = 1 then Some tile else None)
                        |> Seq.exactlyOne

                    addLink previousTile nextOne
                    nextTile nextOne

            nextTile secondSquare

            let lastTile = snd (List.head linksList)

            let nextNeighbour =
                allTiles
                |> List.find (fun (KeyValue(tile, _)) -> tile = lastTile)
                |> fun (KeyValue(_, neighbours)) -> neighbours
                |> Seq.filter (fun t -> innerRings.Keys |> Seq.contains t)
                |> Seq.tryExactlyOne

            match nextNeighbour with
            | Some t ->
                if unselectedTiles.Count = 1 then
                    linksList <- (lastTile, t) :: linksList
                else
                    ringPath t
            | None -> ()

        let startSquare = 
            unselectedTiles
            |> Seq.filter (fun tile -> Seq.length tile.Value = 2)
            |> Seq.map (fun tile -> tile.Key)
            |> Seq.head

        let startNeighbours = unselectedTiles.GetValueOrDefault(startSquare)

        ringPath startSquare

        let linksMap = Map.ofList linksList

        // Section 4 - Place tiles on grid

        let numberRows = sqrt (float (Seq.length parsedTiles)) |> int
        let fullSize = 8 * (2 * numberRows - 1)
        let startPosition = 8 * (numberRows - 1)
        let emptyArray = Array2D.create<char> fullSize fullSize '_'

        let addTile r c (tile: char[,]) (currentGrid: char[,]) =
            let grid = Array2D.copy currentGrid
            for i in 1 .. 8 do
                for j in 1 .. 8 do
                    grid.[r + i - 1, c + j - 1] <- tile.[i, j]
            grid

        // --- FIX: Correctly orient the start square before placement ---
        let getTileGrid tileId =
            parsedTiles |> Seq.find (fun (id, _) -> id = tileId) |> snd

        let rawStartGrid = getTileGrid startSquare

        let neighbor1Grid = getTileGrid startNeighbours.[0]
        let neighbor2Grid = getTileGrid startNeighbours.[1]

        let getEdges (pixel: char[,]) =
            pixel |> getEdgesSeq |> Seq.map System.String.Concat |> Set.ofSeq

        let n1Edges = getEdges neighbor1Grid
        let n2Edges = getEdges neighbor2Grid

        let isEdgeMatched (edge: char[]) =
            let s = System.String.Concat edge
            let revS = System.String.Concat (Array.rev edge)
            Set.contains s n1Edges || Set.contains revS n1Edges ||
            Set.contains s n2Edges || Set.contains revS n2Edges

        let orientCorner (tile: char[,]) =
            tile
            |> orientations
            |> List.find (fun g ->
                // Orient so the 2 matching edges point RIGHT (column 9) and BOTTOM (row 9)
                isEdgeMatched g.[9, *] && isEdgeMatched g.[*, 9])

        let startGrid = orientCorner rawStartGrid
        // -----------------------------------------------------------------

        let initialFullArray = addTile startPosition startPosition startGrid emptyArray
// <<<< END REPLACE >>>>

        let rec placeNextTile y x currentTile currGridFlipped currentFullArray remainingLinks =
            match Map.tryFind currentTile remainingLinks with
            | None -> currentFullArray
            | Some nextTile ->
                let updatedLinks = Map.remove currentTile remainingLinks

                let getEdge (face: Face) (direction: Direction) (tile: char[,]) =
                    let edge = 
                        match direction with
                        | Left   -> tile.[*, 0]
                        | Right  -> tile.[*, 9]
                        | Top    -> tile.[0, *]
                        | Bottom -> tile.[9, *]

                    match face with
                    | Obverse -> edge
                    | Reverse -> Array.rev edge

                let allDirections = seq { Direction.Left; Direction.Right; Direction.Top; Direction.Bottom }
                let bothFaces = seq { Face.Obverse; Face.Reverse }
                
                let getEdges faces tile =
                    allDirections
                    |> Seq.map (fun dir -> faces |> Seq.map (fun face -> (dir, face, getEdge face dir tile)))
                    |> Seq.concat

                let currentEdges = getEdges [Face.Obverse] currGridFlipped

                let nextGrid =
                    parsedTiles
                    |> Seq.find (fun (tileId, _) -> tileId = nextTile)
                    |> snd

                let nextEdges = getEdges bothFaces nextGrid

                let matchedCurrentEdge =
                    let nxtSet = nextEdges |> Seq.map (fun (_, _, e) -> e) |> Set.ofSeq
                    currentEdges |> Seq.filter (fun (_, _, e) -> nxtSet.Contains e) |> Seq.exactlyOne

                let matchedNextEdge =
                    let curSet = currentEdges |> Seq.map (fun (_, _, e) -> e) |> Set.ofSeq
                    nextEdges |> Seq.filter (fun (_, _, e) -> curSet.Contains e) |> Seq.exactlyOne

                let faceGrid =
                    match matchedNextEdge with
                    | (_, Face.Obverse, _) -> nextGrid
                    | (Direction.Right, Face.Reverse, _)
                    | (Direction.Left, Face.Reverse, _) -> flipVertical nextGrid
                    | (Direction.Top, Face.Reverse, _)
                    | (Direction.Bottom, Face.Reverse, _) -> flipHorizontal nextGrid
                    
                let (yNew, xNew, flippedTile) =
                    match matchedCurrentEdge, matchedNextEdge with
                    | (Direction.Right, _, _), (Direction.Right, _, _) -> (y, x + 8, flipHorizontal faceGrid)
                    | (Direction.Right, _, _), (Direction.Left, _, _) -> (y, x + 8, faceGrid)
                    | (Direction.Right, _, _), (Direction.Top, _, _) -> (y, x + 8, rotateClockAndflipHoriz faceGrid)
                    | (Direction.Right, _, _), (Direction.Bottom, _, _) -> (y, x + 8, rotateClockwise faceGrid)

                    | (Direction.Left, _, _), (Direction.Right, _, _) -> (y, x - 8, faceGrid)
                    | (Direction.Left, _, _), (Direction.Left, _, _) -> (y, x - 8, flipHorizontal faceGrid)
                    | (Direction.Left, _, _), (Direction.Top, _, _) -> (y, x - 8, rotateClockwise faceGrid)
                    | (Direction.Left, _, _), (Direction.Bottom, _, _) -> (y, x - 8, rotateClockAndflipHoriz faceGrid)

                    | (Direction.Bottom, _, _), (Direction.Right, _, _) -> (y + 8, x, rotateAntilockwise faceGrid)
                    | (Direction.Bottom, _, _), (Direction.Left, _, _) -> (y + 8, x, rotateClockAndflipHoriz faceGrid)
                    | (Direction.Bottom, _, _), (Direction.Top, _, _) -> (y + 8, x, faceGrid)
                    | (Direction.Bottom, _, _), (Direction.Bottom, _, _) -> (y + 8, x, flipVertical faceGrid)
                    
                    | (Direction.Top, _, _), (Direction.Right, _, _) -> (y - 8, x, rotateClockAndflipHoriz faceGrid)
                    | (Direction.Top, _, _), (Direction.Left, _, _) -> (y - 8, x, rotateAntilockwise faceGrid)
                    | (Direction.Top, _, _), (Direction.Top, _, _) -> (y - 8, x, flipVertical faceGrid)
                    | (Direction.Top, _, _), (Direction.Bottom, _, _) -> (y - 8, x, faceGrid)

                let nextFullArray = addTile yNew xNew flippedTile currentFullArray
                
                placeNextTile yNew xNew nextTile flippedTile nextFullArray updatedLinks

        let fullArray = placeNextTile startPosition startPosition startSquare startGrid initialFullArray linksMap

        // Section 5 - Trim grid and remove tile borders

        let cropGrid (grid: char[,]) : char[,] =
            let points = seq {
                for r in 0 .. (Array2D.length1 grid) - 1 do
                    for c in 0 .. (Array2D.length2 grid) - 1 do
                        if grid.[r, c] <> '_' then
                            yield (r, c)
            }

            let minR = points |> Seq.map fst |> Seq.min
            let maxR = points |> Seq.map fst |> Seq.max
            let minC = points |> Seq.map snd |> Seq.min
            let maxC = points |> Seq.map snd |> Seq.max

            grid.[minR .. maxR, minC .. maxC]   
            
        // Section 6 - Count Sea Monsters & Calculate Sea Roughness

        let monsterCoords = [
            (0, 18)
            (1, 0); (1, 5); (1, 6); (1, 11); (1, 12); (1, 17); (1, 18); (1, 19)
            (2, 1); (2, 4); (2, 7); (2, 10); (2, 13); (2, 16)
        ]

        let markMonsters (grid: char[,]) : (char[,] * int) =
            let g = Array2D.copy grid
            let rows = Array2D.length1 g
            let cols = Array2D.length2 g
            let mutable count = 0
            
            for r in 0 .. rows - 3 do
                for c in 0 .. cols - 20 do
                    if monsterCoords |> List.forall (fun (dr, dc) -> g.[r + dr, c + dc] = '#' || g.[r + dr, c + dc] = 'O') then
                        let hasHash = monsterCoords |> List.exists (fun (dr, dc) -> g.[r + dr, c + dc] = '#')
                        if hasHash then
                            count <- count + 1
                            monsterCoords |> List.iter (fun (dr, dc) -> g.[r + dr, c + dc] <- 'O')
                        
            (g, count)

        let cropped = fullArray |> cropGrid

        let (markedGrid, monsterCount) =
            cropped
            |> orientations
            |> List.map markMonsters
            |> List.maxBy snd

        let totalHashes = 
            cropped 
            |> Seq.cast<char> 
            |> Seq.filter ((=) '#') 
            |> Seq.length

        totalHashes