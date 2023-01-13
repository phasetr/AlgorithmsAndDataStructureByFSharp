#r "nuget: FsUnit"
open FsUnit

(*
let Q,Qa = 3,[|[|1;2420|];[|1;1650|];[|2|]|]
*)
type Tree = Node of int * int * Tree list
type Heap = BH of Tree list
let solve Q (Qa:int[][]) =
  let rank = fun (Node(r,_,_)) -> r
  let root = fun (Node(_,x,_)) -> x
  let link = fun (Node(r1,x1,c1) as t1) (Node(r2,x2,c2) as t2) ->
    if x1<=x2 then Node(r1+1, x1, t2::c1)
    else Node(r1+1, x2, t1::c2)
  let rec insTree = fun t -> function
    | [] -> [t]
    | t' :: ts' as ts ->
      if rank t < rank t' then t::ts
      else insTree (link t t') ts'
  let rec mrg = fun ts1 ts2 ->
    match (ts1, ts2) with
      | (_,[]) -> ts1
      | ([],_) -> ts2
      | (t1::ts1', t2::ts2') ->
        if rank t1 < rank t2 then t1 :: (mrg ts1' ts2)
        else if rank t2 < rank t1 then t1 :: (mrg ts1 ts2')
        else insTree (link t1 t2) (mrg ts1' ts2')
  let rec removeMinTree = function
    | [] -> failwith "empty Heap"
    | [t] -> (t,[])
    | t::ts ->
      let (t', ts') = removeMinTree ts
      if root t < root t' then (t, ts) else (t', t :: ts')
  let empty = BH []
  let isEmpty = fun (BH ts) -> List.isEmpty ts
  let peek = fun (BH ts) ->
    if List.isEmpty ts then failwith "peek: empty"
    else root (fst (removeMinTree ts))
  let rec enqueue = fun x (BH ts) -> BH (insTree (Node(0, x, [])) ts)
  let dequeue = fun (BH ts) ->
    if List.isEmpty ts then failwith "dequeue: empty"
    else let (Node(rk, rt, ts1), ts2) = removeMinTree ts in BH (mrg (List.rev ts1) ts2)

  (empty,Qa) ||> Array.fold (fun q qa ->
    match qa.[0] with
      | 1 -> enqueue qa.[1] q
      | 2 -> q |> peek |> stdout.WriteLine; q
      | _ -> q |> dequeue)

let Q = stdin.ReadLine() |> int
let Qa = Array.init Q (fun _ -> stdin.ReadLine().Split() |> Array.map int)
solve Q Qa |> ignore

(*
1650
*)
