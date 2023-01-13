(*
A priority queue is a queue in which each item has a priority associated with it.
Official implementation: https://github.com/fsprojects/FSharpx.Collections/blob/master/src/FSharpx.Collections/PriorityQueue.fs#L290
cf. https://stackoverflow.com/questions/3326512/f-priority-queue

The below list implementation is from Rabni-Lapalme, P.92.
Items are held in a sorted list.
*)
#r "nuget: FsUnit"
open FsUnit

type 'a PQueue = PQ of 'a list

let emptyPQ = PQ []

let pqEmpty x =
  match x with
    | PQ [] -> true
    | _ -> false

let rec insert x q =
  match x, q with
    | x, [] -> [ x ]
    | x, (e :: r') -> if x <= e then x :: q else e :: insert x r'

let enPQ x (PQ q) = PQ (insert x q)

let dePQ (PQ q) =
  match q with
    | [] -> failwith "dePQ: empty priority queue"
    | x :: xs -> PQ xs

let frontPQ (PQ q) =
  match q with
    | [] -> failwith "frontPQ: empty priority queue"
    | x :: xs -> x

// test
let () =
  emptyPQ |> should equal (PQ [])
  emptyPQ |> pqEmpty |> should be True
  emptyPQ |> enPQ 3 |> pqEmpty |> should be False
  emptyPQ |> enPQ 3 |> enPQ 1 |> should equal (PQ [1;3])
  let pq = emptyPQ |> enPQ 3 |> enPQ 1 |> enPQ 2
  pq |> dePQ |> should equal (PQ [2;3])
  pq |> frontPQ |> should equal 1
