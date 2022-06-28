// https://atcoder.jp/contests/abc139/tasks/abc139_b
// https://atcoder.jp/contests/abc139/submissions/7253845
// 鮮やかで格好いい
#r "nuget: FsUnit"
open FsUnit

let solve a b =
    let f k = a + (a - 1) * (k - 1)
    Seq.initInfinite f |> Seq.findIndex (fun x -> x >= b)

let a,b = stdin.ReadLine().Split(' ') |> Array.map int |> (fun x -> x.[0],x.[1])
solve a b |> stdout.WriteLine

solve 4 10 |> should equal 3
solve 8 9 |> should equal 2
solve 8 8 |> should equal 1

