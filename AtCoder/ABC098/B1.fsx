@"https://atcoder.jp/contests/abc098/tasks/abc098_b
* 2 \leq N \leq 100
* |S| = N
* S は英小文字からなる"
#r "nuget: FsUnit"
open FsUnit

let N = 6
let S = "aabbca"
Seq.take 1 S |> set
Seq.skip 1 S |> set
Set.intersect (Seq.take 1 S |> set) (Seq.skip 1 S |> set)

let solve N S =
    [|0..(N-1)|]
    |> Seq.map (fun i ->
        Set.intersect (Seq.take i S |> set) (Seq.skip i S |> set)
        |> Set.count)
    |> Seq.max

let N = stdin.ReadLine() |> int
let S = stdin.ReadLine()
solve N S |> stdout.WriteLine

solve 6 "aabbca" |> should equal 2
solve 10 "aaaaaaaaaa" |> should equal 1
solve 45 "tgxgdqkyjzhyputjjtllptdfxocrylqfqjynmfbfucbir" |> should equal 9
