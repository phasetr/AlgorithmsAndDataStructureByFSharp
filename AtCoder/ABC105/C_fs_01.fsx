// https://atcoder.jp/contests/abc105/submissions/24199271
let N = stdin.ReadLine() |> int

let rec calc v num =
    if num = 0 then v
    else
        let nv = (if abs (num % 2) = 1 then "1" else "0" ) + v
        let nn = (num + if abs (num % 2) = 1 then -1 else 0) / -2
        calc nv nn

if N = 0 then "0"
else calc "" N
|> printfn "%s"
