// http://lepensemoi.free.fr/index.php/2010/02/11/skew-binomial-heap
module SkewBinomialHeap =
  type Tree<'a> = Node of int * 'a * list<'a> * list<Tree<'a>>

  type t<'a> = list<Tree<'a>>

  let empty: t<'a> = []

  let isEmpty: t<'a> -> bool = List.isEmpty

  let rank: Tree<'a> -> int = fun (Node(r, x, xs, c)) -> r

  let root: Tree<'a> -> 'a = fun (Node(r, x, xs, c)) -> x

  let link: Tree<'a> -> Tree<'a> -> Tree<'a> when 'a: comparison =
    fun (Node(r, x1, xs1, c1) as t1) (Node(_, x2, xs2, c2) as t2) ->
      if x1 <= x2 then Node(r+1, x1, xs1, t2::c1)
      else Node(r+1, x2, xs2, t1::c2)

  let skewLink: 'a -> Tree<'a> -> Tree<'a> -> Tree<'a> when 'a: comparison =
    fun x t1 t2 ->
      let (Node(r, y, ys, c)) = link t1 t2
      if x <= y then Node(r, x, y::ys, c) else Node(r, y, x::ys, c)

  let rec insertTree: Tree<'a> * t<'a> -> t<'a> when 'a: comparison = function
    | t, [] -> [t]
    | t1, t2::ts ->
      if rank t1 < rank t2 then t1::t2::ts
      else insertTree ((link t1 t2) , ts)

  let rec mergeTrees: t<'a> * t<'a> -> t<'a> = function
    | t, [] -> t
    | [], t -> t
    | ((x::xs) as t1), ((y::ys) as t2) ->
      if rank x < rank y then x :: (mergeTrees(xs, t2))
      elif rank y < rank x then y :: (mergeTrees(t1, ys))
      else insertTree (link x y, mergeTrees (xs, ys))

  let normalize: t<'a> -> t<'a> = function
    | [] -> []
    | hd::tl -> insertTree (hd, tl)

  let insert: 'a -> t<'a> -> t<'a> when 'a: comparison = fun x -> function
    | t1::t2::rest when rank t1 = rank t2 -> skewLink x t1 t2 :: rest
    | ts -> Node(0, x, [], []) :: ts

  let merge: t<'a> -> t<'a> -> t<'a> when 'a: comparison =
    fun t1 t2 -> mergeTrees (normalize t1, normalize t2)

  let rec removeMinTree: t<'a> -> Tree<'a> * t<'a> when 'a: comparison = function
    | [] -> failwith "empty"
    | [t] -> t, []
    | t::ts ->
      let t', ts' = removeMinTree ts
      if root t <= root t' then t, ts else t', t::ts'

  let findMin: t<'a> -> 'a when 'a: comparison =
    fun ts -> let t, _ = removeMinTree ts in root t

  let rec insertAll: list<'a> * t<'a> -> t<'a> when 'a: comparison = function
    | [], ts -> ts
    | x::xs, ts -> insertAll (xs, insert x ts)

  let deleteMin: t<'a> -> t<'a> when 'a: comparison = fun ts ->
    let (Node(_, x, xs, ts1)), ts2 = removeMinTree ts
    insertAll (xs, merge (List.rev ts1) ts2)
