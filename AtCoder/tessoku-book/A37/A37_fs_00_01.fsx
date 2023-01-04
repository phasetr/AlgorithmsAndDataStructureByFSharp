#r "nuget: FsUnit"
open FsUnit

(*
let N,M,B,Aa,Ca = 2L,3L,100L,[|10L;20L|],[|1L;2L;3L|]
*)
let solve (N:int64) M B Aa Ca = M*(Array.sum Aa+N*B) + N*Array.sum Ca

let N,M,B = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0],x.[1],x.[2])
let Aa = stdin.ReadLine().Split() |> Array.map int64
let Ca = stdin.ReadLine().Split() |> Array.map int64
solve N M B Aa Ca |> stdout.WriteLine

solve 2L 3L 100L [|10L;20L|] [|1L;2L;3L|] |> should equal 702L
