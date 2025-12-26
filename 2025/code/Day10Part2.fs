namespace _2025

open System

module Day10Part2 =

    let parseLine(input:string) =
        
        let parts =
            input.Split ' '

        let embracedJoltages =
            parts[parts.Length - 1]
        
        let joltages  =
            embracedJoltages[1 .. embracedJoltages.Length - 2].Split ','
            |> Array.map Int32.Parse


        let buttonMaker(buts:int[]) =

            buts
            |> Array.fold (fun (arr:bool[]) n ->
                
                 arr[n] <- true
                 arr
            ) (Array.zeroCreate<bool> joltages.Length)

        let buttons =
            parts[1 .. parts.Length - 2]
            |> Array.map ((fun s -> s[1 .. s.Length - 2]) >> ((fun s -> s.Split ',') >> Array.map Int32.Parse))
            |> Array.map buttonMaker


        let isInRange(joltageOption:int[]) =

            Array.zip joltageOption joltages
            |> Array.map (fun (o, j) -> o > j)
            |> Array.exists id
            |> not

        let rec findSwitches(joltageOptions:int[][], buttons:bool[][], idx:int) =
        
            if Array.contains joltages joltageOptions then
                idx
            else
                let newOptions =
                    joltageOptions
                    |> Array.map (fun joltageOption ->
                        
                        buttons
                        |> Array.map (fun button ->
                            
                            Array.zip joltageOption button
                            |> Array.map (fun (j, b) -> j + (if b then 1 else 0))
                        )
                    )
                    |> Array.concat
                    |> Array.distinct
                    |> Array.filter isInRange


                printfn "%i %i" idx (newOptions.Length)

                findSwitches(newOptions, buttons, idx + 1)

        findSwitches([|(Array.zeroCreate<int> joltages.Length)|], buttons, 0)
    
    let run(input:seq<string>) =
        input
        |> Seq.sumBy parseLine
