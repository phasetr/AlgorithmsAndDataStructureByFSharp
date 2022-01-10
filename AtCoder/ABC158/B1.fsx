#r "nuget: FsUnit"
open System
open System.IO
open FsUnit

let rec solve (N: int64) (A: int64) (B: int64) =
    let rep = N / (A+B)
    let rem = min A (N % (A+B))
    rep*A + rem

let N, A, B = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1], x.[2])
solve N A B |> printfn "%d"

solve 8L 3L 4L |> should equal 4L
solve 8L 0L 4L |> should equal 0L
solve 6L 2L 4L |> should equal 2L
