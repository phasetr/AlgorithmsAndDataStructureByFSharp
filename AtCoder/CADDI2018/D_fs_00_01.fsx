#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa = 2,[|1;2|]
let N,Aa = 3,[|100000;30000;20000|]
*)
let solve = Array.forall (fun x -> x%2=0) >> fun b -> if b then "second" else "first"

stdin.ReadLine() |> ignore
let Aa = Array.init N (fun _ -> stdin.ReadLine() |> int)
solve Aa |> stdout.WriteLine

solve [|1;2|] |> should equal "first"
solve [|100000;30000;20000|] |> should equal "second"
