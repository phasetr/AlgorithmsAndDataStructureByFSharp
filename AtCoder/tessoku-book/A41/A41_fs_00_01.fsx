#r "nuget: FsUnit"
open FsUnit

(*
let N,S = 7,"BBRRRBB"
let N,S = 5,"RBRBR"
*)
let solve N (S:string) = (S.Contains "BBB" || S.Contains "RRR") |> fun b -> if b then "Yes" else "No"

let N = stdin.ReadLine() |> int
let S = stdin.ReadLine()
solve N S |> stdout.WriteLine

solve 7 "BBRRRBB" |> should equal "Yes"
solve 5 "RBRBR" |> should equal "No"
