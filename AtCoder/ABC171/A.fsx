// https://atcoder.jp/contests/abc171/tasks/abc171_a
open System

[<EntryPoint>]
let main argv =
    stdin.ReadLine() |> char
    |> fun x -> if Char.IsUpper x then "A" else "a"
    |> printfn "%s"
    0
