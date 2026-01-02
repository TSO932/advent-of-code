namespace _2025

open System

module Day10Part2 =

    let parseLine(input:string) =
        
        printfn "%s" input

        let parts = input.Split ' '

        let currentJoltages =
            let input = parts[parts.Length - 1]

            input[1 .. input.Length - 2].Split ','
            |> Array.map Int32.Parse

        let buttonMaker(buts:int[]) =

            buts
            |> Array.fold (fun (arr:bool[]) n ->
                
                arr[n] <- true
                arr
            ) (Array.zeroCreate<bool> currentJoltages.Length)

        let buttonCombinator(combos, button) =
            combos
            |> Array.map (fun combo -> [| combo; Array.append combo [|button|] |])
            |> Array.concat

        let buttonCombos =
            parts[1 .. parts.Length - 2]
            |> Array.map ((fun s -> s[1 .. s.Length - 2]) >> ((fun s -> s.Split ',') >> Array.map Int32.Parse))
            |> Array.map buttonMaker        
            |> Array.fold (fun combos buttons ->  buttonCombinator( combos, buttons )) [| [|  |] |]


        let rec doProcess(currentJoltages) =

            if Array.sum currentJoltages = 0 then
                0
            else
                let findJoltage(switches:bool[]) =

                    let xor(a, b) =
                        Array.zip a b
                        |> Array.map (fun (s, b) -> (s || b) && not (s && b))

                    let foldXor(combos) =
                        combos
                        |> Array.fold (fun acc combo -> xor (acc, combo)) (Array.zeroCreate<bool> switches.Length)

                    let foldRemainingJoltages(combos) =

                        let reduceJoltages(acc, combo) =
                            (acc, combo)
                            ||> Array.zip
                            |> Array.map (fun (a, c) -> max 0 (a - if c then 1 else 0))

                        combos
                        |> Array.fold (fun acc combo -> reduceJoltages(acc, combo)) currentJoltages
                        |> Array.map (fun n -> n/2)

                    let clouseau =
                        buttonCombos
                        |> Array.map (fun combo -> (foldXor combo, foldRemainingJoltages combo, Array.length combo))
                        |> Array.filter (fun ( combo, _, _ ) -> combo = switches)|> Array.map (fun (_, remJolts, n) -> n + 2 * doProcess(remJolts))

                    if Array.length clouseau = 0 then
                        2
                    else
                        Array.min clouseau

                currentJoltages
                |> Array.map (fun n -> n % 2 = 1)
                |> findJoltage

        doProcess currentJoltages
    
    let run(input:seq<string>) =
        input
        |> Seq.sumBy parseLine