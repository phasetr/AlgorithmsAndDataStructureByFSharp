// ../AOJ/ALDS1/12C_fs_00.fsx
module DestructivePriorityQueue =
  type 'a PQ = {mutable cnt : int; hp : 'a array; compare : 'a -> 'a -> int}
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
      let l,r = 2*i,2*i+1
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

#r "nuget: FsUnit"
open FsUnit
open DestructivePriorityQueue
let N = 10
let pqN n = create n 0 (compare: int -> int -> int)
pqN N |> fun pq -> [|0..8|] |> Array.iter (fun i -> push i pq); pq
