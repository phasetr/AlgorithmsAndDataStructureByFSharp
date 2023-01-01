#r "nuget: FsUnit"
open FsUnit

(*
let N,K,Ia = 7,10L,[|11L;12L;16L;22L;27L;28L;31L|]
let N,K,Ia = 5,1L,[|1L..5L|]
let N,K,Ia = 3,1L,[|1L;2L;4L|]
*)
let solveTLE N K (Ia:int64[]) =
  let rec frec acc l r =
    if l=N-1 then acc
    elif r<=N-1 && Ia.[r]-Ia.[l]<=K then frec acc l (r+1)
    else frec (acc+r-l-1) (l+1) (l+2)
  frec 0 0 1

let solve N K (Ia:int64[]) =
  let p i j = Ia.[j] - Ia.[i] <= K
  let rec bsearch pi l r =
    if r<=l then if pi l then l else l-1
    else let m = (l+r)/2 in if pi m then bsearch pi (m+1) r else bsearch pi l m
  let search i = if i=N-1 || K<Ia.[i+1]-Ia.[i] then None else Some (bsearch (p i) i (N-1))
  [|0..N-1|] |> Array.sumBy (fun i -> search i |> function | Some j -> (j-i |> int64) | None -> 0L)

let N,K = stdin.ReadLine().Split() |> (fun x -> int x.[0], int64 x.[1])
let Ia = stdin.ReadLine().Split() |> Array.map int64
solve N K Ia |> stdout.WriteLine

solve 7 10L [|11L;12L;16L;22L;27L;28L;31L|] |> should equal 11L
solve 5 1L [|1L..5L|] |> should equal 4L
solve 3 1L [|1L;2L;4L|] |> should equal 1L
solve 1 1L [|1L|] |> should equal 0L
solve 1 2L [|1L|] |> should equal 0L
