namespace AoC2020

module CommonFunctions =

    (*
    Adapted from 
    Source - https://stackoverflow.com/a/68611838
    Posted by Fyodor Soikin, modified by community. See post 'Timeline' for change history
    Retrieved 2026-08-08, License - CC BY-SA 4.0
    *)

    let splitByBlankLine lines =
        let step (blocks, currentBlock) s =
                match s with
                | "" -> (List.rev currentBlock :: blocks), []
                | _ -> blocks, s :: currentBlock

        let (blocks, lastBlock) = Array.fold step ([], []) (Seq.toArray lines)

        (
            if List.isEmpty lastBlock then
                blocks
            else
                List.rev lastBlock :: blocks )
        |> List.rev
