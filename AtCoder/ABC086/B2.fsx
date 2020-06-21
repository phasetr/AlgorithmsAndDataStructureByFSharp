// https://atcoder.jp/contests/abc086/tasks/abc086_b
// https://atcoder.jp/contests/abc086/submissions/5886974
let rec maxSqrt n num =
    if n * n >= num then n else maxSqrt (n + 1) num

let inp =
    stdin.ReadLine().Split(' ')
    |> String.concat ""
    |> int

let maxN = maxSqrt 0 inp

(if maxN * maxN = inp then "Yes" else "No") |> printfn "%s"
