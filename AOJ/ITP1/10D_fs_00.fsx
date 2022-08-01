#r "nuget: FsUnit"
open FsUnit

let solve Xa Ya =
  let l1 = Array.map2 (fun x y -> abs (x-y)) Xa Ya |> Array.sum
  let l2 = Array.map2 (fun x y -> abs (x-y)**2.0) Xa Ya |> Array.sum |> sqrt
  let l3 = Array.map2 (fun x y -> abs (x-y)**3.0) Xa Ya |> Array.sum |> fun x -> x**(1.0/3.0)
  let linf = Array.map2 (fun x y -> abs (x-y)) Xa Ya |> Array.max
  [|l1;l2;l3;linf|]

let N = stdin.ReadLine() |> int
let Xa = stdin.ReadLine().Split() |> Array.map float
let Ya = stdin.ReadLine().Split() |> Array.map float
solve Xa Ya |> Array.iter stdout.WriteLine

let near0 x y = (abs (x-y)) < 0.000_01
let Xa = [|1.0;2.0;3.0|]
let Ya = [|2.0;0.0;4.0|]
Array.map2 near0 (solve Xa Ya) [|4.000000;2.449490;2.154435;2.000000|] |> Array.forall id |> should be True
