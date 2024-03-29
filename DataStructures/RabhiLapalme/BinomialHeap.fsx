#r "nuget: FsUnit"
open FsUnit

type Tree<'a> = Node of int * 'a * Tree<'a> list
type Heap<'a> = BH of Tree<'a> list

let rank: Tree<'a> -> int = function | Node(r,_,_) -> r
let root: Tree<'a> -> 'a = function | Node(_,x,_) -> x

let link: Tree<'a> -> Tree<'a> -> Tree<'a> = fun (Node(r1,x1,c1) as t1) (Node(r2,x2,c2) as t2) ->
  if x1<=x2 then Node(r1+1, x1, t2::c1)
  else Node(r1+1, x2, t1::c2)

let rec insTree: Tree<'a> -> Tree<'a> list -> Tree<'a> list = fun t -> function
  | [] -> [t]
  | t' :: ts' as ts ->
    if rank t < rank t' then t::ts
    else insTree (link t t') ts'

let rec mrg: Tree<'a> list -> Tree<'a> list -> Tree<'a> list = fun ts1 ts2 ->
  match (ts1, ts2) with
    | (_,[]) -> ts1
    | ([],_) -> ts2
    | (t1::ts1', t2::ts2') ->
      if rank t1 < rank t2 then t1 :: (mrg ts1' ts2)
      else if rank t2 < rank t1 then t1 :: (mrg ts1 ts2')
      else insTree (link t1 t2) (mrg ts1' ts2')

let rec removeMinTree: Tree<'a> list -> Tree<'a> * Tree<'a> list = function
  | [] -> failwith "empty Heap"
  | [t] -> (t,[])
  | t::ts ->
    let (t', ts') = removeMinTree ts
    if root t < root t' then (t, ts) else (t', t :: ts')

let emptyHeap: Heap<'a> = BH []
let heapEmpty: Heap<'a> -> bool = fun (BH ts) -> List.isEmpty ts

let findHeap: Heap<'a> -> 'a = fun (BH ts) ->
  if List.isEmpty ts then  failwith "findHeap: not looking for first"
  else root (fst (removeMinTree ts))

let rec insHeap: int -> Heap<'a> -> Heap<'a> = fun x (BH ts) -> BH (insTree (Node(0, x, [])) ts)

let delHeap: Heap<'a> -> Heap<'a> = fun (BH ts) ->
  if List.isEmpty ts then failwith "delHeap: empty"
  else
    let (Node(rk, rt, ts1), ts2) = removeMinTree ts
    BH (mrg (List.rev ts1) ts2)

let () =
  emptyHeap = BH []
  let h1 = insHeap 1 emptyHeap
  let h2 = insHeap 2 h1
  let h3 = insHeap 3 h2
  let h4 = insHeap 4 h3
  let h5 = insHeap 5 h4
  let h6 = insHeap 6 h5
  h1 |> should equal (BH [Node(0,1,[])])
  h2 |> should equal (BH [Node(1,1,[Node(0,2,[])])])
  h3 |> should equal (BH [Node(0,3,[]); Node (1, 1, [Node (0, 2, [])])])
  h4 |> should equal (BH [Node(2,1,[Node (1, 3, [Node (0, 4, [])]); Node (0, 2, [])])])
  h5 |> should equal (BH [Node(0,5,[]); Node (2, 1, [Node (1, 3, [Node (0, 4, [])]); Node (0, 2, [])])])
  h6 |> should equal (BH [Node(1,5,[Node (0, 6, [])]); Node (2, 1, [Node (1, 3, [Node (0, 4, [])]); Node (0, 2, [])])])
