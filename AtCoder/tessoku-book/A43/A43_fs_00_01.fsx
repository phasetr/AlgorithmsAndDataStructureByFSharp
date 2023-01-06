#r "nuget: FsUnit"
open FsUnit

(*
let N,L,Ia = 3,100,[|(20,"E");(50,"E");(70,"W")|]
*)
let solve N L Ia = (0,Ia) ||> Array.fold (fun acc (a,b) -> let x = if b="E" then L-a else a in max acc x)

let N,L = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> fun x -> int x.[0],x.[1])
solve N L Ia |> stdout.WriteLine

solve 3 100 [|(20,"E");(50,"E");(70,"W")|] |> should equal 80
