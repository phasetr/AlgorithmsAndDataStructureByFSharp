#r "nuget: FsUnit"
open FsUnit

type Heap<'a when 'a: comparison> =
  | EmptyHP
  | HP of 'a * int * 'a Heap * 'a Heap

let emptyHeap = EmptyHP

let heapEmpty = function
  | EmptyHP -> true
  | _ -> false

let findHeap = function
  | EmptyHP -> failwith "findHeap: empty heap"
  | HP (x, _, _, _) -> x

let rank = function
  | EmptyHP -> 0
  | HP (_, r, _, _) -> r

let makeHP x a b =
  if rank a >= rank b then HP(x, rank b + 1, a, b) else HP(x, rank a + 1, b, a)

let rec merge h1 h2 =  match h1, h2 with
  | h1, EmptyHP -> h1
  | EmptyHP, h2 -> h2
  | HP (x1, _, a1, b1), HP (x2, _, a2, b2) ->
    if x1 <= x2 then makeHP x1 a1 (merge b1 h2) else makeHP x2 a2 (merge h1 b2)

let insHeap x h = merge (HP(x, 1, EmptyHP, EmptyHP)) h

let delHeap = function
  | EmptyHP -> failwith "delHeap: empty heap"
  | HP (x, _, a, b) -> merge a b

let test =
  EmptyHP |> printfn "%A"
  EmptyHP |> heapEmpty |> should be True

  insHeap 1 EmptyHP |> should equal (HP(1,1,EmptyHP,EmptyHP))
  insHeap 1 EmptyHP |> insHeap 2 |> should equal (HP(1,1,HP (2,1,EmptyHP,EmptyHP),EmptyHP))
  insHeap 1 EmptyHP |> insHeap 2 |> insHeap 3 |> should equal (HP(1,2,HP (2,1,EmptyHP,EmptyHP),HP (3,1,EmptyHP,EmptyHP)))
  insHeap 1 EmptyHP |> insHeap 2 |> insHeap 3 |> insHeap 4 |> should equal (HP(1,2,HP (2,1,EmptyHP,EmptyHP),HP (3,1,HP (4,1,EmptyHP,EmptyHP),EmptyHP)))
