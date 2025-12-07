namespace _2025

open System

module Day07Part2 =

    let splitBeams(beamRowN, deflectorRow) =

        let beamRow = fst beamRowN
        let deflect(newBe:char[], (pos, be, ro)) =

            if ro = '^' && (be = '|' || be = 'S') then
                let altBe = Array.copy newBe
                altBe.[pos - 1] <- '|'
                altBe.[pos] <- '.'
                newBe.[pos] <- '.'
                newBe.[pos + 1] <- '|'
                [ altBe ; newBe ]
            else
                [ newBe ]

        let deflect2 (paths, elem) =
            paths
            |> Seq.map (fun p -> deflect(p, elem) )
            |> Seq.concat

        (beamRow, deflectorRow)
        ||> Array.zip
        |> Array.mapi (fun i (b, d) -> (i, b, d))
        |> Array.fold (fun acc elem -> deflect2(acc, elem))  ([ beamRow ])
        |> Seq.map (fun outp -> (outp, snd beamRowN))

    let splitBeamWorlds (beamRows, deflectorRow) =

        beamRows
        |> Seq.map (fun beamRow -> splitBeams(beamRow, deflectorRow))
        |> Seq.concat
        |> Seq.groupBy fst
        |> Seq.map (fun (a, b) -> (a, b |> Seq.map snd |> Seq.sum))
            
    let run (input:seq<string>) =

        let tachyonManifold = Seq.map Array.ofSeq input
        let startingBeamRow = Seq.head tachyonManifold

        tachyonManifold
        |> Seq.tail
        |> Seq.fold (fun acc deflectorRow -> splitBeamWorlds(acc, deflectorRow)) [ (startingBeamRow, 1) ]
        |> Seq.map snd
        |> Seq.sum