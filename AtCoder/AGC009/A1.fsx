@"https://atcoder.jp/contests/agc009/tasks/agc009_a
- 入力はすべて整数である。
- 1 ≦ N ≦ 10^5
- 0 ≦ A_i ≦ 10^9(1 ≦ i ≦ N)
- 1 ≦ B_i ≦ 10^9(1 ≦ i ≦ N)"
#r "nuget: FsUnit"
open FsUnit

@"一番後ろから計算をはじめればよい.
B_i=1のときは加算する必要ない点に注意する."
let solve N Xa =
    (Xa,0L) ||> Array.foldBack (fun (ai,bi) acc ->
        if bi=1L then acc else acc+(bi-(acc+ai)%bi)%bi)
let N = stdin.ReadLine() |> int64
let Xa = [| for i in 1L..N do (stdin.ReadLine().Split() |> Array.map int64 |> fun x -> x.[0],x.[1]) |]
solve N Xa |> stdout.WriteLine

solve 3L [|(3L,5L);(2L,7L);(9L,4L)|] |> should equal 7L
solve 7L [|(3L,1L);(4L,1L);(5L,9L);(2L,6L);(5L,3L);(5L,8L);(9L,7L)|] |> should equal 22L
