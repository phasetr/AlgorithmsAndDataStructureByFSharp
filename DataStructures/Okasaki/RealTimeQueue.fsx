// http://lepensemoi.free.fr/index.php/2010/01/07/real-time-queue
module RealTimeQueueBySeq =
  type t<'a> = seq<'a> * seq<'a> * seq<'a>
  let (|SeqEmpty|SeqCons|) (xs: 'a seq) = if Seq.isEmpty xs then SeqEmpty else SeqCons(Seq.head xs, Seq.tail xs)

  let empty: t<'a> = Seq.empty, Seq.empty, Seq.empty

  let isEmpty: t<'a> -> bool = fun (x, _, _) -> Seq.isEmpty x

  let rec rotate: t<'a> -> seq<'a> = fun (a, x, b) ->
    match a with
    | SeqEmpty -> Seq.append (Seq.head x |> Seq.singleton) b
    | SeqCons(hd, tl) ->
        let y = Seq.head x
        let ys = Seq.tail x
        let right = Seq.append (Seq.singleton y) b
        Seq.append (Seq.singleton hd) (rotate (tl, ys, right))

  let rec exec: t<'a> -> t<'a> = fun (f, r, right) ->
    match right with
    | SeqEmpty -> let f' = rotate (f, r, Seq.empty) in (f', Seq.empty, f')
    | SeqCons(hd, tl) -> f, r, tl

  let singleton: 'a -> t<'a> = fun  x -> Seq.empty, Seq.singleton x, Seq.empty

  let snoc: 'a -> t<'a> -> t<'a> = fun x (f, r, s) ->
    exec (f, Seq.append (Seq.singleton x) r, s)

  let head: t<'a> -> 'a = fun (a, x, b) ->
    match a with
    | SeqEmpty -> failwith "empty"
    | SeqCons(hd, tl) -> hd

  let tail: t<'a> -> t<'a> = fun (a, x, b) ->
    match a with
    | SeqEmpty -> failwith "empty"
    | SeqCons(hd, tl) -> exec (tl, x, b)
