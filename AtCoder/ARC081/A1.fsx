@"https://atcoder.jp/contests/arc081/tasks/arc081_a
4 \leq N \leq 10^5
1 \leq A_i \leq 10^9
A_i は整数"
#r "nuget: FsUnit"
open FsUnit

@"グループ化して2本以上あって大きい方から取る.
ペアができないときは0を返せばよい.
トップが4本以上ある場合はそれを使う."
let N,Aa = 6,[|3L;1L;2L;4L;2L;1L|]
let N,Aa = 4,[|1L;2L;3L;4L|]
let N,Aa = 6,[|1L;1L;4L;4L;4L;4L|]
let solve N Aa =
    Aa |> Array.countBy id
    |> Array.filter (fun (_,n) -> 2<=n)
    |> Array.sortByDescending fst
    |> fun a ->
        if Array.length a <= 1 then 0L
        elif 4 <= snd a.[0] then (fst a.[0])*(fst a.[0])
        else fst a.[0] * fst a.[1]

let N = stdin.ReadLine() |> int64
let Aa = stdin.ReadLine().Split() |> Array.map int64
solve N Aa |> stdout.WriteLine

solve 6 [|3L;1L;2L;4L;2L;1L|] |> should equal 2L
solve 4 [|1L;2L;3L;4L|] |> should equal 0L
solve 10 [|3L;3L;3L;3L;4L;4L;4L;5L;5L;5L|] |> should equal 20L
solve 6 [|1L;1L;4L;4L;4L;4L|] |> should equal 16L
