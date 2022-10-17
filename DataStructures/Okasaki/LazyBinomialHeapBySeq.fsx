// http://lepensemoi.free.fr/index.php/2009/12/31/lazy-binomial-heap
module LazyBinomialHeapBySeq =
  type BinomialTree<'a> = Node of (int * 'a * seq<BinomialTree<'a>>)
  type t<'a> = seq<BinomialTree<'a>>

  let (|SeqEmpty|SeqCons|) (xs: 'a seq) = if Seq.isEmpty xs then SeqEmpty else SeqCons(Seq.head xs, Seq.tail xs)

  let empty: unit -> seq<'a> = fun () -> Seq.empty
  let isEmpty: t<'a> -> bool = fun x -> Seq.isEmpty x

  let rank: BinomialTree<'a> -> int = fun (Node(r, _, _)) -> r

  let root: BinomialTree<'a> -> 'a = fun (Node(_, x, _)) -> x

  let link: BinomialTree<'a> -> BinomialTree<'a> -> BinomialTree<'a> when 'a: comparison =
    fun (Node(r, x1, xs1) as n1) (Node(_, x2, xs2) as n2) ->
      if x1 <= x2 then Node(r+1, x1, Seq.append (seq {n2}) xs1)
      else Node(r+1, x2, Seq.append (seq {n1}) xs2)

  let rec insertTree: BinomialTree<'a> -> seq<BinomialTree<'a>> -> seq<BinomialTree<'a>> when 'a: comparison =
    fun t -> function
      | SeqEmpty -> Seq.singleton t
      | SeqCons(hd,tl) as t' -> if rank t < rank hd then Seq.append (seq {t}) t' else insertTree (link t hd) tl

  let singletonTree: 'a -> BinomialTree<'a> = fun x -> Node(0, x, Seq.empty)

  let singleton: 'a -> t<'a> = fun x -> seq {singletonTree x}

  let insert: 'a -> t<'a> -> t<'a> = fun x t -> insertTree (singletonTree x) t

  let rec merge: t<'a> -> t<'a> -> t<'a> when 'a: comparison = fun h1 h2 ->
    match h1, h2 with
    | SeqEmpty, x | x, SeqEmpty -> x
    | SeqCons(hd1,tl1), SeqCons(hd2,tl2) ->
        if rank hd1 < rank hd2 then Seq.append (Seq.singleton hd1) (merge tl1 h2)
        elif rank hd1 > rank hd2 then Seq.append (Seq.singleton hd2) (merge h1 tl2)
        else insertTree (link hd1 hd2) (merge tl1 tl2)

  let rec removeMinTree: t<'a> -> BinomialTree<'a> * t<'a> when 'a: comparison = function
    | SeqEmpty -> failwith "remove from an empty tree"
    | SeqCons(hd,tl) ->
      if isEmpty tl then (hd, Seq.empty)
      else
        let hd', tl'= removeMinTree tl
        if root hd <= root hd' then hd, tl else hd', (Seq.append (seq {hd}) tl')

  let findMin: t<'a> -> 'a when 'a: comparison = fun h ->
    let (t, _) = removeMinTree h in root t

  let removeMin: t<'a> -> t<'a> when 'a: comparison = fun h ->
    let Node(_, x, xs1), xs2 = removeMinTree h in merge (Seq.rev xs1) xs2
