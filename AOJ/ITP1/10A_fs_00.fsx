#r "nuget: FsUnit"
open FsUnit

let solve Xa =
  match Xa with
    | [|x1;y1;x2;y2|] -> sqrt ((x1-x2)**2.0 + (y1-y2)**2.0)
    | _ -> failwith "invalid input"

let Xa = stdin.ReadLine().Split() |> Array.map float
solve Xa |> stdout.WriteLine

let near0 x y = (abs (x-y)) < 0.000_1

near0 (solve [|0.0;0.0;1.0;1.0|]) 1.41421356 |> should be True
