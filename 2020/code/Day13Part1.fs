namespace AoC2020

open System

module Day13Part1 =
    let nextBus (inputLines:seq<string>) =

        let tryParseInt (str: string) =
            match Int64.TryParse(str) with
            | true, value -> Some value
            | false, _ -> None

        let startTime = 
            inputLines
            |> Seq.head
            |> tryParseInt
            |> Option.get
       
        let rec findNextDeparture elapsed increment =
            if elapsed >= startTime then
                (elapsed, increment)
            else
                findNextDeparture (elapsed + increment) increment

        let nextDeparture increment = findNextDeparture 0L increment

        (inputLines |> Seq.tail |> Seq.exactlyOne).Split(',')
        |> Seq.choose tryParseInt
        |> Seq.map nextDeparture
        |> Seq.minBy fst
        |> fun (el, inc) -> inc * (el - startTime)
