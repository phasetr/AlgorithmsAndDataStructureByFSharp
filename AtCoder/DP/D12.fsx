@"https://atcoder.jp/contests/dp/tasks/dp_d"
#r "nuget: FsUnit"
open FsUnit

let N,W,wva = 3,8,[|(3,30L);(4,50L);(5,60L)|]
let solve N W (wva: array<int*int64>) =
    let f (dp:int64[]) (wi,vi) = [|0..W|] |> Array.map (fun w -> if w>=wi then max (dp.[w-wi]+vi) dp.[w] else dp.[w])
    Array.fold f (Array.replicate (W+1) 0) wva |> Array.last
let N,W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let wva = [| for i in 1..N do (stdin.ReadLine().Split() |> fun x -> int x.[0], int64 x.[1]) |]
solve N W wva |> stdout.WriteLine

solve 3 8 [|(3,30L);(4,50L);(5,60L)|] |> should equal 90L
solve 5 5 [|(1,1000000000L);(1,1000000000L);(1,1000000000L);(1,1000000000L);(1,1000000000L)|] |> should equal 5000000000L
solve 6 15 [|(6,5L);(5,6L);(6,4L);(6,6L);(3,5L);(7,2L)|] |> should equal 17L
