#r "nuget: FsUnit"
open FsUnit

(*
let N,M,Ia = 3,2,[|(1,3);(2,3)|]
let N,M,Ia = 6,6,[|(1,4);(2,3);(3,4);(5,6);(1,2);(2,4)|]
*)
/// BFS
type P = { To: int; From: int; Step: int }
let solve N M Ia =
  let Ga = (Array.init N (fun _ -> []), Ia) ||> Array.fold (fun g (a,b) ->
    g.[a-1] <- (b-1)::g.[a-1]; g.[b-1] <- (a-1)::g.[b-1]
    g)
  let q = System.Collections.Generic.Queue<P>() in q.Enqueue({To=0;From=0;Step=0})
  let Da = Array.create N (-1) |> fun d -> d.[0] <- 0; d
  let visited = Array.create N false |> fun v -> v.[0] <- true; v
  while q.Count > 0 do
    let w = q.Dequeue()
    Ga.[w.To] |> List.iter (fun x ->
      if not visited.[x] then
        q.Enqueue({To = x; From = w.From; Step = w.Step+1})
        visited.[x] <- true
        Da.[x] <- w.Step+1)
  Da

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = Array.init M (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N M Ia |> Array.iter stdout.WriteLine

solve 3 2 [|(1,3);(2,3)|] |> should equal [|0;2;1|]
solve 6 6 [|(1,4);(2,3);(3,4);(5,6);(1,2);(2,4)|] |> should equal [|0;1;2;1;-1;-1|] //
