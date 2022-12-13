#r "nuget: FsUnit"
open FsUnit

(*
let N,x,Aa = 3L,3L,[|2L;2L;2L|]
let N,x,Aa = 6L,1L,[|1L;6L;1L;2L;0L;4L|]
let N,x,Aa = 5L,9L,[|3L;1L;4L;1L;5L|]
let N,x,Aa = 2L,0L,[|5L;5L|]
*)
let solve N x Aa =
  let n,a0 = if Array.get Aa 0<=x then (0L,Aa.[0]) else (abs(x-Aa.[0]),x)
  ((n,a0), Aa.[1..])
  ||> Array.fold (fun (acc,a0) a -> let s=a0+a in if s<=x then (acc,a) else (acc+s-x,a-s+x))
  |> fst

let N,x = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0],x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int64
solve N x Aa |> stdout.WriteLine

solve 3L 3L [|2L;2L;2L|] |> should equal 1L
solve 6L 1L [|1L;6L;1L;2L;0L;4L|] |> should equal 11L
solve 5L 9L [|3L;1L;4L;1L;5L|] |> should equal 0L
solve 2L 0L [|5L;5L|] |> should equal 10L
