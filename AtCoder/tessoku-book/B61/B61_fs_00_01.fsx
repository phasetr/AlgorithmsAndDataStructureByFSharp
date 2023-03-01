#r "nuget: FsUnit"
open FsUnit

(*
let N,M,Ia = 5,4,[|(1,2);(2,3);(3,4);(3,5)|]
let N,M,Ia = 15,30,[|(6,9);(9,10);(2,9);(9,12);(2,14);(1,4);(4,6);(1,3);(4,14);(1,6);(9,11);(2,6);(3,9);(5,9);(4,9);(11,15);(1,13);(4,13);(8,9);(9,13);(5,15);(3,5);(8,10);(2,4);(9,14);(1,9);(2,8);(6,13);(7,9);(9,15)|]
*)
let solve N M Ia =
  (Array.create (N+1) 0, Ia)
  ||> Array.fold (fun g (a,b) -> g.[a] <- g.[a]+1; g.[b] <- g.[b]+1; g)
  |> Array.indexed
  |> Array.maxBy snd
  |> fst

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = Array.init M (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N M Ia |> stdout.WriteLine

solve 5 4 [|(1,2);(2,3);(3,4);(3,5)|] |> should equal 3
solve 15 30 [|(6,9);(9,10);(2,9);(9,12);(2,14);(1,4);(4,6);(1,3);(4,14);(1,6);(9,11);(2,6);(3,9);(5,9);(4,9);(11,15);(1,13);(4,13);(8,9);(9,13);(5,15);(3,5);(8,10);(2,4);(9,14);(1,9);(2,8);(6,13);(7,9);(9,15)|] |> should equal 9

