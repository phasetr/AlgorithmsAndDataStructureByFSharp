// https://atcoder.jp/contests/abc068/submissions/2373088
let rec f n x = if x * 2 > n then x else f n (x * 2)

let N = stdin.ReadLine() |> int
f N 1 |> printfn "%d"
