// http://lepensemoi.free.fr/index.php/2009/12/31/lazy-binomial-heap
module LazyBinomialHeap =
  type BinomialTree<'a> = Node of (int * 'a * list<BinomialTree<'a>>)
  type t<'a> = Lazy<list<BinomialTree<'a>>>

  let empty: unit -> Lazy<'a list> = fun () -> lazy []

  let isEmpty: t<'a> -> bool = fun x -> x.Force() = []

  let rank: BinomialTree<'a> -> int = fun (Node(r, _, _)) -> r

  let root: BinomialTree<'a> -> 'a = fun (Node(_, x, _)) -> x

  let link: BinomialTree<'a> -> BinomialTree<'a> -> BinomialTree<'a> when 'a: comparison =
    fun (Node(r, x1, xs1) as n1) (Node(_, x2, xs2) as n2) ->
      if x1 <= x2 then Node(r+1, x1, n2 :: xs1)
      else Node(r+1, x2, n1 :: xs2)

  let rec insertTree: BinomialTree<'a> -> list<BinomialTree<'a>> -> list<BinomialTree<'a>> when 'a: comparison =
    fun t -> function
      | [] -> [t]
      | hd::tl as t' -> if rank t < rank hd then t::t' else insertTree (link t hd) tl

  let singletonTree: 'a -> BinomialTree<'a> = fun x -> Node(0, x, [])

  let singleton: 'a -> t<'a> = fun x -> lazy [singletonTree x]

  // let insert x t = lazy insertTree (singletonTree x) (Lazy.force t)
  // let insert x (t: t<'a>) = lazy insertTree (singletonTree x) (t.Force())
  let insert: 'a -> t<'a> -> t<'a> = fun x t -> lazy insertTree (singletonTree x) (t.Force())

  let rec mrg: list<BinomialTree<'a>> -> list<BinomialTree<'a>> -> list<BinomialTree<'a>> when 'a: comparison = fun h1 h2 ->
    match h1, h2 with
    | [], x | x, [] -> x
    | hd1::tl1, hd2::tl2 ->
        if rank hd1 < rank hd2 then hd1 :: mrg tl1 h2
        elif rank hd1 > rank hd2 then hd2 :: mrg h1 tl2
        else insertTree (link hd1 hd2) (mrg tl1 tl2)

  let merge: t<'a> -> t<'a> -> t<'a> when 'a: comparison = fun h1 h2 ->
    lazy mrg (h1.Force()) (h2.Force())

  let rec removeMinTree: list<BinomialTree<'a>> -> BinomialTree<'a> * list<BinomialTree<'a>> when 'a: comparison = function
    | [] -> failwith "remove from an empty tree"
    | [t] -> t, []
    | hd::tl ->
      let hd', tl'= removeMinTree tl
      if root hd <= root hd' then hd, tl else hd', hd::tl'

  let findMin: list<BinomialTree<'a>> -> 'a when 'a: comparison = fun h ->
    let (t, _) = removeMinTree h in root t

  let removeMin: t<'a> -> t<'a> when 'a: comparison = fun h ->
    let Node(_, x, xs1), xs2 = removeMinTree (h.Force()) in lazy mrg (List.rev xs1) xs2
