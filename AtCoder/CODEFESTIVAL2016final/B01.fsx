@"https://atcoder.jp/contests/cf16-final/tasks/codefestival_2016_final_b"
#r "nuget: FsUnit"
open FsUnit

@"解説から:
和が(n-1)*n < 2*N && n*(n+1) <= 2*Nをみたすnのうち最大の数をKとすれば,
Kまでの和で求める点数が取れる.
和の項を一つ追加すればちょうど溢れるところまで数を採っているから,
K以下の数を一つ抜けば求めるデータセットが得られる.
Nがある程度まで大きくなると途中の i*(i-1L) も大きくなって
int の範囲を越えるから int64 で処理しなければならない.
(実際にREで落とされた.)"
let N =7L
let solve N =
    [|1L..N|]
    |> Array.filter (fun i -> (i-1L)*i < 2L*N && 2L*N <= i*(i+1L))
    |> Array.max
    |> fun K -> (K, Array.sum [|1L..K|] - N)
    |> fun (K,s) -> [|1L..K|] |> Array.filter (fun i -> i<>s)
let N = stdin.ReadLine() |> int64
solve N |> Array.map stdout.WriteLine

solve 4L |> should equal [|1L;3L|]
solve 7L |> should equal [|1L;2L;4L|]
solve 1L |> should equal [|1L|]
solve 9997155L |> Array.max
