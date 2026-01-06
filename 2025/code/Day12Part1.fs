namespace _2025

open System

module Day12Part1 =

    let run(input:seq<string>) =

        let processLine(inputLine:string) =

            let values =
                inputLine.Split([|' '; 'x'; ':'|], StringSplitOptions.RemoveEmptyEntries)
                |> Seq.map int
                |> Seq.toArray

            let area = values[0] * values[1]

            let numberOfPresents = 
                values[2..]
                |> Seq.sumBy (fun n -> n * 9)

            area >= numberOfPresents

        input
        |> Seq.filter (fun inputLine -> inputLine.Contains 'x')
        |> Seq.filter processLine
        |> Seq.length

   