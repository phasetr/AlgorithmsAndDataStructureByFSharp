#r "nuget: FsUnit"
open FsUnit

let N,Aa = 5,[|6;9;4;2;11|]
let solve N Aa =
  let Ba = Array.sortDescending Aa
  let n = Ba.[0]
  if N=2 then sprintf "%d %d" n Ba.[1]
  else let k = Aa |> Array.minBy (fun a -> abs (a - (n/2))) in sprintf "%d %d" n k

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> stdout.WriteLine

solve 5 [|6;9;4;2;11|] |> should equal "11 6"
solve 2 [|100;0|] |> should equal "100 0"
