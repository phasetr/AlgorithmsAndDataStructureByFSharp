// http://lepensemoi.free.fr/index.php/2010/01/07/bottom-up-merge-sort
module BottomUpMergeSort =
  type Sortable<'a> = int * Lazy<list<list<'a>>>

  let rec merge: list<'a> -> list<'a> -> list<'a> when 'a: comparison = fun xs ys ->
    match xs, ys with
    | [], ys -> ys
    | xs, [] -> xs
    | x::tlx, y::tly -> if x <= y then x :: merge tlx ys else y :: merge xs tly

  let empty: unit -> Sortable<'a> = fun () -> (0, lazy [])

  let isEmpty: Sortable<'a> -> bool = fun (n, _) -> n = 0

  let singleton: 'a -> Sortable<'a> = fun x -> (1, lazy [[x]])

  let rec addSeg: list<'a> -> list<list<'a>> -> int -> 'a list list = fun seg segs size ->
    if size % 2 = 0 then seg::segs
    else addSeg (merge seg (List.head segs)) (List.tail segs) (size / 2)

  let add: 'a -> Sortable<'a> -> Sortable<'a> when 'a: comparison = fun x (size, segs) ->
    size+1, lazy addSeg [x] (segs.Force()) size

  let rec mergeAll: list<'a> -> list<list<'a>> -> list<'a> when 'a: comparison = fun xs ys ->
    match ys with
    | [] -> xs
    | seg::segs -> mergeAll (merge xs seg) segs

  let sort: Sortable<'a> -> list<'a> when 'a: comparison =
    fun (size, segs) -> mergeAll [] (segs.Force())
