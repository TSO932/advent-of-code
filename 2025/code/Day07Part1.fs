namespace _2025

open System

module Day07Part1 =

    let splitBeams((count, beamRow), deflectorRow) =

        let deflect((count, newBe:char[]), (pos, be, ro)) =

            if ro = '^' && (be = '|' || be = 'S') then
                newBe[pos - 1] <- '|'
                newBe[pos] <- '.'
                newBe[pos + 1] <- '|'
                (count + 1, newBe)
            else
                (count, newBe)

        (beamRow, deflectorRow)
        ||> Array.zip
        |> Array.mapi (fun i (b, d) -> (i, b, d))
        |> Array.fold (fun acc elem -> deflect(acc, elem))  (count, beamRow)

    let run (input:seq<string>) =

        let tachyonManifold = Seq.map Array.ofSeq input
        let startingBeamRow = Seq.head tachyonManifold

        tachyonManifold
        |> Seq.tail
        |> Seq.fold (fun acc deflectorRow -> splitBeams(acc, deflectorRow)) (0, startingBeamRow)
        |> fst