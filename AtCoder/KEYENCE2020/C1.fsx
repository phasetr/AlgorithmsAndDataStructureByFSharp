@"https://atcoder.jp/contests/keyence2020/tasks/keyence2020_c
1 \leq N \leq 10^5
0 \leq K \leq N
1 \leq S \leq 10^9
入力値はすべて整数である。"
#r "nuget: FsUnit"
open FsUnit

@"とにかく一つ作ればよい.
実際に部分列を作ろうと思うと大変だから,
各項がSの列を作れないか考える.
各A_iは 1 <= A_i <= S をみたしつつ
他の全ての部分和が絶対にSにならないようにするには,
S,S,S,...,S,S+1,S+1,...とすればよい.
ただし S=10^9 のとき S+1 にすることは許されない.
いま項数は最大で N<=10^5 だから,
S+1の代わりに1を取ればよい."
let solve N K S =
    if S = (pown 10 9) then Array.append (Array.replicate K S) (Array.replicate (N-K) 1)
    else Array.append (Array.replicate K S) (Array.replicate (N-K) (S+1))
let N,K,S = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1], x.[2])
solve N K S |> Array.map string |> String.concat " " |> stdout.WriteLine

// solve 4 2 3 |> should equal [|1;2;3;4|]
// solve 5 3 100 |> should equal [|50;50;50;30;70|]
