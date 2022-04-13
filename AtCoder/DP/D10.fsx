@"https://atcoder.jp/contests/dp/tasks/dp_d"
#r "nuget: FsUnit"
open FsUnit

let N,W,wva = 3,8,[|(3,30L);(4,50L);(5,60L)|]
let solve1 N W (wva: array<int*int64>) =
    let f (dp:int64[]) (w,v) =
        let g w0 = if w0>=w then max (dp.[w0-w]+v) dp.[w0] else dp.[w0]
        Array.map g [|0..W|]
    wva |> Array.fold f (Array.replicate (W+1) 0L) |> Array.last
let N,W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let wva = [| for i in 1..N do (stdin.ReadLine().Split() |> fun x -> int x.[0], int64 x.[1]) |]
solve1 N W wva |> stdout.WriteLine

@"TLE"
let solve2 N W (wva: array<int*int64>) =
    let f (dp:seq<int64>) (w,v) = seq {0..W} |> Seq.map (fun w0 -> if w0>=w then max ((Seq.item (w0-w) dp)+v) (Seq.item w0 dp) else Seq.item w0 dp)
    Array.fold f (Seq.replicate (W+1) 0L) wva |> Seq.last
let N,W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let wva = [| for i in 1..N do (stdin.ReadLine().Split() |> fun x -> int x.[0], int64 x.[1]) |]
solve2 N W wva |> stdout.WriteLine

solve1 3 8 [|(3,30L);(4,50L);(5,60L)|] |> should equal 90L
solve1 5 5 [|(1,1000000000L);(1,1000000000L);(1,1000000000L);(1,1000000000L);(1,1000000000L)|] |> should equal 5000000000L
solve1 6 15 [|(6,5L);(5,6L);(6,4L);(6,6L);(3,5L);(7,2L)|] |> should equal 17L
solve2 3 8 [|(3,30L);(4,50L);(5,60L)|] |> should equal 90L
solve2 5 5 [|(1,1000000000L);(1,1000000000L);(1,1000000000L);(1,1000000000L);(1,1000000000L)|] |> should equal 5000000000L
solve2 6 15 [|(6,5L);(5,6L);(6,4L);(6,6L);(3,5L);(7,2L)|] |> should equal 17L
