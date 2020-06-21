// https://atcoder.jp/contests/abc139/tasks/abc139_b
// https://atcoder.jp/contests/abc139/submissions/7253845
// 鮮やかで格好いい

let [ a; b ] = stdin.ReadLine().Split(' ')
let f k = a + (a - 1) * (k - 1)

Seq.initInfinite f
|> Seq.findIndex (fun x -> x >= b)
|> printfn "%i"
