namespace AoC2020

open System

module Day13Part2 =
    let nextBus (inputLines:seq<string>) =

        let tryParseInt (idx : int, str: string) =
            match Int64.TryParse(str) with
            | true, value -> Some (int64 idx, value)
            | false, _ -> None

        let nextTimestamp (step : int64, time : int64, offset : int64, bus : int64) =
        
            let rec itterateTimestamp (count) =
        
                let currentTime = time + (step * count)
                if (currentTime + offset) % bus = 0L then

                    (currentTime, step * bus)
                
                elif count >= 10000L then
                    failwith "recursive loop with 10,000 itterations"
                else
                    itterateTimestamp (count + 1L)
            
            itterateTimestamp 0L

        (inputLines |> Seq.tail |> Seq.exactlyOne).Split(',')
        |> Seq.indexed
        |> Seq.choose tryParseInt
        |> Seq.fold (fun (time, step) (offset, bus) -> nextTimestamp(step, time, offset, bus)) (0L, 1L)
        |> fst
