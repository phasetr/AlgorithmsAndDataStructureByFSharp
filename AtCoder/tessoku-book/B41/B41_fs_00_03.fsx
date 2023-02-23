#r "nuget: FsUnit"
open FsUnit

(*
let X,Y = 5,2
let X,Y = 1,1
*)
let solve X Y =
  let mutable rs,x,y = [],X,Y
  while 2<x+y do
    rs <- (x,y)::rs
    if x<y then y <- y-x else x <- x-y
  rs
let X,Y = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
solve X Y |> fun Xs -> stdout.WriteLine (Xs.Length); Xs |> List.iter (fun (x,y) -> sprintf "%d %d" x y |> stdout.WriteLine)

solve 5 2 |> should equal [(1,2);(3,2);(5,2)]
solve 1 1 |> should equal (List.empty<int*int>)
