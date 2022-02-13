@"https://atcoder.jp/contests/abc139/tasks/abc139_d
N は 1 \leq N \leq 10^9 を満たす整数である。"
#r "nuget: FsUnit"
open FsUnit

@"{1,2,...,N}の順列に対してi%P_iの最大値は(N-1)%N=N-1で,
上から順にこれを詰めればよい.
いま N=10^9 なので普通に和を取るとTLEが出る."
let solve N = N*(N-1L) / 2L
let N = stdin.ReadLine() |> int64
solve N |> stdout.WriteLine

solve 2L |> should equal 1L
solve 13L |> should equal 78L
solve 1L |> should equal 0L
