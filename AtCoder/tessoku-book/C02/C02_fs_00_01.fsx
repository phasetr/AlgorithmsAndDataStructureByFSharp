#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa = 5,[|120;150;100;200;100|]
let N,Aa = 10,[|1;2;3;4;5;6;7;8;9;10|]
*)
let solve N Aa = Aa |> Array.sortDescending |> fun x -> x.[0]+x.[1]
let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> stdout.WriteLine

solve 5 [|120;150;100;200;100|] |> should equal 350
solve 10 [|1;2;3;4;5;6;7;8;9;10|] |> should equal 19
