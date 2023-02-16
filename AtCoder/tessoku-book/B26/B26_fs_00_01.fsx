#r "nuget: FsUnit"
open FsUnit

(*
let N = 20
*)
let solve N =
  let primes = Array.create (N+1) true
  primes.[0] <- false; primes.[1] <- false
  let rec go i p = if i>=(N+1) then () else (primes.[i] <- false; go (i+p) p)
  [|0..N|] |> Array.iter (fun p -> if primes.[p] then go (2*p) p)
  primes |> Array.indexed |> Array.filter snd |> Array.map fst

let N = stdin.ReadLine() |> int
solve N |> Array.iter (stdout.WriteLine)

solve 20 |> should equal [|2;3;5;7;11;13;17;19|]
solve 1000000
