#r "nuget: FsUnit"
open FsUnit

(*
let N,Ia = 4,[|(20,70);(30,50);(30,100);(20,60)|]
*)
let solve N Ia =
  (Array.create 1441 0, Ia |> Array.sortBy snd)
  ||> Array.fold (fun dp (ti,di) ->
    for j in 1440..(-1)..0 do
      if ti<=j && j<=di then dp.[j] <- max dp.[j] (dp.[j-ti]+1)
    dp)
  |> Array.max

let N = stdin.ReadLine() |> int
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N Ia |> stdout.WriteLine

solve 4 [|(20,70);(30,50);(30,100);(20,60)|] |> should equal 4
