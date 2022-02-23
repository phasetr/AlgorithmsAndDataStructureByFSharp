@"https://atcoder.jp/contests/abc159/tasks/abc159_d
3 \leq N \leq 2 \times 10^5
1 \leq A_i \leq N
入力はすべて整数である。"
#r "nuget: FsUnit"
open FsUnit

@"i=1,2,...,N に対して ci := #{1 ≤ j ≤ N|A_j = i} とする.
k(1 ≤ k ≤ N)を固定したとき,
k に対する問題の答えは次の二数の差.
- N個のボールから書かれている整数が等しい異なる2つのボールを選び出す方法の数
- k番目のボールを除いたN−1個のボールからk番目のボールと同じ整数が書かれたボールを選び出す方法の数
前者は sum (comb ci 2) で後者は c_{A_k} − 1."
let solve N As =
    let inline comb2 n = n * (n-1L) / 2L
    let Cs =
        As |> Array.countBy id
        |> Array.map (fun (k,v) -> (k, int64 v))
        |> Array.fold (fun state (k,v) ->
            Array.set state (k-1) v
            state) (Array.create N 0L)
    let sum = Cs |> Array.sumBy comb2
    As |> Array.map (fun n -> sum - (Cs.[n-1] - 1L))

let N = stdin.ReadLine() |> int
let As = stdin.ReadLine().Split() |> Array.map int
solve N As |> Array.map string |> String.concat "\n" |> stdout.WriteLine

solve 5 [|1;1;2;1;2|] |> should equal [|2;2;3;2;3|]
solve 4 [|1;2;3;4|] |> should equal [|0;0;0;0|]
solve 5 [|3;3;3;3;3|] |> should equal [|6;6;6;6;6|]
solve 8 [|1;2;1;4;2;1;4;1|] |> should equal [|5;7;5;7;7;5;7;5|]
