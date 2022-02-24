@"https://atcoder.jp/contests/agc013/tasks/agc013_a
1 \leq N \leq 10^5
1 \leq A_i \leq 10^9
A_i は全て整数である"
#r "nuget: FsUnit"
open FsUnit

let N,Aa = 6,[|1;2;3;2;2;1|]
let N,Aa = 9,[|1;2;1;2;1;2;1;2;1|]
@"pairwiseして差を取り, その符号の反転のところを切り出す."
let solve N (Aa: array<int>) =
    let f (bsgn, acc) sgn =
        match (bsgn, sgn) with
        | (1,-1) | (-1,1) -> (0, acc+1)
        | (0, sgn)        -> (sgn, acc)
        | _               -> (bsgn, acc)
    // Array.map2だと要素数が合わないと怒られる
    Seq.map2 (-) (Aa.[1..]) Aa
    |> Seq.map sign
    |> Seq.fold f (0,1)
    |> snd

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> stdout.WriteLine

solve 6 [|1;2;3;2;2;1|] |> should equal 2
solve 9 [|1;2;1;2;1;2;1;2;1|] |> should equal 5
solve 7 [|1;2;3;2;1;999999999;1000000000|] |> should equal 3
