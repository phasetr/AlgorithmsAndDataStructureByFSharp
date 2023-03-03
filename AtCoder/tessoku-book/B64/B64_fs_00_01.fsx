#r "nuget: FsUnit"
open FsUnit

(*
let N,M,Ia = 6,7,[|(1,2,15);(1,4,20);(2,3,65);(2,5,4);(3,6,50);(4,5,30);(5,6,8)|]
let N,M,Ia = 15,30,[|(10,11,23);(11,13,24);(5,8,22);(10,15,18);(12,14,15);(2,10,11);(4,7,15);(5,7,15);(7,9,8);(8,12,1);(5,14,1);(10,14,17);(10,12,11);(8,10,6);(7,14,28);(6,9,1);(1,10,19);(4,5,4);(9,10,21);(7,10,21);(4,10,29);(5,10,8);(4,14,8);(11,12,24);(10,13,13);(3,10,1);(5,12,24);(2,15,23);(6,10,18);(6,15,25)|]
let N,M,Ia = 2,1,[|(1,2,3945)|]
*)
type 'a t = { mutable cnt : int; hp : 'a array; compare : 'a -> 'a -> int }
let create n v f = {cnt = 0; hp = Array.create n v; compare = f}
let push k pq =
  let swap i j = let t = pq.hp.[i] in pq.hp.[i] <- pq.hp.[j]; pq.hp.[j] <- t
  let rec iter i =
    let p = i / 2
    if p = 0 || pq.compare pq.hp.[p] pq.hp.[i] >= 0 then () else (swap p i; iter p)
  pq.cnt <- pq.cnt + 1
  pq.hp.[pq.cnt] <- k
  iter (pq.cnt)
let maxHeapify pq n =
  let swap i j = let t = pq.hp.[i] in pq.hp.[i] <- pq.hp.[j]; pq.hp.[j] <- t
  let rec iter i =
    let l = 2*i
    let r = 2*i+1
    let mi =
      let ti = if l <= pq.cnt && pq.compare pq.hp.[l] pq.hp.[i] > 0 then l else i
      if r <= pq.cnt && pq.compare pq.hp.[r] pq.hp.[ti] > 0 then r else ti
    if mi <> i then swap mi i; iter mi
  iter n
let pop pq =
  let ret = pq.hp.[1]
  pq.hp.[1] <- pq.hp.[pq.cnt]
  pq.cnt <- pq.cnt - 1
  maxHeapify pq 1
  ret
let top pq = pq.hp.[1]
let isEmpty pq = pq.cnt = 0

let solve N M Ia =
  let Ga =
    (Array.create (N+1) [], Ia)
    ||> Array.fold (fun g (a,b,c) -> g.[a] <- (b,c)::g.[a]; g.[b] <- (a,c)::g.[b]; g)
    |> Array.map (List.toArray)

  let fix = Array.create (N+1) false
  let cur = Array.create (N+1) 2000000000 |> fun c -> c.[1] <- 0; c
  let pq = create 100000 (0,0) (fun x y -> compare y x) |> fun pq -> push (0,1) pq; pq
  while not (isEmpty pq) do
    let pos = pop pq |> snd
    if fix.[pos] then ()
    else
      fix.[pos] <- true
      for (next,cost) in Ga.[pos] do
        if cur.[next] > cur.[pos] + cost then
          cur.[next] <- cur.[pos] + cost
          pq |> push (cur.[next], next)

  let rec aux place i =
    let (next,cost) = Ga.[place].[i]
    if cur.[next]+cost = cur.[place] then next else aux place (i+1)
  let rec minPath path place =
    if place=1 then 1::path
    else let p = aux place 0 in minPath (place::path) p
  minPath [] N

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = Array.init M (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1],x.[2])
solve N M Ia |> List.map string |> String.concat " " |> stdout.WriteLine

solve 6 7 [|(1,2,15);(1,4,20);(2,3,65);(2,5,4);(3,6,50);(4,5,30);(5,6,8)|] |> should equal [1;2;5;6]
solve 15 30 [|(10,11,23);(11,13,24);(5,8,22);(10,15,18);(12,14,15);(2,10,11);(4,7,15);(5,7,15);(7,9,8);(8,12,1);(5,14,1);(10,14,17);(10,12,11);(8,10,6);(7,14,28);(6,9,1);(1,10,19);(4,5,4);(9,10,21);(7,10,21);(4,10,29);(5,10,8);(4,14,8);(11,12,24);(10,13,13);(3,10,1);(5,12,24);(2,15,23);(6,10,18);(6,15,25)|] |> should equal [1;10;15]

// 06.txt
solve 2 1 [|(1,2,3945)|] |> should equal [1;2]
