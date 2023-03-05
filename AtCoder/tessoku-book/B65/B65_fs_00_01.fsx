#r "nuget: FsUnit"
open FsUnit

(*
let N,T,Ia = 7,1,[|(1,2);(1,3);(3,4);(2,5);(4,6);(4,7)|]
let N,T,Ia = 15,1,[|(1,2);(2,3);(1,4);(1,5);(1,6);(6,7);(2,8);(6,9);(9,10);(10,11);(6,12);(12,13);(13,14);(12,15)|]
// 01.txt
let N,T = 100000,72036
let Ia = Array.init (N-1) (fun i -> ((i+2)/2,i+2))
*)
let solveStackOverflow N T Ia =
  let g =
    (Array.create N [], Ia)
    ||> Array.fold (fun g (a,b) -> g.[a-1] <- (b-1)::g.[a-1]; g.[b-1] <- (a-1)::g.[a-1]; g)
  let v = Array.create N 0
  let rec f cur prev (g:(list<int>)[]) (v:int[]) =
    let mutable lv = 0
    let rec aux = function
      | [] -> ()
      | next::gcur -> if next=prev then aux gcur else lv <- max lv (f next cur g v + 1); aux gcur
    aux g.[cur]
    v.[cur] <- lv
    lv
  f (T-1) (T-1) g v |> ignore
  v

open System.Collections.Generic
let solveTLE N T Ia =
  let edge =
    (Array.init N (fun _ -> HashSet<int>()), Ia)
    ||> Array.fold (fun g (a,b) -> g.[a-1].Add(b-1) |> ignore; g.[b-1].Add(a-1) |> ignore; g)
  let dist =
    let vec = Array.create N (-1) |> fun v -> v.[T-1] <- 0; v
    let rec go (children:HashSet<int>) = function
      | [] -> ()
      | p::ps ->
        let parents = edge.[p]
        parents.IntersectWith(children)
        children.ExceptWith(parents)
        let k = vec.[p]
        for j in parents do vec.[j] <- k+1
        go children (ps @ (Seq.toList parents))
    go (HashSet<int>([0..N-1] |> List.filter ((<>) (T-1)))) [T-1]
    vec
  let dsorted = (dist,[|0..N-1|]) ||> Array.map2 (fun x y -> (x,y)) |> Array.sortDescending |> Array.map snd
  let rank =
    let vec = Array.create N (-1)
    for i in dsorted do
      let boss = edge.[i] |> Seq.toList
      let ranks = boss |> Seq.map (fun j -> vec.[j])
      vec.[i] <- if Seq.isEmpty ranks then 0 else Seq.max ranks + 1
    vec
  rank

let N,T = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = Array.init (N-1) (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N T Ia |> Array.map string |> String.concat " " |> stdout.WriteLine

solve 7 1 [|(1,2);(1,3);(3,4);(2,5);(4,6);(4,7)|] |> should equal [|3;1;2;1;0;0;0|]
solve 15 1 [|(1,2);(2,3);(1,4);(1,5);(1,6);(6,7);(2,8);(6,9);(9,10);(10,11);(6,12);(12,13);(13,14);(12,15)|] |> should equal [|4;1;0;0;0;3;0;0;2;1;0;2;1;0;0|]

// 01.txt
let N,T = 100000,72036
let Ia = Array.init (N-1) (fun i -> ((i+2)/2,i+2))
solve N T Ia
