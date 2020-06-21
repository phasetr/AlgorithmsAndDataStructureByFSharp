// https://atcoder.jp/contests/abc139/tasks/abc139_b
// https://atcoder.jp/contests/abc139/submissions/12017708
// シンプルな解答

let [| A; B |] = stdin.ReadLine().Split() |> Array.map float

(B - 1.0) / (A - 1.0)
|> ceil
|> stdout.WriteLine
