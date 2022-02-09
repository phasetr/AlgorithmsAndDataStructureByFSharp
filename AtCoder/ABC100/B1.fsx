@"https://atcoder.jp/contests/abc100/tasks/abc100_b
D=0,1,2
1 <= N <= 100"
#r "nuget: FsUnit"
open FsUnit

let solve D N =
    if N = 100 then 101 * (pown 100 D)
    else N * (pown 100 D)
let D, N = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
solve D N |> stdout.WriteLine

solve 0 5 |> should equal 5
solve 1 11 |> should equal 1100
solve 2 85 |> should equal 850000
