// http://lepensemoi.free.fr/index.php/2010/01/21/scheduled-binomial-heap
module ScheduledBinomialHeap =
  type Tree<'a> = Node of ('a * list<Tree<'a>>)
  type Digit<'a> = option<Tree<'a>>
  type Digits<'a> = seq<Digit<'a>>
  type Schedule<'a> = list<Digits<'a>>
  type t<'a> = Digits<'a> * Schedule<'a>
  let (|SeqEmpty|SeqCons|) (xs: 'a seq) = if Seq.isEmpty xs then SeqEmpty else SeqCons(Seq.head xs, Seq.tail xs)

  let empty: t<'a> = Seq.empty, []

  let singleton: Tree<'a> -> t<'a> = fun x -> (Seq.singleton (Some x), [])

  let isEmpty: t<'a> -> bool = fun (x, _) -> Seq.isEmpty x

  let link (Node(x1, c1) as t1) (Node(x2, c2) as t2) =
    if x1 <= x2 then Node (x1, t2::c1) else Node(x2, t1::c2)

  let rec insTree: Tree<'a> -> Digits<'a> -> Digits<'a> = fun t -> function
    | SeqEmpty -> Some t |> Seq.singleton
    | SeqCons(None, tl) -> Seq.append (Some t |> Seq.singleton) tl
    | SeqCons(Some hd, tl) -> Seq.append (Seq.singleton None) (insTree (link t hd) tl)

  let rec mrg: Digits<'a> -> Digits<'a> -> Digits<'a> = fun ds1 ds2 ->
    match ds1, ds2 with
    | ds1, SeqEmpty -> ds1
    | SeqEmpty, ds2 -> ds2
    | SeqCons(None, tl1), SeqCons(hd, tl2)
    | SeqCons(hd, tl1), SeqCons(None, tl2) -> Seq.append (Seq.singleton hd) (mrg tl1 tl2)
    | SeqCons(Some x1, tl1), SeqCons(Some x2, tl2) ->
        Seq.append (Seq.singleton None) (insTree (link x1 x2) (mrg tl1 tl2))

  let rec exec: Schedule<'a> -> Schedule<'a> = function
    | [] -> []
    | SeqCons(None, job) :: sched -> job::sched
    | _::sched -> sched

  let insert: 'a -> (Digits<'a> * Schedule<'a>) -> (Digits<'a> * Schedule<'a>) when 'a: comparison = fun x (ds, sched) ->
    let ds' = insTree (Node(x, [])) ds
    (ds', exec (exec (ds'::sched)))

  let merge: t<'a> -> t<'a> -> t<'a> = fun (ds1, _) (ds2, _) -> (mrg ds1 ds2, [])

  let rec removeMinTree: Digits<'a> -> Tree<'a> * Digits<'a> when 'a: comparison = function
    | SeqEmpty -> failwith "empty"
    | SeqCons(Some t, SeqEmpty) -> (t, Seq.empty)
    | SeqCons(None, ds) ->
      let t', ds' = removeMinTree ds in  (t', Seq.append (Seq.singleton None) ds')
    | SeqCons(Some (Node (x,_) as t), ds) ->
      let t', ds' = removeMinTree ds
      match t' with
      | Node(x', _) ->
        if x <= x' then t, Seq.append (Seq.singleton None) ds
        else t', Seq.append (Some t |> Seq.singleton) ds'

  let findMin: t<'a> -> 'a = fun (ds, _) -> let Node(x, _), _ = removeMinTree ds in x

  let removeMin: t<'a> -> t<'a> when 'a: comparison = fun (ds, _) ->
    let Node(x, c), ds' = removeMinTree ds
    (mrg (List.map Some (List.rev c)) ds', [])
