// http://lepensemoi.free.fr/index.php/2009/12/10/binomial-heap
module BinaryHeap =
  type BinomialTree<'a> = Node of (int * 'a * list<BinomialTree<'a>>)
  type t<'a> = list<BinomialTree<'a>>

  let empty: 'a list = []
  let isEmpty: 'a list -> bool = function [] -> true | _ -> false

  let rank: BinomialTree<'a> -> int = fun (Node(r, _, _)) -> r
  let root: BinomialTree<'a> -> 'a  = fun (Node(_, x, _)) -> x

  let link: BinomialTree<'a> -> BinomialTree<'a> -> BinomialTree<'a> when 'a: comparison =
    fun (Node(r, x1, xs1) as n1) (Node(_, x2, xs2) as n2) ->
      if x1 <= x2 then Node(r+1, x1, n2 :: xs1)
      else Node(r+1, x2, n1 :: xs2)

  let rec insertTree: BinomialTree<'a> -> BinomialTree<'a> list -> BinomialTree<'a> list when 'a: comparison = fun t -> function
    | [] -> [t]
    | hd::tl as t' ->
      if rank t < rank hd then t::t' else insertTree (link t hd) tl

  let singletonTree: 'a -> BinomialTree<'a> = fun x -> Node(0, x, [])
  let singleton: 'a -> BinomialTree<'a> list = fun x -> [singletonTree x]

  let insert: 'a -> BinomialTree<'a> list -> BinomialTree<'a> list when 'a: comparison =
    fun x t -> insertTree (singletonTree x) t

  let rec merge: BinomialTree<'a> list -> BinomialTree<'a> list -> BinomialTree<'a> list when 'a: comparison = fun h1 h2 ->
    match h1, h2 with
    | [], x -> x
    | x, [] -> x
    | (hd1::tl1), (hd2::tl2) ->
      if rank hd1 < rank hd2 then hd1 :: merge tl1 h2
      elif rank hd1 > rank hd2 then hd2 :: merge h1 tl2
      else insertTree (link hd1 hd2) (merge ( tl1) ( tl2))

  let rec removeMinTree: BinomialTree<'a> list -> BinomialTree<'a> * BinomialTree<'a> list when 'a: comparison = function
    | [] -> failwith "empty"
    | [t] -> t, []
    | hd::tl ->
        let hd', tl'= removeMinTree tl
        if root hd <= root hd' then hd, tl else hd', hd::tl'

  let findMin: BinomialTree<'a> list -> 'a when 'a: comparison =
    fun h -> let (t, _) = removeMinTree h in root t

  let removeMin: BinomialTree<'a> list -> BinomialTree<'a> list when 'a: comparison = fun h ->
    let Node(_, x, xs1), xs2 = removeMinTree h
    merge (List.rev xs1) xs2
