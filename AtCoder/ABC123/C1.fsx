@"https://atcoder.jp/contests/abc123/tasks/abc123_c
- 1 \leq N, A, B, C, D, E \leq 10^{15}
- 入力中の値はすべて整数である。"
#r "nuget: FsUnit"
open FsUnit

@"一番小さい数がボトルネック."
ceil ((float 5) / (float 2)) |> int64
let Xa = [|5L;3L;2L;4L;3L;5L|]
let solve (Xa: array<int64>) =
    let min = Array.min Xa.[1..]
    let n = ceil (float Xa.[0] / float min) |> int64
    n+5L-1L
let Xa = [| for i in 1..6 do (stdin.ReadLine() |> int64) |]
solve Xa |> stdout.WriteLine

solve [|5L;3L;2L;4L;3L;5L|] |> should equal 7L
solve [|10L;123L;123L;123L;123L;123L|] |> should equal 5L
solve [|10000000007L;2L;3L;5L;7L;11L|] |> should equal 5000000008L
