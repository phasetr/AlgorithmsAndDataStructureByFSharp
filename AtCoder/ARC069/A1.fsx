@"https://atcoder.jp/contests/arc069/tasks/arc069_a
1 ≦ N,M ≦ 10^{12}"
#r "nuget: FsUnit"
open FsUnit

@"S:C=1:2になるようにCを分配し, Sを返せばよい.
特に次の二つの組み方がある.
1. S 字型のピース 1 つと c 字型のピース 2 つを組み合わせて Scc の組を 1 つ作る
2. c 字型のピース 4 つを組み合わせて Scc の組を 1 つ作る"
let solve N M = if M<=2L*N then M/2L else N + (M-2L*N)/4L
let N, M = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1])
solve N M |> stdout.WriteLine

solve 1L 6L |> should equal 2L
solve 12345L 678901L |> should equal 175897L
solve 2L 6L |> should equal 2L
solve 3L 6L |> should equal 3L
solve 2L 0L |> should equal 0L
solve 2L 1L |> should equal 0L
solve 2L 2L |> should equal 1L
solve 2L 3L |> should equal 1L
solve 2L 4L |> should equal 2L
solve 2L 5L |> should equal 2L
solve 2L 6L |> should equal 2L
solve 2L 7L |> should equal 2L
solve 2L 8L |> should equal 3L
solve 2L 9L |> should equal 3L
solve 2L 10L |> should equal 3L
