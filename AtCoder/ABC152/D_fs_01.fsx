// https://atcoder.jp/contests/abc152/submissions/11921499
let N = stdin.ReadLine() |> int

let rec firstDigit num =
    match num with
    | n when n < 10 -> n
    | n -> firstDigit (n / 10)

let table = Array2D.init 10 10 (fun _ _ -> 0)

for i in [ 1..N ] do
    table.[firstDigit i, i % 10] <- table.[firstDigit i, i % 10] + 1

let mutable result = 0

for i in [ 1..N ] do
    result <- result + table.[i % 10, firstDigit i]
result |> stdout.WriteLine
