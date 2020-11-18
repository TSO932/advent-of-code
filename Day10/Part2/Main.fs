let isDebug = true
    
let vaporise(spaceMap:string,stationLocation) =
    let arrays = spaceMap.Split '\010' |> Seq.map (fun a -> Array.ofSeq a) |> Array.ofSeq
    let matrix = Array2D.init arrays.Length arrays.[0].Length (fun i j -> arrays.[i].[j])

    if isDebug then printfn "%A" matrix

    let matrixOfAngles = matrix |> Array2D.mapi (fun v h c -> (c = '#' && not (v = snd stationLocation && h = fst stationLocation), (System.Math.Atan2(float (h - fst stationLocation),float (v - snd stationLocation)), h - fst stationLocation)))
    
    let mutable firingAngle = float 3.141592654f

    let angleWithMostAsteroids = matrixOfAngles |> Seq.cast<bool*(double*int)> |> Seq.filter (fun x -> fst x) |> Seq.groupBy (fun x -> fst (snd x)) |> Seq.map (fun (a,b) -> (a, Seq.length b)) |> Seq.maxBy snd |> fst
    let nextTarget = matrixOfAngles |> Seq.cast<bool*(double*int)> |> Seq.filter (fun x -> fst x) |> Seq.maxBy snd
    let mapWithTargetRemoved = matrixOfAngles |> Seq.cast<bool*(double*int)> |> Seq.filter (fun x -> not (x = nextTarget))
    
    //let asteroidsInLineOfFire = matrixOfAngles |> Array2D.mapi (fun y x c -> if fst c && snd c = angleWithMostAsteroids then (true, (y, x)) else (false, (0, 0))) |> Seq.cast<bool*(int*int)> |> Seq.filter (fun x -> fst x) |> Seq.map snd
    //let furthestAsteroid = asteroidsInLineOfFire |> Seq.map (fun (y, x) -> x * 100 + y, abs (x - fst stationLocation) + abs (y - snd stationLocation)) |> Seq.maxBy snd |> fst

    //if isDebug then printfn "furthestAsteroid %A angleWithMostAsteroids %A asteroidsInLineOfFire %A matrixOfAngles %A" furthestAsteroid angleWithMostAsteroids asteroidsInLineOfFire matrixOfAngles
    printfn "%A %A" nextTarget matrixOfAngles

vaporise(".#....#####...#..
##...##.#####..##
##...#...#.#####.
..#.....X...###..
..#.#.....#....##",(8,3))

vaporise(".#..##.###...#######
##.############..##.
.#.######.########.#
.###.#######.####.#.
#####.##.#.##.###.##
..#####..#.#########
####################
#.####....###.#.#.##
##.#################
#####.##.###..####..
..######..##.#######
####.##.####...##..#
.#####..#.######.###
##...#.##########...
#.##########.#######
.####.#.###.###.#.##
....##.##.###..#####
.#.#.###########.###
#.#.#.#####.####.###
###.##.####.##.#..##",(11,13))

if not isDebug then vaporise("##.##..#.####...#.#.####
##.###..##.#######..##..
..######.###.#.##.######
.#######.####.##.#.###.#
..#...##.#.....#####..##
#..###.#...#..###.#..#..
###..#.##.####.#..##..##
.##.##....###.#..#....#.
########..#####..#######
##..#..##.#..##.#.#.#..#
##.#.##.######.#####....
###.##...#.##...#.######
###...##.####..##..#####
##.#...#.#.....######.##
.#...####..####.##...##.
#.#########..###..#.####
#.##..###.#.######.#####
##..##.##...####.#...##.
###...###.##.####.#.##..
####.#.....###..#.####.#
##.####..##.#.##..##.#.#
#####..#...####..##..#.#
.##.##.##...###.##...###
..###.########.#.###..#.",(14,17))

