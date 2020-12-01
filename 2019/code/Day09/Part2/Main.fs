    let runProgram (inputString:string, inputVals:int64 array) =

        let isDebug = false
        let isShowAllOutputs = true
        
        let intcodes = inputVals |> Array.map (fun s -> Array.concat [|inputString.Split ',' |> Array.map System.Int64.Parse; (Array.zeroCreate 1000)|]) 
        let inputValues = inputVals |> Array.map (fun x -> [|x|])
        inputValues.[0] <- Array.append inputValues.[0] [|0L|]
        
        let indices = Array.zeroCreate inputValues.Length
        let inputIndices = Array.zeroCreate inputValues.Length
        let outputValues = Array.zeroCreate inputValues.Length
        let relativeBases = Array.zeroCreate inputValues.Length
        let mutable currentMachine = 0
        
        while intcodes.[currentMachine].[indices.[currentMachine]] <> 99L do
        
            let mutable index = indices.[currentMachine]
            let intcode = intcodes.[currentMachine]
     
            let opcode = intcode.[index] - 100L * (intcode.[index] / 100L)
            
            if isDebug then printfn "SRT index %i opcode %i machine %i base %i output %i intcode.[index]... %i %i %i %i" index opcode currentMachine relativeBases.[currentMachine] outputValues.[currentMachine] intcode.[index] intcode.[index + 1] intcode.[index + 2] intcode.[index + 3]
            
            let modeSettings =
                let digits = (string intcode.[index]).PadLeft(5, '0')
                digits.[0..digits.Length - 3] |> List.ofSeq |> List.rev
            
            let indexRef = ref index
            let relativeBase = ref relativeBases.[currentMachine]
            
            let getParameterValue(position:int) =
                if modeSettings.[position - 1] = '0' then
                    intcode.[int intcode.[!indexRef + position]]  //positional mode
                elif modeSettings.[position - 1] = '1' then
                    intcode.[!indexRef + position]  //immediate mode
                else
                    intcode.[!relativeBase + int intcode.[!indexRef + position]]  //relative mode
                
            let getIndexForWrite(position:int) =
                if modeSettings.[position - 1] = '0' then
                    int intcode.[!indexRef + position]  //positional mode
                else
                    !relativeBase + int intcode.[!indexRef + position]  //relative mode
                    
            if opcode = 1L then
                intcode.[getIndexForWrite(3)] <- getParameterValue(1) + getParameterValue(2)
                index <- index + 4

            elif opcode = 2L then
                intcode.[getIndexForWrite(3)] <- getParameterValue(1) * getParameterValue(2)
                index <- index + 4

            elif opcode = 3L then
                intcode.[getIndexForWrite(1)] <- inputValues.[currentMachine].[inputIndices.[currentMachine]]
                inputIndices.[currentMachine] <- inputIndices.[currentMachine] + 1
                index <- index + 2

            elif opcode = 4L then
                outputValues.[currentMachine] <- getParameterValue(1)
                index <- index + 2

            elif opcode = 5L then
                index <- if getParameterValue(1) <> 0L then (getParameterValue(2) |> int)
                         else index + 3
                    
            elif opcode = 6L then
                index <- if getParameterValue(1) = 0L then (getParameterValue(2) |> int)
                         else index + 3

            elif opcode = 7L then
                intcode.[getIndexForWrite(3)] <- if getParameterValue(1) < getParameterValue(2) then 1L else 0L
                index <- index + 4
                
            elif opcode = 8L then
                intcode.[getIndexForWrite(3)] <- if getParameterValue(1) = getParameterValue(2) then 1L else 0L
                index <- index + 4
                
            elif opcode = 9L then
                relativeBases.[currentMachine] <- relativeBases.[currentMachine] + (getParameterValue(1) |> int)
                index <- index + 2
                
            indices.[currentMachine] <- index
            intcodes.[currentMachine] <- intcode
            
            if opcode = 4L then
                if isShowAllOutputs then printfn "machine %i index %i output %i" currentMachine index outputValues.[currentMachine]
                
                let oldMachine = currentMachine
                currentMachine <- if currentMachine = inputValues.Length - 1 then 0 else currentMachine + 1
                inputValues.[currentMachine] <- Array.append inputValues.[currentMachine] [|outputValues.[oldMachine]|]
            
            if isDebug then printfn "END index %i opcode %i machine %i base %i output %i intcode %A" index opcode currentMachine relativeBases.[currentMachine] outputValues.[currentMachine] intcode
            
        outputValues.[inputValues.Length - 1]
            
    printfn "%i" (runProgram("109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99",[|0L|])) //example 1
    printfn "%i" (runProgram("1102,34915192,34915192,7,4,7,99,0",[|0L|])) //example 2
    printfn "%i" (runProgram("104,1125899906842624,99",[|0L|]))//example3
    let inputString = "1102,34463338,34463338,63,1007,63,34463338,63,1005,63,53,1101,0,3,1000,109,988,209,12,9,1000,209,6,209,3,203,0,1008,1000,1,63,1005,63,65,1008,1000,2,63,1005,63,904,1008,1000,0,63,1005,63,58,4,25,104,0,99,4,0,104,0,99,4,17,104,0,99,0,0,1101,0,30,1016,1101,37,0,1005,1101,362,0,1023,1101,0,20,1014,1101,39,0,1013,1102,34,1,1007,1101,682,0,1027,1102,664,1,1025,1102,1,655,1028,1101,0,26,1002,1102,1,38,1015,1101,669,0,1024,1101,0,28,1017,1102,1,21,1000,1101,0,27,1012,1102,1,29,1008,1102,1,23,1019,1101,0,24,1011,1101,685,0,1026,1102,646,1,1029,1102,1,369,1022,1101,0,31,1003,1102,1,36,1001,1101,0,0,1020,1102,1,35,1009,1101,32,0,1010,1101,0,1,1021,1102,33,1,1004,1101,22,0,1006,1102,1,25,1018,109,14,1205,6,197,1001,64,1,64,1105,1,199,4,187,1002,64,2,64,109,-4,21107,40,39,9,1005,1019,219,1001,64,1,64,1105,1,221,4,205,1002,64,2,64,109,9,1206,1,239,4,227,1001,64,1,64,1106,0,239,1002,64,2,64,109,-9,2101,0,-8,63,1008,63,26,63,1005,63,261,4,245,1106,0,265,1001,64,1,64,1002,64,2,64,109,-6,2108,37,1,63,1005,63,287,4,271,1001,64,1,64,1105,1,287,1002,64,2,64,109,15,21108,41,44,-2,1005,1017,307,1001,64,1,64,1106,0,309,4,293,1002,64,2,64,109,-16,1207,1,34,63,1005,63,327,4,315,1105,1,331,1001,64,1,64,1002,64,2,64,109,8,1208,-9,29,63,1005,63,347,1106,0,353,4,337,1001,64,1,64,1002,64,2,64,109,4,2105,1,8,1001,64,1,64,1105,1,371,4,359,1002,64,2,64,109,-22,1201,9,0,63,1008,63,27,63,1005,63,391,1106,0,397,4,377,1001,64,1,64,1002,64,2,64,109,18,21107,42,43,5,1005,1016,415,4,403,1106,0,419,1001,64,1,64,1002,64,2,64,109,-8,1201,2,0,63,1008,63,37,63,1005,63,441,4,425,1105,1,445,1001,64,1,64,1002,64,2,64,109,27,1205,-9,463,4,451,1001,64,1,64,1106,0,463,1002,64,2,64,109,-1,1206,-8,475,1105,1,481,4,469,1001,64,1,64,1002,64,2,64,109,-6,21101,43,0,-8,1008,1015,43,63,1005,63,507,4,487,1001,64,1,64,1106,0,507,1002,64,2,64,109,-15,2101,0,-3,63,1008,63,35,63,1005,63,531,1001,64,1,64,1106,0,533,4,513,1002,64,2,64,109,-2,2102,1,-6,63,1008,63,18,63,1005,63,553,1105,1,559,4,539,1001,64,1,64,1002,64,2,64,109,7,21102,44,1,3,1008,1016,44,63,1005,63,581,4,565,1105,1,585,1001,64,1,64,1002,64,2,64,109,-11,1202,7,1,63,1008,63,34,63,1005,63,609,1001,64,1,64,1105,1,611,4,591,1002,64,2,64,109,6,1202,1,1,63,1008,63,35,63,1005,63,637,4,617,1001,64,1,64,1106,0,637,1002,64,2,64,109,16,2106,0,4,4,643,1001,64,1,64,1106,0,655,1002,64,2,64,109,-1,2105,1,1,4,661,1106,0,673,1001,64,1,64,1002,64,2,64,109,5,2106,0,-1,1105,1,691,4,679,1001,64,1,64,1002,64,2,64,109,-24,1208,-2,26,63,1005,63,709,4,697,1105,1,713,1001,64,1,64,1002,64,2,64,109,-10,2102,1,6,63,1008,63,21,63,1005,63,735,4,719,1105,1,739,1001,64,1,64,1002,64,2,64,109,25,21108,45,45,-9,1005,1010,757,4,745,1106,0,761,1001,64,1,64,1002,64,2,64,109,-12,1207,-7,20,63,1005,63,777,1106,0,783,4,767,1001,64,1,64,1002,64,2,64,109,-13,2108,22,6,63,1005,63,799,1106,0,805,4,789,1001,64,1,64,1002,64,2,64,109,17,21102,46,1,0,1008,1011,45,63,1005,63,825,1105,1,831,4,811,1001,64,1,64,1002,64,2,64,109,-6,2107,21,1,63,1005,63,849,4,837,1105,1,853,1001,64,1,64,1002,64,2,64,109,-3,2107,27,0,63,1005,63,873,1001,64,1,64,1105,1,875,4,859,1002,64,2,64,109,12,21101,47,0,0,1008,1014,48,63,1005,63,899,1001,64,1,64,1105,1,901,4,881,4,64,99,21102,27,1,1,21101,0,915,0,1105,1,922,21201,1,42931,1,204,1,99,109,3,1207,-2,3,63,1005,63,964,21201,-2,-1,1,21101,942,0,0,1106,0,922,21202,1,1,-1,21201,-2,-3,1,21102,1,957,0,1106,0,922,22201,1,-1,-2,1106,0,968,22101,0,-2,-2,109,-3,2106,0,0"
    //Part 1 - test mode
    printfn "%i" (runProgram(inputString,[|1L|]))
    //Part 2 - sensor boost mode
    printfn "%i" (runProgram(inputString,[|2L|]))