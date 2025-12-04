namespace _2025

module Day04Part2 =

    let runArray(matrix:char[,], count) =

        let newCount =
            matrix
            |> Array2D.mapi (fun v h _ -> Day04Part1.isAccessible(matrix, v, h))
            |> Seq.cast<bool>
            |> Seq.filter id
            |> Seq.length

        let remainingRolls =
            matrix
            |> Array2D.mapi (fun v h c -> if Day04Part1.isAccessible(matrix, v, h) then 'x' else c)

        (remainingRolls, count + newCount)


    let rec runRec(matrix:char[,], count) =

        let (remainingRolls, newCount) = runArray (matrix, count)

        if newCount = count then
            count
        else
            runRec(remainingRolls, newCount)


    let run(input:seq<string>) =

        let arrays = input |> Seq.map (Array.ofSeq) |> Array.ofSeq
        let matrix = Array2D.init arrays.Length arrays.[0].Length (fun i j -> arrays.[i].[j])

        runRec (matrix, 0)