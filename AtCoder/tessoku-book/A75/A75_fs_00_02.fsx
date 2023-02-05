#r "nuget: FsUnit"
open FsUnit

(*
let N,Ia = 4,[|(20,70);(30,50);(30,100);(20,60)|]
*)
let solve N Ia =
  Array2D.create (N+1) 1441 (-1)
  |> fun dp -> dp.[0,0] <- 0; ((1,dp), Ia |> Array.sortBy snd)
  ||> Array.fold (fun (i,dp) (ti,di) ->
    for j in 0..1440 do
      if ti<=j && j<=di then dp.[i,j] <- max dp.[i-1,j] (dp.[i-1,j-ti]+1)
      else dp.[i,j] <- dp.[i-1,j]
    (i+1,dp))
  |> snd |> fun dp -> Array.max dp.[N,0..]

let N = stdin.ReadLine() |> int
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N Ia |> stdout.WriteLine

solve 4 [|(20,70);(30,50);(30,100);(20,60)|] |> should equal 4
