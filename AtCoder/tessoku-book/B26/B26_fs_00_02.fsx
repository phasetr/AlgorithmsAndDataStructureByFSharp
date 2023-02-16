#r "nuget: FsUnit"
open FsUnit

(*
let N = 20L
*)
let solve N =
  let M = N+1L
  let Va =
    let Va = Array.create (int M) true
    Va.[0] <- false; Va.[1] <- false
    Va
  Array.append [|2L|] [|3L..2L..M|] |> Array.iter (fun p ->
    for c in (pown p 2)..p..N do Va.[int c] <- false)
  Va |> Array.indexed |> Array.filter snd |> Array.map fst

let N = stdin.ReadLine() |> int64
solve N |> Array.iter (stdout.WriteLine)

solve 20L |> should equal [|2L;3L;5L;7L;11L;13L;17L;19L|]
solve 1000000L
