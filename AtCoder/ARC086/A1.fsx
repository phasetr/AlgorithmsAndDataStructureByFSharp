@"https://atcoder.jp/contests/arc086/tasks/arc086_a
1 \leq K \leq N \leq 200000
1 \leq A_i \leq N
与えられる数値はすべて整数"
#r "nuget: FsUnit"
open FsUnit

let N,K,As = 5,2,[|1;1;2;2;5|]
let N,K,As = 10,3,[|5;1;3;2;4;1;1;2;3;4|]
@"countByして少ない数を多い数に書き換える.

問題は「整数をK個選んでそれらが書かれているボールの数を最大化する」とも言える.
選ぶ整数はできるだけそれが書かれているボールの数が多い順に選ぶ.
各整数に対して「その整数が書かれているボールは何個あるか」は簡単にわかる.
この個数分布をソートして大きいほうからK個の和をとれば書き換えないボールの個数の最大値がわかる.
あとはNからこの値を引く."
let solve N K As =
    As |> Array.countBy id
    |> fun Bs ->
        if Array.length Bs <= K then 0
        else
            Bs |> Array.sortByDescending snd
            |> Array.skip K
            |> Array.sumBy snd

let N, K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let As = stdin.ReadLine().Split() |> Array.map int
solve N K As |> stdout.WriteLine

solve 5 2 [|1;1;2;2;5|] |> should equal 1
solve 4 4 [|1;1;2;2;|] |> should equal 0
solve 10 3 [|5;1;3;2;4;1;1;2;3;4|] |> should equal 3
