#r "nuget: FsUnit"
open FsUnit

let N,K,Aa = 3,7,[|9;3;4|]
let N,K,Aa = 3,5,[|6;9;3|]
let solve N K Aa =
  let gcd x y = let rec frec x y = if y=0 then x else frec y (x%y) in if x>=y then frec x y else frec y x
  let m = Array.max Aa
  let g = Aa |> Array.reduce gcd
  if K<=m && K%g=0 then "POSSIBLE" else "IMPOSSIBLE"

let N,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N K Aa |> stdout.WriteLine

solve 3 7 [|9;3;4|] |> should equal "POSSIBLE"
solve 3 5 [|6;9;3|] |> should equal "IMPOSSIBLE"
solve 4 11 [|11;3;7;15|] |> should equal "POSSIBLE"
solve 5 12 [|10;2;8;6;4|] |> should equal "IMPOSSIBLE"
