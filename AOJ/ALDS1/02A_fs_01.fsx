#r "nuget: FsUnit"
open FsUnit

let solve N Xa =
  let rec bsort (a:int[]) c =
    let rec bubble c = function
      | 0 -> a,c
      | i ->
        let ai,aj = a.[i],a.[i-1]
        bubble (if ai < aj then (a.[i] <- aj; a.[i-1] <- ai; c+1) else c) (i-1) in
    match bubble 0 N with
      | v,0 -> v,c
      | v,t -> bsort v (c+t) in
  bsort Xa 0

let N = stdin.ReadLine() |> int
let Xa = stdin.ReadLine().Split() |> Array.map int
solve (N-1) Xa |> stdout.WriteLine

solve (5-1) [|5;3;2;4;1|] |> should equal ([|1;2;3;4;5|], 8)
solve (6-1) [|5;2;4;6;1;3|] |> should equal ([|1;2;3;4;5;6|], 9)
