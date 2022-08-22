#r "nuget: FsUnit"
open FsUnit

/// IMPLEMENTATION with Leftist Heap
/// adapted from C. Okasaki Purely Functional Data Structures p 197
type Heap<'a> = EmptyHP | HP of 'a * int * Heap<'a> * Heap<'a>

let emptyHeap: Heap<'a> = EmptyHP
let heapEmpty: Heap<'a> -> bool = function
  | EmptyHP -> true
  | _ -> false

let findHeap: Heap<'a> -> 'a = function
  | EmptyHP -> failwith "findHeap: empty heap"
  | HP(x,_,a,b) -> x

/// auxiliary function
let rank: Heap<'a> -> int = function
  | EmptyHP -> 0
  | HP(_,r,_,_) -> r

/// auxiliary function
let makeHP: 'a -> Heap<'a> -> Heap<'a> -> Heap<'a> = fun x a b ->
  if rank a >= rank b then HP(x, rank b + 1, a, b)
  else HP(x, rank a + 1, b, a)

/// auxiliary function
let rec merge: Heap<'a> -> Heap<'a> -> Heap<'a> = fun h1 h2 ->
  match (h1,h2) with
    | (_,EmptyHP) -> h1
    | (EmptyHP,_) -> h2
    | (HP(x,_,a1,b1), HP(y,_,a2,b2)) ->
      if x<=y then makeHP x a1 (merge b1 h2)
      else makeHP y a2 (merge h1 b2)

let insHeap: 'a -> Heap<'a> -> Heap<'a> = fun x h -> merge (HP(x,1,EmptyHP,EmptyHP)) h

let delHeap: Heap<'a> -> Heap<'a> = function
  | EmptyHP -> failwith "delHeap: empty heap"
  | HP(x,_,a,b) -> merge a b

let () =
  emptyHeap |> heapEmpty |> should be True
