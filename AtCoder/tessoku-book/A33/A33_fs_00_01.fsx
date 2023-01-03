#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa = 2,[|7;7|]
elt N,Aa = 2,[|5;8|]
*)
let solve N = Array.reduce (^^^) >> fun x -> if x=0 then "Second" else "First"

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> stdout.WriteLine

solve 2 [|7;7|] |> should equal "Second"
solve 2 [|5;8|] |> should equal "First"
