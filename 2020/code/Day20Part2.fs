namespace AoC2020

open System

module Day20Part2 =

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

    let orientations (grid: char[,]) =
        let r1 = rotateClockwise grid
        let r2 = rotateClockwise r1
        let r3 = rotateClockwise r2
        let flipped = flipVertical grid
        let f1 = rotateClockwise flipped
        let f2 = rotateClockwise f1
        let f3 = rotateClockwise f2
        [ grid; r1; r2; r3; flipped; f1; f2; f3 ]

    let getEdges (tile: char[,]) =
            seq {
                tile.[0,*]
                tile.[9, *]
                tile.[*, 0]
                tile.[*, 9]
            }

    let calculateSeaRoughness (pixels: seq<string>) =

        // Section 1 - Parse data

        let p = Seq.map (fun x -> (Seq.head x, Seq.tail x)) (pixels |> Seq.filter  (fun x -> x.Length > 0) |> Seq.chunkBySize 11)
        let tiles = p |> Seq.map (fun x -> (int64 (fst x).[5..8], (Array2D.init 10 10 (fun i j -> (snd x |> Array.ofSeq).[i].[j]))))

        // Section 2 - Place tiles
        let tileSize = 10
        let tilesPerRow = tiles |> Seq.length |> float |> sqrt |> int
        let fullSize = tileSize * tilesPerRow
        let grid = Array2D.create<char> fullSize fullSize '_'

        let edgeKey (edge: char[]) =
            let edgeText = String.Concat edge
            let reversed = edgeText |> Seq.rev |> String.Concat
            min edgeText reversed

        let edgeCounts =
            tiles
            |> Seq.collect (fun (_, tile) -> getEdges tile |> Seq.map edgeKey)
            |> Seq.countBy id
            |> Map.ofSeq

        let isOuterEdge (edge: char[]) = edgeCounts.[edgeKey edge] = 1
        let placed = Array2D.create<(int64 * char[,]) option> tilesPerRow tilesPerRow None

        let orientationCandidates (tile: char[,]) =
            orientations tile
            |> List.distinctBy (fun candidate ->
                [| for r in 0 .. tileSize - 1 do
                       for c in 0 .. tileSize - 1 do
                           yield candidate.[r, c] |])

        let matchesNeighbours row col (tile: char[,]) =
            let leftMatches =
                if col = 0 then
                    isOuterEdge tile.[*, 0]
                else
                    match placed.[row, col - 1] with
                    | Some (_, leftTile) -> tile.[*, 0] = leftTile.[*, tileSize - 1]
                    | None -> false

            let topMatches =
                if row = 0 then
                    isOuterEdge tile.[0, *]
                else
                    match placed.[row - 1, col] with
                    | Some (_, topTile) -> tile.[0, *] = topTile.[tileSize - 1, *]
                    | None -> false

            let rightMatches = col < tilesPerRow - 1 || isOuterEdge tile.[*, tileSize - 1]
            let bottomMatches = row < tilesPerRow - 1 || isOuterEdge tile.[tileSize - 1, *]
            leftMatches && topMatches && rightMatches && bottomMatches

        let copyTileToGrid row col (tile: char[,]) =
            for tileRow in 0 .. tileSize - 1 do
                for tileCol in 0 .. tileSize - 1 do
                    grid.[row * tileSize + tileRow, col * tileSize + tileCol] <- tile.[tileRow, tileCol]

        let clearTileFromGrid row col =
            for tileRow in 0 .. tileSize - 1 do
                for tileCol in 0 .. tileSize - 1 do
                    grid.[row * tileSize + tileRow, col * tileSize + tileCol] <- '_'

        let rec placeTile position used =
            if position = tilesPerRow * tilesPerRow then
                true
            else
                let row = position / tilesPerRow
                let col = position % tilesPerRow

                tiles
                |> Seq.toList
                |> List.tryPick (fun (tileId, rawTile) ->
                    if Set.contains tileId used then
                        None
                    else
                        rawTile
                        |> orientationCandidates
                        |> List.tryPick (fun tile ->
                            if matchesNeighbours row col tile then
                                placed.[row, col] <- Some (tileId, tile)
                                copyTileToGrid row col tile

                                if placeTile (position + 1) (Set.add tileId used) then
                                    Some ()
                                else
                                    placed.[row, col] <- None
                                    clearTileFromGrid row col
                                    None
                            else
                                None))
                |> Option.isSome

        if not (placeTile 0 Set.empty) then
            failwith "Could not place all tiles"

        // Section 3 - Remove the border from every tile

        let innerTileSize = tileSize - 2
        let innerSize = innerTileSize * tilesPerRow

        let removeTileBorders (grid: char[,]) : char[,] =
            Array2D.init innerSize innerSize (fun row col ->
                let tileRow = row / innerTileSize
                let tileCol = col / innerTileSize
                let tileRowOffset = row % innerTileSize + 1
                let tileColOffset = col % innerTileSize + 1
                grid.[tileRow * tileSize + tileRowOffset,
                      tileCol * tileSize + tileColOffset])
            
        // Section 4 - Count sea monsters and calculate sea roughness

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

        let cropped = grid |> removeTileBorders

        let markedGrid =
            cropped
            |> orientations
            |> List.map markMonsters
            |> List.maxBy snd
            |> fst

        // Uncomment to print the finished grid.
        // for r in 0 .. Array2D.length1 markedGrid - 1 do printfn "%s" (System.String(markedGrid.[r, *]))
        
        markedGrid 
        |> Seq.cast<char> 
        |> Seq.filter ((=) '#') 
        |> Seq.length