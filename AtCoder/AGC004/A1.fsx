@"https://atcoder.jp/contests/agc004/tasks/agc004_a"
#r "nuget: FsUnit"
open FsUnit

@"偶数が含まれる場合はその辺の中央で区切ればよく差はない.
奇数だけの場合はどうしても「分割の中央」が出る.
これが一番小さくなるのは長さが小さい二つを選んだとき.
はじめに入力をソートして下から二つの積を取ればいい."
let solve A B C =
    let xs = Array.sort [|A;B;C|]
    let prod = Array.fold (*) 1L xs
    if prod%2L=0L then 0L else xs.[0] * xs.[1]

let A,B,C = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1], x.[2])
solve A B C |> stdout.WriteLine

solve 3L 3L 3L |> should equal 9L
solve 2L 2L 4L |> should equal 0L
solve 5L 3L 5L |> should equal 15L
