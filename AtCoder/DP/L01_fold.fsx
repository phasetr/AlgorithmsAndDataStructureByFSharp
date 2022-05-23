#r "nuget: FsUnit"
open FsUnit
let N,Aa = 4,[|10L;80L;90L;30L|]
let N,Aa = 1,[|10L|]
let solve N (Aa:int64[]) =
    (Array2D.zeroCreate (N+1) (N+1), [|1..N|])
    ||> Array.fold (fun dp w ->
        (dp, [|0..N-w|]) ||> Array.fold (fun dp i -> Array2D.set dp i (i+w) (max (Aa.[i]-dp.[i+1,i+w]) (Aa.[i+w-1]-dp.[i,i+w-1])); dp))
    |> fun dp -> dp.[0,N]
let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int64
solve N Aa |> stdout.WriteLine

solve 4 [|10L;80L;90L;30L|] |> should equal 10L
solve 3 [|10L;100L;10L|] |> should equal -80L
solve 1 [|10L|] |> should equal 10L
solve 10 [|1000000000L;1L;1000000000L;1L;1000000000L;1L;1000000000L;1L;1000000000L;1L|] |> should equal 4999999995L
solve 6 [|4L;2L;9L;7L;1L;5L|] |> should equal 2L
