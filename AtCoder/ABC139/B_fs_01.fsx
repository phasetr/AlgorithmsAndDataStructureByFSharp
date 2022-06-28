// https://atcoder.jp/contests/abc139/tasks/abc139_b
// https://atcoder.jp/contests/abc139/submissions/12017708
// シンプルな解答
#r "nuget: FsUnit"
open FsUnit

let solve A B = (B - 1.0) / (A - 1.0) |> ceil

let A,B = stdin.ReadLine().Split() |> Array.map float |> (fun x -> x.[0], x.[1])
solve A B |> stdout.WriteLine

solve 4 10 |> should equal 3
solve 8 9 |> should equal 2
solve 8 8 |> should equal 1
