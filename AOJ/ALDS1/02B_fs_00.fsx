#r "nuget: FsUnit"
open FsUnit

let Xa = [|5;6;4;2;1;3|]
let solve N Xa =
  let change i minj (a:int[]) =
    let ai,aminj = a.[i], a.[minj] in a.[i] <- aminj; a.[minj] <- ai; a
  let rec ssort i j (a:int[]) min cnt =
    if (i = N) && (j = N) then (a, cnt)
    else if (j = N) then
      if i = min then ssort (i+1) (i+1) a (i+1) cnt
      else ssort (i+1) (i+1) (change i min a) (i+1) (cnt+1)
    else if a.[j] < a.[min] then ssort i (j+1) a j cnt
    else ssort i (j+1) a min cnt
  ssort 0 0 Xa 0 0

let N = stdin.ReadLine() |> int
let Xa = stdin.ReadLine().Split() |> Array.map int
solve N Xa |> stdout.WriteLine

solve 6 [|5;6;4;2;1;3|] |> should equal ([|1..6|],4)
solve 6 [|5;2;4;6;1;3|] |> should equal ([|1..6|],3)
