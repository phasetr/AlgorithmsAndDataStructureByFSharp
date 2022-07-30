#r "nuget: FsUnit"
open FsUnit

let solve n Xa =
  let m = (Array.sum Xa) / (float n)
  (0.0,Xa) ||> Array.fold (fun acc si -> acc + (si - m)**2.0)
  |> fun x -> sqrt (x/n)

let N = stdin.ReadLine() |> float
let Xa = stdin.ReadLine().Split() |> Array.map float
solve N Xa |> stdout.WriteLine

let near0 x y = (abs (x-y)) < 0.000_1
near0 (solve 5 [|70.0;80.0;100.0;90.0;20.0|]) 27.8567 |> should be True
near0 (solve 3 [|80.0;80.0;80.0|]) 0.0 |> should be True
