#r "nuget: FsUnit"
open FsUnit

(*
let N = 4
*)
let solve N =
  [|0..N-1|] |> Array.map (fun i -> sprintf "%d %d" (i+1) ((i+1)%N+1))
  |> Array.append [|string N|]
let N = stdin.ReadLine() |> int
solve N |> Array.iter stdout.WriteLine

solve 4
(*
4
1 3
2 3
1 4
2 4
*)
