namespace _2025

open System

module Day07Part2 =

    let splitBeams((count, beamRow), deflectorRow) =

        let deflect((count, newBe:char[]), (pos, be, ro)) =

            if ro = '^' && (be = '|' || be = 'S') then
                let altBe = Array.copy newBe
                altBe.[pos - 1] <- '|'
                altBe.[pos] <- '.'
                newBe.[pos] <- '.'
                newBe.[pos + 1] <- '|'
                [ (count + 1, altBe) ; (count + 1, newBe) ]
            else
                [ (count, newBe) ]

        let deflect2 (paths, elem) =
            paths
            |> Seq.map (fun p -> deflect(p, elem) )
            |> Seq.concat

        (beamRow, deflectorRow)
        ||> Array.zip
        |> Array.mapi (fun i (b, d) -> (i, b, d))
        |> Array.fold (fun acc elem -> deflect2(acc, elem))  ([ count, beamRow ])

    let splitBeamWorlds (beamRows, deflectorRow) =

        beamRows
        |> Seq.map (fun beamRow -> splitBeams(beamRow, deflectorRow))
        |> Seq.concat

    let run (input:seq<string>) =

        let tachyonManifold = Seq.map Array.ofSeq input
        let startingBeamRow = Seq.head tachyonManifold

        tachyonManifold
        |> Seq.tail
        |> Seq.fold (fun acc deflectorRow -> splitBeamWorlds(acc, deflectorRow)) [ (0, startingBeamRow) ]
        |> Seq.length