#r "nuget: FsUnit"
open FsUnit

(*
let X,Y = 5,2
let X,Y = 1,1
*)
let solve X Y =
  let mutable x,y = X,Y
  let Rr = ResizeArray<int*int>()
  while 2<x+y do Rr.Add(x,y); if x<y then y <- y-x else x <- x-y
  Rr.Reverse(); Rr
let X,Y = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
solve X Y |> fun Rr -> stdout.WriteLine (Rr.Count); for (x,y) in Rr do (sprintf "%d %d" x y |> stdout.WriteLine)

solve 5 2 |> should equal (seq [(1,2);(3,2);(5,2)])
solve 1 1 |> should equal Seq.empty<int*int>
