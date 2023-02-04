#r "nuget: FsUnit"
open FsUnit

(*
let N,M,Ia = 3,3,[|(1,2,70,1);(2,3,20,1);(1,3,90,0)|]
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
  let dijkstra N s (g: ((int64*int) list)[]) =
    let d = Array.create N System.Int64.MaxValue |> fun d -> d.[s] <- 0L; d
    let visited = Array.create N true
    let pq = create 1000000 (0L,0) (fun x y -> compare y x) |> fun pq -> push (d.[s],s) pq; pq
    let rec loop () =
      if isEmpty pq then d
      else
        let du, u = pop pq
        if visited.[u] then
          Array.set visited u false
          g.[u] |> List.iter (fun (c,v) -> if du + c < d.[v] then Array.set d v (du+c); push (d.[v],v) pq)
        loop ()
    loop ()

  (Array.create N [], Ia)
  ||> Array.fold (fun g (a,b,c,d) ->
    let c0 = (int64 c)*10000L - (int64 d)
    g.[a-1] <- (c0,b-1)::g.[a-1]
    g.[b-1] <- (c0,a-1)::g.[b-1]
    g)
  |> dijkstra N 0 |> Array.last |> fun d -> ((d+9999L)/10000L, 10000L-(d%10000L))

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = Array.init M (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1],x.[2],x.[3])
solve N M Ia |> fun (x,y) -> [|string x; string y|] |> String.concat " " |> stdout.WriteLine

solve 3 3 [|(1,2,70,1);(2,3,20,1);(1,3,90,0)|] |> should equal (90L,2L)
