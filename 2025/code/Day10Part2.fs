namespace _2025

open System

module Day10Part2 =

    let parseLine(input:string) =
        
        let parts = input.Split ' '
        
        let currentJoltages =
            let input = parts[parts.Length - 1]

            input[1 .. input.Length - 2].Split ','
            |> Array.map Int32.Parse

        let rec doProcess(currentJoltages) = 

            if Array.sum currentJoltages = 0 then
                0
            else
                let currentParities =
                    currentJoltages
                    |> Array.map (fun n -> n % 2 = 1)

                let reducedJoltages =
                    currentJoltages
                    |> Array.map (fun n -> n / 2)

                let findJoltage(switches:bool[]) =

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

                    let buttonCombinator(combos, button) =
                        combos
                        |> Array.map (fun combo -> [| combo; Array.append combo [|button|] |])
                        |> Array.concat

                    let xor(a, b) =
                        Array.zip a b
                        |> Array.map (fun (s, b) -> (s || b) && not (s && b))

                    let foldXor(combos) =
                        combos
                        |> Array.fold (fun acc combo -> xor (acc, combo)) (Array.zeroCreate<bool> switches.Length)

                    let buttonCombinations =
                        buttons
                        |> Array.fold (fun combos buttons ->  buttonCombinator( combos, buttons )) [| [|  |] |]
                        |> Array.map (fun combo -> (foldXor combo, Array.length combo))
                        |> Array.filter (fun ( combo, _ ) -> combo = switches)
                        |> Array.minBy snd
                        |> snd

                    buttonCombinations

                findJoltage currentParities

        doProcess currentJoltages
    
    let run(input:seq<string>) =
        input
        |> Seq.sumBy parseLine