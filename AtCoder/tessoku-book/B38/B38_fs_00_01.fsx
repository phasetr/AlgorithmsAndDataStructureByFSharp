#r "nuget: FsUnit"
open FsUnit

(*
let N,S = 7,"AABBBA"
*)
let solve N S =
  Array.create N 1
  |> fun Aa ->
    S |> String.iteri (fun i c -> if c='A' then Aa.[i+1] <- Aa.[i]+1)
    for i in (N-2)..(-1)..0 do if S.[i]='B' then Aa.[i] <- max Aa.[i] (Aa.[i+1]+1)
    Aa |> Array.sum

let N = stdin.ReadLine() |> int
let S = stdin.ReadLine()
solve N S |> stdout.WriteLine

solve 7 "AABBBA" |> should equal 15
