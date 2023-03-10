#r "nuget: FsUnit"
open FsUnit

(*
let N = 800
*)
let solve N = N |> fun n -> (float n) * 1.1 |> int
let N = stdin.ReadLine() |> int
solve N |> stdout.WriteLine

solve 800 |> should equal 880
