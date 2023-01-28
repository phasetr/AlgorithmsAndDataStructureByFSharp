#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa = 7,[|1;1;3;2;4;4|]
let N,Aa = 15,[|1;2;1;1;1;6;2;6;9;10;6;12;13;12|]
*)
let solve N (Aa:int[]) =
  let Ta = (Array.create N [], [|0..N-2|]) ||> Array.fold (fun t i ->
    let j = Aa.[i]-1 in t.[j] <- (i+1)::t.[j]; t)
  let Sa = Array.create N 0
  let rec dfs i =
    let mutable cnt = 0
    Ta.[i] |> List.iter (fun j -> dfs j; cnt <- cnt+Sa.[j]+1)
    Sa.[i] <- cnt
  dfs 0
  Sa

let solve N (Aa:int[]) =
  let Ta = (Array.create N [], [|0..N-2|]) ||> Array.fold (fun t i ->
    let j = Aa.[i]-1 in t.[j] <- (i+1)::t.[j]; t)
  let rec dfs i (sa:int[]) =
    (0, Ta.[i]) ||> List.fold (fun acc j ->
      dfs j sa |> fun (s:int[]) -> acc+s.[j]+1)
    |> fun c -> sa.[i] <- c; sa
  Array.create N 0 |> dfs 0

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> Array.map string |> String.concat " " |> stdout.WriteLine

solve 7 [|1;1;3;2;4;4|] |> should equal [|6;1;3;2;0;0;0|]
solve 15 [|1;2;1;1;1;6;2;6;9;10;6;12;13;12|] |> should equal [|14;2;0;0;0;8;0;0;2;1;0;3;1;0;0|]
