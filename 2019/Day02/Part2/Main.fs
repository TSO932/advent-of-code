let inputString = "99,99,99" // paste input values over the dummy values in the string

let mutable output = 0
for noun = 0 to 100 do
    for verb = 0 to 100 do
   
        let intcode = inputString.Split ',' |> Array.map System.Int32.Parse
        intcode.[1] <- noun
        intcode.[2] <- verb

        let mutable index = 0

        while intcode.[index] <> 99 do
            if intcode.[index] = 1 then
                intcode.[intcode.[index + 3]] <- intcode.[intcode.[index + 1]] + intcode.[intcode.[index + 2]]
            elif intcode.[index] = 2 then
                intcode.[intcode.[index + 3]] <- intcode.[intcode.[index + 1]] * intcode.[intcode.[index + 2]]

            index <- index + 4
        
            if intcode.[0] = 19690720 then
                printfn "%i" (noun * 100 + verb)