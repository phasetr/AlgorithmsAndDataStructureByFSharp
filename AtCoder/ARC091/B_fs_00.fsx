#r "nuget: FsUnit"
open FsUnit

let solve N K =
  if K=0L then N*N else [|1L..N|] |> Array.sumBy (fun b -> (N/b) * max 0L (b-K) + max (N%b-K+1L) 0L)

let N,K = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0],x.[1])
solve N K |> stdout.WriteLine

solve 5L 2L |> should equal 7L
solve 10L 0L |> should equal 100L
solve 31415L 9265L |> should equal 287927211L
