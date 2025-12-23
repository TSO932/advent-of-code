namespace _2025

open System

module Day10Part1 =

    let parseLine(input:string) =
        
        let parts =
            input.Split ' '

        let embracedSwitches =
            parts[0].ToCharArray()
        
        let switches =
            embracedSwitches[1 .. embracedSwitches.Length - 2]
            |> Array.map (fun c -> (c = '#'))

        let buttonMaker(buts:int[]) =

            buts
            |> Array.fold (fun (arr:bool[]) n ->
                
                 arr[n] <- true
                 arr
            ) (Array.zeroCreate<bool> switches.Length)

        let buttons =
            parts[1 .. parts.Length - 2]
            |> Array.map ((fun s -> s[1 .. s.Length - 2]) >> ((fun s -> s.Split ',') >> Array.map Int32.Parse))
            |> Array.map buttonMaker

        let rec findSwitches(switchOptions:bool[][], buttons:bool[][], idx:int) =
        
            if Array.contains switches switchOptions then
                idx
            else
                let newOptions =
                    switchOptions
                    |> Array.map (fun switchOption ->
                        
                        buttons
                        |> Array.map (fun button ->
                            
                            Array.zip switchOption button
                            |> Array.map (fun (s, b) -> (s || b) && not (s && b))
                        )
                    )
                    |> Array.concat
                    |> Array.distinct

                findSwitches(newOptions, buttons, idx + 1)

        findSwitches([|(Array.zeroCreate<bool> switches.Length)|], buttons, 0)
    
    let run(input:seq<string>) =
        input
        |> Seq.sumBy parseLine
