@"https://atcoder.jp/contests/dp/tasks/dp_e"
#r "nuget: FsUnit"
open FsUnit

let N,W,wva = 3,8L,[|(3L,30);(4L,50);(5L,60)|]
let solve N W wva =
    ((Array.replicate 100_001 1_000_000_001L), wva)
    ||> Array.fold (fun (dp:int64[]) (wi,vi) -> [|0..100_000|] |> Array.map (fun v -> if v<vi then min dp.[v] wi else min dp.[v] (wi+dp.[v-vi])))
    |> Array.takeWhile ((>=) W) |> Array.length
let N,W = stdin.ReadLine().Split() |> (fun x -> int x.[0], int64 x.[1])
let wva = [| for i in 1..N do (stdin.ReadLine().Split() |> fun x -> int64 x.[0], int x.[1]) |]
solve N W wva |> stdout.WriteLine

solve 3 8L [|(3L,30);(4L,50);(5L,60)|] |> should equal 90
solve 1 1000000000L [|(1000000000L,10)|] |> should equal 10
solve 6 15L [|(6L,5);(5L,6);(6L,4);(6L,6);(3L,5);(7L,2)|] |> should equal 17
