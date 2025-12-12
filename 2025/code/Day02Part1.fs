namespace _2025

open System

module Day02Part1 =

    let parseLine(inputLine:string) =

        inputLine.Split ','
        |> Seq.map (fun s -> s.Split '-' |> Seq.map Int64.Parse)


    let expandRange(startEnd:seq<int64>) =

        let first = Seq.head startEnd
        let last = Seq.last startEnd

        [| first .. last |] |> Seq.ofArray


    let isInvalid(range:int64) =

        let divisor = int64(pown 10 (range.ToString().Length / 2))

        range / divisor = range % divisor
        

    let run(input) =
        input
        |> parseLine
        |> Seq.map expandRange
        |> Seq.concat
        |> Seq.filter isInvalid
        |> Seq.sum

        