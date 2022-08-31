#r "nuget: FsUnit"
open FsUnit

let solve N Xa =
  let Ya = Array.sort Xa
  let t = Array.create (Ya.[N-1] + 1) 0
  Array.iteri (fun i e -> t.[e] <- i) Ya
  let p = Array.create N false
  let rec df i acc =
    p.[i] <- true;
    if p.[t.[Xa.[i]]] then Xa.[i] :: acc
    else df t.[Xa.[i]] (Xa.[i] :: acc)
  let rec frec i acc =
    if i=N then acc
    else if p.[i] then frec (i+1) acc
    else
      let ws = df i []
      let m = List.length ws
      let s = List.fold (+) 0 ws
      let z = List.fold min System.Int32.MaxValue ws
      frec (i+1) (acc + (min (s+(m-2)*z) (s+z+(m+1)*Ya.[0])))
  frec 0 0

let N = stdin.ReadLine() |> int
let Xa = stdin.ReadLine().Split() |> Array.map int
solve N Xa |> stdout.WriteLine

solve 5 [|1;5;3;4;2|] |> should equal 7
solve 4 [|4;3;2;1;|] |> should equal 10
