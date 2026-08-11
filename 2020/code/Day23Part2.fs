namespace AoC2020

open System
open System.Collections.Generic

module Day23Part2 =

    let rotateCircle (currentPosition:int64) (cupCircle:int64[]) =
        let idx = int currentPosition
        Array.append cupCircle.[idx..(cupCircle.Length - 1)]
                     cupCircle.[0..(idx - 1)]

    let rotateCircleByOne (cupCircle:int64[]) = rotateCircle 1L cupCircle

    let play (inputData:string) =

        let start = inputData |> Array.ofSeq |> Array.map (string >> int64)
        let circle = Array.append start (seq { (int64 start.Length + 1L) .. 1000000L } |> Array.ofSeq)
        let rotatedCircle = rotateCircleByOne circle

        let cupMap = Dictionary<int64,int64>()
        let cupMapBack = Dictionary<int64,int64>()

        let populateArray x rotX =
            cupMap.Add(x, rotX)
            cupMapBack.Add(rotX, x)

        (circle, rotatedCircle) ||> Array.iter2 populateArray

        let currentPosition = Seq.head start
        let minLabel = Seq.min circle
        let maxLabel = Seq.max circle

        let rec playRound (iterations:int) (currentPosition:int64) =

            if iterations = 0 then
                let netCup = cupMap[1L]
                netCup * (cupMap[netCup])
            else
                let nextCup1 = cupMap[currentPosition]
                let nextCup2 = cupMap[nextCup1]
                let nextCup3 = cupMap[nextCup2]
                let nextCup4 = cupMap[nextCup3]
                cupMap[currentPosition] <- nextCup4
                cupMapBack[nextCup4] <- currentPosition

                let rec getDestinationPosition cup =

                    let c = cup - 1L
                
                    let candidate =
                        if c < minLabel then
                            maxLabel
                        else
                            c

                    if  candidate = nextCup1 || candidate = nextCup2 || candidate = nextCup3 then
                        getDestinationPosition candidate
                    else
                        candidate

                let destinationCup = getDestinationPosition currentPosition
                let afterDest = cupMap[destinationCup]

                cupMap[destinationCup] <- nextCup1
                cupMap[nextCup3] <- afterDest
                cupMapBack[nextCup1] <- destinationCup
                cupMapBack[afterDest] <- nextCup3

                playRound (iterations - 1) cupMap[currentPosition]

        playRound 10000000 currentPosition

    let playGame (inputData:string) = play inputData
