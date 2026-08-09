namespace AoC2020

module Day16Part1 =
    type Rule = { IsDeparture: bool; Ranges: seq<int * int> }

    let splitBlocks inputLines =
        match inputLines |> CommonFunctions.splitByBlankLine with
        | [rules; myTicket; tickets] -> rules, Seq.tail myTicket, Seq.tail tickets
        | _ -> failwith "Expected three sections of input data."

    let parseRange (range:string) =
        match range.Split('-') with
        | [| low; high |] ->
            match System.Int32.TryParse low, System.Int32.TryParse high with
            | (true, lowValue), (true, highValue) -> lowValue, highValue
            | _ -> failwith "Expected numeric values."
        | _ -> failwith "Expected hyphen-seperated pairs of values."

    let parseValidityRule (inputLine:string) =
        let chunks =
            inputLine.Split([|": "; " or "|], System.StringSplitOptions.None)

        { IsDeparture = chunks[0].Contains("departure")
          Ranges = chunks |> Array.skip 1 |> Array.map parseRange |> Seq.ofArray }

    let parseValidityRules inputLines =
        inputLines |> Seq.map parseValidityRule

    let parseMyTicket (inputLines:string seq) =
        inputLines
        |> Seq.exactlyOne
        |> fun line -> line.Split(',')
        |> Seq.map int

    let isValidValue ruleSet n =
        ruleSet |> Seq.exists (fun (nmin, nmax) -> n >= nmin && n <= nmax)

    let errorRate ticketValues ruleSet =
        ticketValues
        |> Seq.filter (isValidValue ruleSet >> not)
        |> Seq.sum

    let sumErrors inputLines =
        let rules, _, tickets = splitBlocks inputLines

        let ruleSet =
            rules
            |> parseValidityRules
            |> Seq.collect (fun rule -> rule.Ranges)

        let ticketValues =
            tickets
            |> Seq.collect (fun ticket -> ticket.Split(',') |> Seq.map int)

        errorRate ticketValues ruleSet