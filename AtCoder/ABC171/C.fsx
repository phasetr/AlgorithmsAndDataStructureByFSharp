// https://atcoder.jp/contests/abc171/tasks/abc171_c
// 注意：バグっていて正しく動かない
// let maxNum = 1000000000000001L
// 26L ** 7 < maxNum < 26L ** 8
// 気分的には 26 進法を考えればいい

open System

let alphabets = [| 'a' .. 'z' |]
let ts = 26L // twenty six

let rec tsspan newRepn number =
    if number = 0L then
        newRepn
    else if number % ts = 0L then
        if number = ts then tsspan (26L :: newRepn) 0L else tsspan (26L :: newRepn) (number / ts)
    else
        tsspan ((number % ts) :: newRepn) (number / ts)

let judge number =
    tsspan [] number
    |> List.map (fun x -> alphabets.[x - 1L |> int])
    |> String.Concat

//let inputs = [| 1L; 2L; 26L; 27L; 123456789L |]
//for i in inputs do judge i |> printfn "%A"

[<EntryPoint>]
let main argv =
    stdin.ReadLine() |> int64 |> judge |> printfn "%s"
    0
