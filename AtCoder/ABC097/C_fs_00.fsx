#r "nuget: FsUnit"
open FsUnit

(*
let S,K = "aba",4
let S,K = "atcoderandatcodeer",5
let S,K = "z",1
*)
let solve (S:string) K =
  let n = S.Length - 1
  [|0..n|] |> Array.collect (fun i -> [|i..(min n (i+K-1))|] |> Array.map (fun j -> S.[i..j]))
  |> Array.distinct
  |> Array.sort
  |> fun a -> a.[K-1]

let S = stdin.ReadLine()
let K = stdin.ReadLine() |> int
solve S K |> stdout.WriteLine

solve "aba" 4 |> should equal "b"
solve "atcoderandatcodeer" 5 |> should equal "andat"
solve "z" 1 |> should equal "z"
  let n = S.Length - 1
  [|0..n|] |> Array.map (fun i -> [|i..(min n (i+K-1))|] |> Array.map (fun j -> S.[i..j]))
