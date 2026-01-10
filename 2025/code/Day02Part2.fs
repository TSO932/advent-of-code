namespace _2025

open System

module Day02Part2 =


    let isInvalid(range:int64) =

        let isInvalidForChunk(chunkSize) =
            
            let chunks =
                range.ToString()
                |> Seq.chunkBySize chunkSize
 
            chunks |> Seq.forall ((=) (Seq.head chunks))

        [ 1 .. int(range.ToString().Length / 2)]
        |> Seq.map (fun n -> isInvalidForChunk(n))
        |> Seq.exists ((=) true)


    let run(input) =
        input
        |> Day02Part1.parseLine
        |> Seq.collect Day02Part1.expandRange
        |> Seq.filter isInvalid
        |> Seq.sum

        