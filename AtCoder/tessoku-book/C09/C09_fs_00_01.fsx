#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa = 5,[|2L;5L;3L;3L;1L|]
*)
let solve N Aa =
  ((0L,0L),Aa) ||> Array.fold (fun (p2,p1) a -> (max p1 p2, p2+a))
  |> fun (p1,p2) -> max p1 p2

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int64
solve N Aa |> stdout.WriteLine

solve 5 [|2L;5L;3L;3L;1L|] |> should equal 8L
