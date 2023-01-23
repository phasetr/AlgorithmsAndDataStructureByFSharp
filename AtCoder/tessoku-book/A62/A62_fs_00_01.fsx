#r "nuget: FsUnit"
open FsUnit

(*
let N,M,Ia = 3,2,[|(1,3);(2,3)|]
let N,M,Ia = 6,6,[|(1,4);(2,3);(3,4);(5,6);(1,2);(2,4)|]
*)
let solveTLE N M Ia =
  let Ga = (Array.create N [], Ia) ||> Array.fold (fun acc (a,b) ->
    acc.[a-1] <- (b-1)::acc.[a-1]; acc.[b-1] <- (a-1)::acc.[b-1]
    acc)
  let dfs f v0 =
    let rec g v (vs, visited) = ((vs, visited), f v) ||> List.fold (fun (us,visited') u ->
      if Set.contains u visited' then (us, visited')
      else g u (u::us, Set.add u visited'))
    g v0 ([v0], Set.singleton v0)
  dfs (fun x -> Ga.[x]) 0 |> fst
  |> fun xs -> if List.length xs = N then "The graph is connected." else "The graph is not connected."

open System.Collections.Generic
let solve N M Ia =
  let Ga = (Array.create N [], Ia) ||> Array.fold (fun acc (a,b) ->
    acc.[a-1] <- (b-1)::acc.[a-1]; acc.[b-1] <- (a-1)::acc.[b-1]
    acc)
  let dfs f v0 =
    let rec g v ((vs, visited):(int list)*(HashSet<int>)) =
      ((vs, visited), f v) ||> List.fold (fun (us,visited') u ->
        if visited'.Contains(u) then (us, visited')
        else visited'.Add(u) |> ignore; g u (u::us, visited'))
    let s = HashSet<int>() in s.Add(v0) |> ignore; g v0 ([v0], s)
  dfs (fun x -> Ga.[x]) 0 |> fst
  |> fun xs -> if List.length xs = N then "The graph is connected." else "The graph is not connected."

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = Array.init M (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N M Ia |> stdout.WriteLine

solve 3 2 [|(1,3);(2,3)|] |> should equal "The graph is connected."
solve 6 6 [|(1,4);(2,3);(3,4);(5,6);(1,2);(2,4)|] |> should equal "The graph is not connected."
