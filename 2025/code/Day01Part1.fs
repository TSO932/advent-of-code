namespace _2025

open System

module Day01Part1 =
    let run (input: seq<string>) =

        input
        |> Seq.head
        |> fun name -> "Hello " + name + "!"