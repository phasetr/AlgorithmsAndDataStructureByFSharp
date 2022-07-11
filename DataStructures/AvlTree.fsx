// https://en.wikibooks.org/wiki/F_Sharp_Programming/Advanced_Data_Structures#AVL_Trees
// height, left child, value, right child
type 'a Tree = | Nil | Node of int * 'a Tree * 'a * 'a Tree
(*
   Notation:
   h = height
   x = value
   l = left child
   r = right child

   lh = left child's height
   lx = left child's value
   ll = left child's left child
   lr = left child's right child

   rh = right child's height
   rx = right child's value
   rl = right child's left child
   rr = right child's right child
*)
let height = function
  | Node (h, _, _, _) -> h
  | Nil -> 0

let make l x r =
  let h = 1 + max (height l) (height r)
  Node(h, l, x, r)

let rotRight = function
  | Node (_, Node (_, ll, lx, lr), x, r) ->
    let r' = make lr x r
    make ll lx r'
  | node -> node

let rotLeft = function
  | Node (_, l, x, Node (_, rl, rx, rr)) ->
    let l' = make l x rl
    make l' rx rr
  | node -> node

let doubleRotLeft = function
  | Node (h, l, x, r) ->
    let r' = rotRight r
    let node' = make l x r'
    rotLeft node'
  | node -> node

let doubleRotRight = function
  | Node (h, l, x, r) ->
    let l' = rotLeft l
    let node' = make l' x r
    rotRight node'
  | node -> node

let balanceFactor = function
  | Nil -> 0
  | Node (_, l, _, r) -> (height l) - (height r)

let balance = function
  (* left unbalanced *)
  | Node (h, l, x, r) as node when balanceFactor node >= 2 ->
    if balanceFactor l >= 1
    then rotRight node (* left left case *)
  else doubleRotRight node (* left right case *)
  (* right unbalanced *)
  | Node (h, l, x, r) as node when balanceFactor node <= -2 ->
    if balanceFactor r <= -1
    then rotLeft node (* right right case *)
    else doubleRotLeft node (* right left case *)
  | node -> node

let rec insert v = function
  | Nil -> Node(1, Nil, v, Nil)
  | Node (_, l, x, r) as node ->
    if v = x then node
    else
      let l', r' = if v < x then insert v l, r else l, insert v r
      let node' = make l' x r'
      balance node'

let rec contains v = function
  | Nil -> false
  | Node (_, l, x, r) ->
    if v = x then true
    elif v < x then contains v l
    else contains v r

type AvlTree<'a when 'a: comparison>(tree: 'a Tree) =
  member this.Height = height tree
  member this.Left = match tree with
    | Node (_, l, _, _) -> new AvlTree<'a>(l)
    | Nil -> failwith "Empty tree"
  member this.Right = match tree with
    | Node (_, _, _, r) -> new AvlTree<'a>(r)
    | Nil -> failwith "Empty tree"
  member this.Value = match tree with
    | Node (_, _, x, _) -> x
    | Nil -> failwith "Empty tree"
  member this.Insert(x) = new AvlTree<'a>(insert x tree)
  member this.Contains(v) = contains v tree

module AvlTree =
  [<GeneralizableValue>]
  let empty<'a when 'a: comparison> : AvlTree<'a> = new AvlTree<'a>(Nil)
