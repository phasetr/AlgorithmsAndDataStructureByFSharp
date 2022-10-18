// http://lepensemoi.free.fr/index.php/2010/01/07/bottom-up-merge-sort
module BottomUpMergeSortBySeq =
  type Sortable<'a> = int * seq<list<'a>>
  let (|SeqEmpty|SeqCons|) (xs: 'a seq) = if Seq.isEmpty xs then SeqEmpty else SeqCons(Seq.head xs, Seq.tail xs)

  let rec merge: list<'a> -> list<'a> -> list<'a> when 'a: comparison = fun xs ys ->
    match xs, ys with
    | [], ys -> ys
    | xs, [] -> xs
    | x::tlx, y::tly -> if x <= y then x :: merge tlx ys else y :: merge xs tly

  let empty: Sortable<'a> = (0, Seq.empty)

  let isEmpty: Sortable<'a> -> bool = fun (n, _) -> n = 0

  let singleton: 'a -> Sortable<'a> = fun x -> (1, Seq.singleton [x])

  let rec addSeg: list<'a> -> seq<list<'a>> -> int -> seq<list<'a>> = fun seg segs size ->
    if size%2 = 0 then Seq.append (Seq.singleton seg) segs
    else addSeg (merge seg (Seq.head segs)) (Seq.tail segs) (size / 2)

  let add: 'a -> Sortable<'a> -> Sortable<'a> = fun x (size, segs) ->
    (size + 1, addSeg [x] segs size)

  let rec mergeAll: list<'a> -> seq<list<'a>> -> list<'a> when 'a: comparison = fun xs ys ->
    match ys with
    | SeqEmpty -> xs
    | SeqCons(seg,segs) -> mergeAll (merge xs seg) segs

  let sort: Sortable<'a> -> list<'a> when 'a: comparison = fun (size, segs) ->
    mergeAll [] segs
