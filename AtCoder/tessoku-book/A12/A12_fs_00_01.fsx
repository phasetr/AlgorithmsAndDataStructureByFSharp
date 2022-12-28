#r "nuget: FsUnit"
open FsUnit

(*
let N,K,Ia = 4L,10L,[|1L..4L|]
*)
let solve N K Ia =
  let rec bsearch l r =
    if r<=l then l
    else
      let m = (l+r)/2L
      let s = Ia |> Array.sumBy (fun a -> m/a)
      if K<=s then bsearch l m
      else bsearch (m+1L) r
  bsearch 1L (pown 10L 9)

let N,K = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0],x.[1])
let Ia = stdin.ReadLine().Split() |> Array.map int64
solve N K Ia |> stdout.WriteLine

solve 4L 10L [|1L;2L;3L;4L|] |> should equal 6L
