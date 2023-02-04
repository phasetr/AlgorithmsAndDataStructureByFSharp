#r "nuget: FsUnit"
open FsUnit

module Pqueue =
  type 'a t = {mutable cnt : int; hp : 'a array; cmp : 'a -> 'a -> int}
  let create n v f = {cnt = 0; hp = Array.create n v; cmp = f}
  let push k pq =
    let swap i j = let t = pq.hp.[i] in pq.hp.[i] <- pq.hp.[j]; pq.hp.[j] <- t
    let rec iter i =
      let p = i / 2
      if p = 0 || pq.cmp pq.hp.[p] pq.hp.[i] >= 0 then () else (swap p i; iter p)
    pq.cnt <- pq.cnt + 1
    pq.hp.[pq.cnt] <- k
    iter (pq.cnt)
  let maxHeapify pq n =
    let swap i j = let t = pq.hp.[i] in pq.hp.[i] <- pq.hp.[j]; pq.hp.[j] <- t
    let rec iter i =
      let l = 2*i
      let r = 2*i+1
      let mi =
        let ti = if l <= pq.cnt && pq.cmp pq.hp.[l] pq.hp.[i] > 0 then l else i
        if r <= pq.cnt && pq.cmp pq.hp.[r] pq.hp.[ti] > 0 then r else ti
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

let solve N (Aa: int list[]) =
  let dijkstra N s (g: ((int*int) list)[]) =
    let d = Array.create N System.Int32.MaxValue
    let av = Array.create N true
    let pq = Pqueue.create 1000000 (0,0) (fun x y -> compare y x)
    let rec loop () =
      if Pqueue.isEmpty pq then d
      else
        let du, u = Pqueue.pop pq
        if av.[u] then
          Array.set av u false
          g.[u] |> List.iter
            (fun (v,c) ->
             if du + c < d.[v] then Array.set d v (du+c); Pqueue.push (d.[v],v) pq)
          loop ()
        else loop ()
    d.[s] <- 0
    Pqueue.push (d.[s], s) pq
    loop ()

  (Array.create N [], Aa)
  ||> Array.fold
    (fun g a ->
     let u,k = a.[0],a.[1]
     let rec read g l =
       match l with
         | [] -> g
         | v::c::tail -> Array.set g u ((v,c) :: g.[u]); read g tail
         | _ -> failwith "not come here"
     read g a.[2..])
  |> dijkstra N 0 |> Array.mapi (fun i x -> [|i;x|])

let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..N do (stdin.ReadLine().Split() |> Array.map int) |> Array.toList |]
solve N Xa |> Array.map string |> String.concat " " |> stdout.WriteLine

let N,Aa = 5,[|[0;3;2;3;3;1;1;2];[1;2;0;2;3;4];[2;3;0;3;3;1;4;1];[3;4;2;1;0;1;1;4;4;3];[4;2;2;1;3;3]|]
solve N Aa |> should equal [|[|0;0|];[|1;2|];[|2;2|];[|3;1|];[|4;3|]|]
