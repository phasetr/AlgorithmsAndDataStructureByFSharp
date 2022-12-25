#r "nuget: FsUnit"
open FsUnit

let solve N X Ia =
  (false,Ia) ||> Array.fold (fun b a -> if b || X=a then true else false)
  |> fun b -> if b then "Yes" else "No"

let N,X = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = stdin.ReadLine().Split() |> Array.map int
solve N X Ia |> stdout.WriteLine

solve 5 40 [|10;20;30;40;50|] |> should equal "Yes"
solve 6 28 [|30;10;40;10;50;50|] |> should equal "No"
