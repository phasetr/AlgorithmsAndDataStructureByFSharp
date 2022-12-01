#r "nuget: FsUnit"
open FsUnit

(*
let solveTLE N Aa Ba Ca =
  let Xa = Aa |> Array.sort
  let Za = Ca |> Array.sort
  let rec aCount i b  = if i<N && Xa.[i]<b  then aCount (i+1) b else int64 i
  let rec cCount i b  = if i<N && Za.[i]<=b then cCount (i+1) b else int64 (N-i)
  (0L, Ba) ||> Array.fold (fun acc b -> acc + aCount 0 b * cCount 0 b)
*)

// let N,Aa,Ba,Ca = 2,[|1L;5L|],[|2L;4L|],[|3L;6L|]
// let N,Aa,Ba,Ca = 3,[|1L;1L;1L|],[|2L;2L;2L|],[|3L;3L;3L|]
// let N,Aa,Ba,Ca = 100000,(Array.create 100000 1L),(Array.create 100000 2L),(Array.create 100000 3L)
let solve N Aa Ba Ca =
  let Xa = Aa |> Array.sort
  let Ya = Ba |> Array.sort
  let Za = Ca |> Array.sort
  let rec a i b = if i<N-1 && Xa.[i+1]<b then a (i+1) b else i
  let rec c k b = if k<N-1 && Za.[k]<=b  then c (k+1) b else k
  ((0L,0,0),Ya) ||> Array.fold (fun (acc0,i0,k0) b ->
    let i = a i0 b
    let k = c k0 b
    let acc = if Xa.[i]<b && b<Za.[k] then acc0 + (int64 (i+1) * int64(N-k)) else acc0
    (acc,i,k)) |> fun (acc,_,_) -> acc

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int64
let Ba = stdin.ReadLine().Split() |> Array.map int64
let Ca = stdin.ReadLine().Split() |> Array.map int64
solve N Aa Ba Ca |> stdout.WriteLine

solve 2 [|1L;5L|] [|2L;4L|] [|3L;6L|] |> should equal 3L
solve 3 [|1L;1L;1L|] [|2L;2L;2L|] [|3L;3L;3L|] |> should equal 27L
solve 6 [|3L;14L;159L;2L;6L;53L|] [|58L;9L;79L;323L;84L;6L|] [|2643L;383L;2L;79L;50L;288L|] |> should equal 87L
solve 3 [|1L;2L;3L|] [|1L;2L;3L|] [|1L;2L;3L|] |> should equal 1L
solve 100000 (Array.create 100000 1L) (Array.create 100000 2L) (Array.create 100000 3L) |> should equal 1000000000000000L
