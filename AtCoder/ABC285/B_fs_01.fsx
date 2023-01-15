// https://atcoder.jp/contests/abc285/submissions/38075323
let N = stdin.ReadLine() |> int
let S = stdin.ReadLine()

let rec loop i k =
    if k + i = N then
        k
    else
        if S.[k] <> S.[k+i] then
            loop i (k+1)
        else
            k

for i = 1 to N - 1 do
    loop i 0
    |> printfn "%d"
