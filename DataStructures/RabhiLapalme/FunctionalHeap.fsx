#r "nuget: FsUnit"
open FsUnit

#load "BinTree.fsx"
open BinTree

type Heap<'a when 'a: comparison> = int * BinTree<'a>

let emptyHeap: Heap<'a> = (0, EmptyBT)
let heapEmpty: Heap<'a> -> bool = fun (n,_) -> n=0

let rec findTree: int -> BinTree<'a> -> 'a = fun i -> function
  | NodeBT(v,lf,rt) ->
    if i=1 then v
    else if i%2=0 then findTree (i/2) lf
    else findTree (i/2) rt
  | _ -> failwith "undefined"

let findHeap: int -> Heap<'a> -> 'a = fun i (n,t) ->
  if 0<i && i<=n then findTree i t
  else failwith "findHeap: element not found in Heap"

let rec insTree: 'a -> int -> BinTree<'a> -> BinTree<'a> = fun v' i btree ->
  match (v',i,btree) with
    | (_, 1, _) -> NodeBT(v', EmptyBT, EmptyBT)
    | (_,i, NodeBT(v,lf,rt)) ->
      let (small,big) = if v<= v' then(v,v') else (v',v)
      if i%2=0 then NodeBT(small, insTree big (i/2) lf, rt)
      else NodeBT(small, lf, insTree big (i/2) rt)
    | _ -> failwith "undefined"

let insHeap: 'a -> Heap<'a> -> Heap<'a> = fun v (n,t) -> (n+1, insTree v (n+1) t)

let rec delTreeLast: int -> BinTree<'a> -> 'a * BinTree<'a> = fun i t ->
  match t with
    | Node(v,lf,rt) ->
      if i=1 then (v, EmptyBT)
      else i%2=0 then let (v',lf') = delTreeLast(i/2) lf in (v', NodeBT(v,lf',rt'))
      else let(v',rt') = delTreeLast (i/2) rt in (v', NodeBT(v,lf,rt'))
    | _ -> failwith "undefined"

let node = NodeBT(1,EmptyBT,EmptyBT)
let (NodeBT(v0,lf0,rt0)) = node

let rec pdown: 'a -> BinTree<'a> -> BinTree<'a> when 'a: comparison = fun v' -> function
  | EmptyBT -> EmptyBT
  | NodeBT(_, EmptyBT, EmptyBT) -> NodeBT(v', EmptyBT, EmptyBT)
  | NodeBT(_, NodeBT(v,lf,rt), EmptyBT) ->
    if v<v' then NodeBT(v, NodeBT(v',lf,rt), EmptyBT)
    else NodeBT(v', NodeBT(v,lf,rt), EmptyBT)
  | NodeBT(v0, lf, rt) ->
    let (NodeBT(vlf,lflf,rtlf)) = lf
    let (NodeBT(vrt,lfrt,rtrt)) = rt
    if vlf<vrt then if v'<vlf then NodeBT(v',lf,rt) else NodeBT(vlf, pdown v' lf, rt)
    else if v'<vrt then NodeBT(v',lf,rt) else NodeBT(vrt, lf, pdown v' rt)

let rec delTree: int -> 'a -> BinTree<'a> -> 'a * BinTree<'a> = fun i v' t ->
  match t with
    | NodeBT(v,lf,rt) ->
      let (small,big) = if v<=v' then (v,v') else (v',v)
      if i=1 then (v, pdown v' t)
      else if i%2=0 then let (v'', lf'') = delTree (i/2) big lf in (v'', NodeBT(small,lf'',rt))
      else let (v'',rt'') = delTree (i/2) big rt in (v'', NodeBT(big,lf,rt''))
    | _ -> failwith "undefined"

"""TODO: delHeap"""

let () =
  heapEmpty emptyHeap |> should be True
  let h1 = insHeap 1 emptyHeap
  let h2 = insHeap 2 h1
  let h3 = insHeap 3 h2
  h1 |> should equal (1, NodeBT (1, EmptyBT, EmptyBT))
  h2 |> should equal (2, NodeBT (1, NodeBT (2, EmptyBT, EmptyBT), EmptyBT))
  h3 |> should equal (3, NodeBT (1, NodeBT (2, EmptyBT, EmptyBT), NodeBT (3, EmptyBT, EmptyBT)))
  findHeap 1 h3 |> should equal 1
  findHeap 2 h3 |> should equal 2
  (fun () -> findHeap 4 h3 |> ignore) |> should throw typeof<System.Exception>
