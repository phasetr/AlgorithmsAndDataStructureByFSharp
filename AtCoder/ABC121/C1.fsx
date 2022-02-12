@"https://atcoder.jp/contests/abc121/tasks/abc121_c"
#r "nuget: FsUnit"
open FsUnit

let solve N M Xs =
    Xs |> Array.sortBy (fun (x,_) -> x)
    |> Array.fold (fun (accmon, accM) (a,b) ->
        if accM=0L then (accmon, 0L)
        else if b < accM then (accmon+a*b, accM-b) else (accmon + a*accM, 0L))
        (0L,M) |> fst
let N, M = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1])
let Xs = [| for i in 1L..N do (stdin.ReadLine().Split() |> Array.map int64 |> fun x -> x.[0],x.[1]) |]
solve N M Xs |> stdout.WriteLine

solve 2L 5L [|(4L,9);(2L,4)|] |> should equal 12L
solve 4L 30L [|(6L,18L);(2L,5L);(3L,10L);(7L,9L)|] |> should equal 130L
solve 1L 100000L [|(1000000000L,100000L)|] |> should equal 100000000000000L
