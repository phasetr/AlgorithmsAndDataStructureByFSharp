#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa = 7,[|1;1;3;2;4;4|]
let N,Aa = 15,[|1;2;1;1;1;6;2;6;9;10;6;12;13;12|]
*)
let solve N (Aa:int[]) =
  (Array.create N 0, [|(N-1)..(-1)..1|]) ||> Array.fold (fun dp i ->
    let j = Aa.[i-1]-1 in dp.[j] <- dp.[j] + dp.[i] + 1
    dp)

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> Array.map string |> String.concat " " |> stdout.WriteLine

solve 7 [|1;1;3;2;4;4|] |> should equal [|6;1;3;2;0;0;0|]
solve 15 [|1;2;1;1;1;6;2;6;9;10;6;12;13;12|] |> should equal [|14;2;0;0;0;8;0;0;2;1;0;3;1;0;0|]
