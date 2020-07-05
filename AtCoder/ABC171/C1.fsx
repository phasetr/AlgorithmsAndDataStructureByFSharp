// https://atcoder.jp/contests/abc171/tasks/abc171_c
// https://atcoder.jp/contests/abc171/submissions/14569358
open System

let alphabets = [| 'a' .. 'z' |]

let rec solve x =
    if x <= 26L then
        [ alphabets.[x - 1L |> int] ]
    else
        let q = (x - 1L) / 26L
        let r = (x - 1L) % 26L |> int
        alphabets.[r] :: solve q

let judge =
    solve >> List.rev >> Array.ofList >> String.Concat

//let inputs = [| 1L; 2L; 26L; 27L; 123456789L |]
//for i in inputs do judge i |> printfn "%A"
// expected a; b; z; aa; jjddja

[<EntryPoint>]
let main argv =
    stdin.ReadLine() |> int64 |> judge |> printfn "%s"
    0
