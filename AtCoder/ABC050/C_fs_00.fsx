#r "nuget: FsUnit"
open FsUnit

let N,Aa = 5L,[|2;4;4;0;2|]
let N,Aa = 7L,[|6;4;0;2;4;0;2|]
let N,Aa = 8L,[|7;5;1;1;7;3;5;3|]
let solve N Aa =
  let MOD = 1_000_000_007L
  let rec pow m x n = if n=0L then 1L else if n%2L=0L then pow m (x*x % m) (n/2L) else (x * (pow m x (n-1L)) % m)
  let Ta = [|1L..N|] |> Array.map (fun i -> (abs (N-2L*i+1L)) |> int) |> Array.sort
  if (Aa |> Array.sort |> fun Ba -> Ba = Ta) then pow MOD 2L (if N%2L=0L then N/2L else (N-1L)/2L) else 0L

let N = stdin.ReadLine() |> int64
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> stdout.WriteLine

solve 5L [|2;4;4;0;2|] |> should equal 4L
solve 7L [|6;4;0;2;4;0;2|] |> should equal 0L
solve 8L [|7;5;1;1;7;3;5;3|] |> should equal 16L
