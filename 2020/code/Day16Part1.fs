namespace AoC2020

open System.Collections.Generic

module Day16Part1 =
    let splitBlocks inputLines =

        let blocks =
            inputLines
            |> CommonFunctions.splitByBlankLine
            |> List.map Seq.tail

        (blocks[0], blocks[1], blocks[2])

    let parseValidityRule (inputLine:string) =

        let chunks =
            inputLine.Split([|": "; " or "|], System.StringSplitOptions.None)

        let isDeparture = (Seq.head chunks).Contains("departure")

        let getRange(range:string) =
            let parts = range.Split('-')
            (int parts.[0], int parts.[1])

        let ranges =
            chunks
            |> Seq.tail
            |> Seq.map getRange

        (isDeparture, ranges)
        
    let parseValidityRules inputLines =
        inputLines |> Seq.map parseValidityRule

    let parseMyTicket (inputLines : string seq) =
        (Seq.head inputLines).Split(',')
        |> Seq.map int

    // seq {validityInstuctions; myTicket; discardedTickets}