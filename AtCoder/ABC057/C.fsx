(*
https://atcoder.jp/contests/abc057/tasks/abc057_c
https://qiita.com/drken/items/a14e9af0ca2d857dad23#問題-3-abc-057-c---digits-in-multiplication-300-点
cf. https://atcoder.jp/contests/abc057/submissions/11154569
*)
let digit = string >> Seq.length >> int64
let max64 (a: int64) (b: int64) = if a <= b then b else a
let min64 (a: int64) (b: int64) = if a <= b then a else b
let selectMin64 n a acc =
    if n % a = 0L then
        let newDigit = max64 (digit a) (digit (n / a))
        min64 acc newDigit
    else acc

let rec maxDivisorDigit n a acc =
    if n = 1L then 1L
    elif n <= a * a then selectMin64 n a acc
    else maxDivisorDigit n (a + 1L) (selectMin64 n a acc)

//for n in [| 1L; 2L; 10000L; 1000003L; 9876543210L |] do maxDivisorDigit n 1L n |> printfn "%i"

[<EntryPoint>]
let main argv =
    let n = stdin.ReadLine() |> int64
    maxDivisorDigit n 1L n |> printfn "%i"
    0
