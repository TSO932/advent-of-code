namespace AoC2019

module Day11Part1 =
    let rotate(((x0, y0), currentDirection), turnInstruction) =
    
        let resetCircle(angle) =
            if   angle <  0   then angle + 360 * (1 + abs angle/360)
            elif angle >= 360 then angle - 360 * (angle/360)
            else angle
        
        let newDirection = 
            match turnInstruction with
            | 0 -> resetCircle(currentDirection - 90)
            | 1 -> resetCircle(currentDirection + 90)
            | _ -> invalidArg "Invalid turnInstruction input to rotate function. Expected 0 or 1" (string turnInstruction)
           
        let (x1, y1) =
            match newDirection with
            |   0 -> (x0, y0 - 1)
            |  90 -> (x0 + 1, y0)
            | 180 -> (x0, y0 + 1)
            | 270 -> (x0 - 1, y0)
            |   _ -> invalidArg "Invalid newDirection input to rotate function. Expected 0, 90, 180 or 270" (string newDirection)
            
        ((x1, y1), newDirection)
    
