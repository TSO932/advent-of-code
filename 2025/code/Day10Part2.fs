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


                // printfn "%i %i" idx (newOptions.Length)

                findSwitches(newOptions, buttons, idx + 1)

        findSwitches([|(Array.zeroCreate<int> joltages.Length)|], buttons, 0)
    
    let run(input:seq<string>) =
        input
        |> Seq.sumBy parseLine

    let getParities(input:string) =
        
        input.ToCharArray()
        |> Array.map (fun c -> (c = '1' || c = '3' || c = '5' || c = '7' || c = '9'))

    let parseLine2(input:string) =
        
        let parts =
            input.Split ' '

        let embracedJoltages =
            parts[parts.Length - 1]
        
        let joltages  =
            embracedJoltages[1 .. embracedJoltages.Length - 2].Split ','
            |> Array.map (Int32.Parse >> (fun n -> n % 2 = 1))

        printfn "%A" joltages

        let buttonMaker(buts:int[]) =

            buts
            |> Array.fold (fun (arr:bool[]) n ->
                
                 arr[n] <- true
                 arr
            ) (Array.zeroCreate<bool> joltages.Length)

        let buttons =
            parts[1 .. parts.Length - 2]
            |> Array.map ((fun s -> s[1 .. s.Length - 2]) >> ((fun s -> s.Split ',') >> Array.map Int32.Parse))
            //|> Array.map buttonMaker

        printfn "%A" buttons
        

        let rec buttonOptions(butOpts:(int[]*bool)[][], buttons:int[][]) =

            if buttons.Length = 0 then
                butOpts
            else

                let nextButton = Array.head buttons
                let buttonOff = [| (nextButton, false) |]
                let buttonOn = [| (nextButton, true) |]

                let newButOpts =
                    butOpts
                    |> Array.map (fun butOpt -> [| Array.append butOpt buttonOff; Array.append butOpt buttonOn |])
                    |> Array.concat
                    
                buttonOptions(newButOpts, Array.tail buttons)

        // buttonOptions([| ([|-8; -90|], false); ([|-1; -66|], true)  |], buttons)
        buttonOptions([|[||]|], buttons)
        //|> Array.length