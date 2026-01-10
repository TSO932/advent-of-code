namespace _2025

open System
open System.Collections.Generic

module Day10Part2 =

    let parseLine(input:string) =

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
            |> Array.collect (fun combo -> [| combo; Array.append combo [|button|] |])

        let buttonCombos =
            parts[1 .. parts.Length - 2]
            |> Array.map ((fun s -> s[1 .. s.Length - 2]) >> ((fun s -> s.Split ',') >> Array.map Int32.Parse))
            |> Array.map buttonMaker        
            |> Array.fold (fun combos buttons ->  buttonCombinator( combos, buttons )) [| [|  |] |]

        let xor(a, b) =
            Array.zip a b
            |> Array.map (fun (s, b) -> (s || b) && not (s && b))

        let foldXor(combos) =
            combos
            |> Array.fold (fun acc combo -> xor (acc, combo)) (Array.zeroCreate<bool> currentJoltages.Length)

        let buttonComboXor =
            buttonCombos
            |> Seq.map (fun combo -> (combo, foldXor(combo)))
            |> dict
            |> Dictionary

        let cache = Dictionary<_,_>()

        let rec doProcess(currentJoltages) =

            if Array.sum currentJoltages = 0 then
                0
            else
                match cache.TryGetValue(currentJoltages) with
                | true, memorisedAnswer -> memorisedAnswer
                | _ -> 
                    let getButtonPresses(switches:bool[]) =

                        let foldRemainingJoltages(combos) =
                    
                            let reduceJoltages(acc, combo) =
                                (acc, combo)
                                ||> Array.zip
                                |> Array.map (fun (a, c) -> a - if c then 1 else 0)

                            combos
                            |> Array.fold (fun acc combo -> reduceJoltages(acc, combo)) currentJoltages
                            |> Array.map (fun n -> n/2)

                        let isNotNegative (viablePath) =
                            viablePath
                            |> fst
                            |> Array.exists ((>) 0)
                            |> not

                        let viablePaths =
                            buttonCombos
                            |> Array.filter (fun combo -> buttonComboXor[combo] = switches)
                            |> Array.map (fun combo -> (foldRemainingJoltages combo, Array.length combo))
                            |> Array.filter isNotNegative

                        if Array.length viablePaths = 0 then
                            9999999
                        else
                            viablePaths
                            |> Array.map (fun (remJolts, n) -> n + 2 * doProcess(remJolts))
                            |> Array.min

                    let buttonPresses =
                        currentJoltages
                        |> Array.map (fun n -> n % 2 = 1)
                        |> getButtonPresses

                    cache.Add(currentJoltages, buttonPresses)
                    buttonPresses

        doProcess currentJoltages
    
    let run(input:seq<string>) =
        input
        |> Seq.sumBy parseLine