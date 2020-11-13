let runProgram (inputString:string, inputValue) =
    let intcode = inputString.Split ',' |> Array.map System.Int32.Parse

    let mutable index = 0
    let mutable inputOutput = inputValue

    while intcode.[index] <> 99 do
        
        let opcode = intcode.[index] - 100 * (intcode.[index] / 100)
        
        let immediateModeSettings =
            let digits = (string intcode.[index]).PadLeft(5, '0')
            digits.[0..digits.Length - 3] |> Seq.map (fun c -> if c = '1' then true else false) |> List.ofSeq |> List.rev
           
        if opcode = 1 then
            intcode.[intcode.[index + 3]] <- (if immediateModeSettings.[0] then intcode.[index + 1] else intcode.[intcode.[index + 1]]) + if immediateModeSettings.[1] then intcode.[index + 2] else intcode.[intcode.[index + 2]]
            index <- index + 4

        elif opcode = 2 then
            intcode.[intcode.[index + 3]] <- (if immediateModeSettings.[0] then intcode.[index + 1] else intcode.[intcode.[index + 1]]) * if immediateModeSettings.[1] then intcode.[index + 2] else intcode.[intcode.[index + 2]]
            index <- index + 4

        elif opcode = 3 then
            intcode.[intcode.[index + 1]] <- inputOutput
            index <- index + 2

        elif opcode = 4 then
            inputOutput <- if immediateModeSettings.[0] then intcode.[index + 1] else intcode.[intcode.[index + 1]]
            index <- index + 2

        elif opcode = 5 then
            index <- if (if immediateModeSettings.[0] then intcode.[index + 1] else intcode.[intcode.[index + 1]]) <> 0 then
                        if immediateModeSettings.[1] then intcode.[index + 2] else intcode.[intcode.[index + 2]]
                     else
                        index + 3
                
        elif opcode = 6 then
            index <- if (if immediateModeSettings.[0] then intcode.[index + 1] else intcode.[intcode.[index + 1]]) = 0 then
                        if immediateModeSettings.[1] then intcode.[index + 2] else intcode.[intcode.[index + 2]]
                     else
                        index + 3

        elif opcode = 7 then
            intcode.[intcode.[index + 3]] <- if (if immediateModeSettings.[0] then intcode.[index + 1] else intcode.[intcode.[index + 1]]) < (if immediateModeSettings.[1] then intcode.[index + 2] else intcode.[intcode.[index + 2]]) then 1 else 0
            index <- index + 4
            
        elif opcode = 8 then
            intcode.[intcode.[index + 3]] <- if (if immediateModeSettings.[0] then intcode.[index + 1] else intcode.[intcode.[index + 1]]) = (if immediateModeSettings.[1] then intcode.[index + 2] else intcode.[intcode.[index + 2]]) then 1 else 0
            index <- index + 4
            
    printfn "%i" inputOutput 

runProgram("3,9,8,9,10,9,4,9,99,-1,8",8) //example 1
runProgram("3,9,7,9,10,9,4,9,99,-1,8",8) //example 2
runProgram("3,3,1108,-1,8,3,4,3,99",8) //example 3
runProgram("3,3,1107,-1,8,3,4,3,99",8) //example 4
runProgram("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99",7) //example 5 - input less than 8
runProgram("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99",8) //example 5 - input equals 8
runProgram("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99",9) //example 5 - input greater than 9
runProgram("3,225,1,225,6,6,1100,1,238,225,104,0,1101,32,43,225,101,68,192,224,1001,224,-160,224,4,224,102,8,223,223,1001,224,2,224,1,223,224,223,1001,118,77,224,1001,224,-87,224,4,224,102,8,223,223,1001,224,6,224,1,223,224,223,1102,5,19,225,1102,74,50,224,101,-3700,224,224,4,224,1002,223,8,223,1001,224,1,224,1,223,224,223,1102,89,18,225,1002,14,72,224,1001,224,-3096,224,4,224,102,8,223,223,101,5,224,224,1,223,224,223,1101,34,53,225,1102,54,10,225,1,113,61,224,101,-39,224,224,4,224,102,8,223,223,101,2,224,224,1,223,224,223,1101,31,61,224,101,-92,224,224,4,224,102,8,223,223,1001,224,4,224,1,223,224,223,1102,75,18,225,102,48,87,224,101,-4272,224,224,4,224,102,8,223,223,1001,224,7,224,1,224,223,223,1101,23,92,225,2,165,218,224,101,-3675,224,224,4,224,1002,223,8,223,101,1,224,224,1,223,224,223,1102,8,49,225,4,223,99,0,0,0,677,0,0,0,0,0,0,0,0,0,0,0,1105,0,99999,1105,227,247,1105,1,99999,1005,227,99999,1005,0,256,1105,1,99999,1106,227,99999,1106,0,265,1105,1,99999,1006,0,99999,1006,227,274,1105,1,99999,1105,1,280,1105,1,99999,1,225,225,225,1101,294,0,0,105,1,0,1105,1,99999,1106,0,300,1105,1,99999,1,225,225,225,1101,314,0,0,106,0,0,1105,1,99999,1107,226,226,224,1002,223,2,223,1005,224,329,1001,223,1,223,1007,677,226,224,1002,223,2,223,1006,224,344,1001,223,1,223,108,677,226,224,102,2,223,223,1006,224,359,1001,223,1,223,7,226,226,224,1002,223,2,223,1005,224,374,101,1,223,223,107,677,677,224,1002,223,2,223,1006,224,389,1001,223,1,223,1007,677,677,224,1002,223,2,223,1006,224,404,1001,223,1,223,1107,677,226,224,1002,223,2,223,1005,224,419,1001,223,1,223,108,226,226,224,102,2,223,223,1006,224,434,1001,223,1,223,1108,226,677,224,1002,223,2,223,1006,224,449,1001,223,1,223,1108,677,226,224,102,2,223,223,1005,224,464,1001,223,1,223,107,226,226,224,102,2,223,223,1006,224,479,1001,223,1,223,1008,226,226,224,102,2,223,223,1005,224,494,101,1,223,223,7,677,226,224,1002,223,2,223,1005,224,509,101,1,223,223,8,226,677,224,1002,223,2,223,1006,224,524,1001,223,1,223,1007,226,226,224,1002,223,2,223,1006,224,539,101,1,223,223,1008,677,677,224,1002,223,2,223,1006,224,554,101,1,223,223,1108,677,677,224,102,2,223,223,1006,224,569,101,1,223,223,1107,226,677,224,102,2,223,223,1005,224,584,1001,223,1,223,8,677,226,224,1002,223,2,223,1006,224,599,101,1,223,223,1008,677,226,224,102,2,223,223,1006,224,614,1001,223,1,223,7,226,677,224,1002,223,2,223,1005,224,629,101,1,223,223,107,226,677,224,102,2,223,223,1005,224,644,101,1,223,223,8,677,677,224,102,2,223,223,1005,224,659,1001,223,1,223,108,677,677,224,1002,223,2,223,1005,224,674,101,1,223,223,4,223,99,226",5)
