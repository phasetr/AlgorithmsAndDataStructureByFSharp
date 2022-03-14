@"https://atcoder.jp/contests/abc082/tasks/arc087_a
- 1 \leq N \leq 10^5
- a_i は整数である。
- 1 \leq a_i \leq 10^9"
#r "nuget: FsUnit"
open FsUnit

@"countByしてから指示通り計算すればよい."
let solve N Aa =
    Aa |> Array.countBy id
    |> Array.fold (fun acc (a,n) ->
        if a=n then acc elif a < n then acc+(n-a) else acc+n) 0
let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> stdout.WriteLine

solve 4 [|3;3;3;3|] |> should equal 1
solve 5 [|2;4;1;4;2|] |> should equal 2
solve 6 [|1;2;2;3;3;3|] |> should equal 0
solve 1 [|1000000000|] |> should equal 1
