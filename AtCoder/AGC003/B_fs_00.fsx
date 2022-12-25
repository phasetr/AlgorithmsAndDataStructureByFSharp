#r "nuget: FsUnit"
open FsUnit

(*
let N,Ia = 4,[|4L;0L;3L;2L|]
let N,Ia = 8,[|2L;0L;1L;6L;0L;8L;2L;1L|]
*)
let solve N Ia =
  ((0L,0L), Ia)
  ||> Array.fold (fun (acc,m) a ->
    if m=0L then let (q,r) = (a/2L,a%2L) in (acc+q,r)
    elif a=0L then (acc,0L)
    else let (q,r) = ((a-1L)/2L, (a-1L)%2L) in (acc+q+1L,r))
  |> fst

let N = stdin.ReadLine() |> int
let Ia = Array.init N (fun _ -> stdin.ReadLine() |> int64)
solve N Ia |> stdout.WriteLine

solve 4 [|4L;0L;3L;2L|] |> should equal 4L
solve 8 [|2L;0L;1L;6L;0L;8L;2L;1L|] |> should equal 9L
