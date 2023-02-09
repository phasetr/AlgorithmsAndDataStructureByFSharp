#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa,Q,Xa = 15,[|83;31;11;17;32;19;23;37;43;47;53;61;67;5;55|],5,[|10;20;30;40;50|]
let N,Aa,Q,Xa = 5,[|1;3;3;3;1|],2,[|4;3|]
*)
let solve N Aa Q Xa =
  let Sa = Aa |> Array.sort
  let bisectLeft x =
    let rec bsearch l r = if r<=l then l else let m = l+(r-l)/2 in if Sa.[m]<x then bsearch (m+1) r else bsearch l m
    bsearch 0 N
  Xa |> Array.map bisectLeft

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
let Q = stdin.ReadLine() |> int
let Xa = Array.init Q (fun _ -> stdin.ReadLine() |> int)
solve N Aa Q Xa |> Array.iter stdout.WriteLine

solve 15 [|83;31;11;17;32;19;23;37;43;47;53;61;67;5;55|] 5 [|10;20;30;40;50|] |> should equal [|1;4;5;8;10|]
solve 5 [|1;3;3;3;1|] 2 [|4;3|] |> should equal [|5;2|]
