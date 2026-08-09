namespace AoC2020

module Day16Part2 =
    type Rule = { IsDeparture: bool; Ranges: seq<int64 * int64> }

    let parseMyTicket (inputLines:string seq) =
        inputLines
        |> Seq.exactlyOne
        |> fun line -> line.Split(',')
        |> Seq.map int64

    let private uniqueCombinationsOf combinations =
        combinations
        |> Seq.groupBy fst
        |> Seq.choose (fun (_, cols) -> cols |> Seq.tryExactlyOne)

    let rec private resolveMatches matched remaining =
        let unique = uniqueCombinationsOf remaining
        if Seq.isEmpty unique then
            matched
        else
            let foundColumns =
                unique
                |> Seq.map snd
                |> Set.ofSeq

            let remaining' =
                remaining
                |> Seq.filter (fun (_, col) -> not (Set.contains col foundColumns))

            resolveMatches (Seq.append matched unique) remaining'

    let calculate inputLines =
        let rules, myTicket, tickets = Day16Part1.splitBlocks inputLines

        let initialRuleSet =
            rules
            |> Day16Part1.parseValidityRules
            |> Seq.indexed

        let departureRules =
            initialRuleSet
            |> Seq.filter (fun (_, rule) -> rule.IsDeparture)
            |> Seq.map fst
      
        let indexRuleSet =
            initialRuleSet
            |> Seq.map (fun (idx, rule) -> (idx, rule.Ranges))
        
        let ruleSet =
            initialRuleSet
            |> Seq.map (fun (_, rule) -> rule.Ranges)

        let validTickets =
            tickets
            |> Seq.map (fun ticket -> ticket.Split(',') |> Seq.map int64)
            |> Seq.filter (fun ticketValues -> (Day16Part1.errorRate ticketValues (Seq.concat ruleSet)) = 0)

        let transposedTickets =
            validTickets
            |> Seq.transpose
            |> Seq.indexed

        let validCombinations =
            transposedTickets
            |> Seq.collect (fun (colIdx, colVals) ->
                indexRuleSet
                |> Seq.filter (fun (_ruleIdx, ruleRanges) ->
                    colVals |> Seq.forall (Day16Part1.isValidValue ruleRanges)
                )
                |> Seq.map (fun (ruleIdx, _) -> (ruleIdx, colIdx))
            )

        let departureColumns =
            resolveMatches Seq.empty validCombinations
            |> Seq.choose (fun (rule, col) ->
                if departureRules |> Seq.contains rule then Some col else None
            )

        let myValues =
            myTicket
            |> parseMyTicket
            |> Seq.toArray
        
        departureColumns
        |> Seq.fold (fun acc col -> acc * myValues[col]) 1L