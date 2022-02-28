@"https://atcoder.jp/contests/abc117/tasks/abc117_c
入力はすべて整数である。
1 \leq N \leq 10^5
1 \leq M \leq 10^5
-10^5 \leq X_i \leq 10^5
X_1, X_2, ..., X_M は全て異なる。"
#r "nuget: FsUnit"
open FsUnit

@"もしM<=Nならはじめからそこに置けばいいから初手で終わる.
あとは差が最小になるN個のグループにわければよい.
まずはソートするか?

ソートしたあと前後のペアを作り, その差を取る.
差についてソートして大きいところからコマを置く.
残りはコマを動かして制圧するために和を取る."
let solve N M Xs =
    if M<=N then 0
    else
        Array.sort Xs
        |> Array.pairwise
        |> Array.map (fun (a,b) -> b-a)
        |> Array.sort
        |> Array.take (M-N)
        |> Array.sum
let N, M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Xs = stdin.ReadLine().Split() |> Array.map int
solve N M Xs |> stdout.WriteLine

solve 2 5 [|10;12;1;2;14|] |> should equal 5
solve 3 7 [|-10;-3;0;9;-100;2;17|] |> should equal 19
solve 100 1 [|-100000|] |> should equal 0
