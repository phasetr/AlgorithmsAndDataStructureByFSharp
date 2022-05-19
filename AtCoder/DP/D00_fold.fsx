@"https://atcoder.jp/contests/dp/tasks/dp_d"
#r "nuget: FsUnit"
open FsUnit

@"https://atcoder.jp/contests/dp/submissions/14854368"
@"dp[i][w]=(i番目までの品物を重さがw以下になるように選んだときの価値の最大値)"
let solve N W (wva: array<int*int64>) =
    let f (dp: array<int64>) (wi,vi) =
        let g w = if w >= wi then max (dp.[w-wi]+vi) dp.[w] else dp.[w]
        Array.map g [|0..W|]
    (Array.replicate (W+1) 0L, wva) ||> Array.fold f |> Array.last

let N,W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let wva = [| for i in 1..N do (stdin.ReadLine().Split() |> fun x -> int x.[0], int64 x.[1]) |]
solve N W wva |> stdout.WriteLine

solve 3 8 [|(3,30L);(4,50L);(5,60L)|] |> should equal 90L
solve 5 5 [|(1,1000000000L);(1,1000000000L);(1,1000000000L);(1,1000000000L);(1,1000000000L)|] |> should equal 5000000000L
solve 6 15 [|(6,5L);(5,6L);(6,4L);(6,6L);(3,5L);(7,2L)|] |> should equal 17L
