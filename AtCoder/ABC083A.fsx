// これは何の問題かわからなくなったのでわかったら記録し、ファイル名も変える
// Practice https://atcoder.jp/contests/practice/tasks/practice_1#C#
// https://beta.atcoder.jp/contests/abc086/tasks/abc086_a
open System

let s = @"1
2 3
s"

let a =
    s.Split("\n")
    |> Array.collect (fun x -> x.Split ' ')

printfn "%d %s" (a.[0..2] |> Array.sumBy int) a.[3]
