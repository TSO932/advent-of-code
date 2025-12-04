namespace _2025

module Day04Part1 =

    let isAccessable (square:char[,], v:int, h:int) =

        if square[v, h] = '@' then
            square.[ v - 1 .. v + 1, h - 1 .. h + 1 ]
            |> Seq.cast<char>
            |> Seq.filter ((=) '@')
            |> Seq.length
            |> (>) 5
        else
            false


    let run(input:seq<string>) =

        let arrays = input |> Seq.map (Array.ofSeq) |> Array.ofSeq
        let matrix = Array2D.init arrays.Length arrays.[0].Length (fun i j -> arrays.[i].[j])

        matrix
        |> Array2D.mapi (fun v h _ -> isAccessable(matrix, v, h))
        |> Seq.cast<bool>
        |> Seq.filter id
        |> Seq.length