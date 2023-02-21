#r "nuget: FsUnit"
open FsUnit

(*
let N,X,Y,Aa = 2,2,3,[|5L;8L|]
let N,X,Y,Aa = 2,2,3,[|7L;8L|]
*)
let solve N X Y Aa =
  (0L,Aa) ||> Array.fold (fun acc a -> acc^^^(a%5L/2L))
  |> fun x -> if x=0L then "Second" else "First"
let N,X,Y = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1],x.[2])
let Aa = stdin.ReadLine().Split() |> Array.map int64
solve N X Y Aa |> stdout.WriteLine

solve 2 2 3 [|5L;8L|] |> should equal "First"
solve 2 2 3 [|7L;8L|] |> should equal "Second"
