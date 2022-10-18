// http://lepensemoi.free.fr/index.php/2010/02/05/real-time-double-ended-queue
module RealTimeDequeue =
  type t<'a> = {
    C : int //c = 2 or 3
    FrontLength : int
    Front : seq<'a>
    StreamFront : seq<'a>
    RBackLength : int
    RBack : seq<'a>
    StreamRBack : seq<'a>
  }
  let (|SeqEmpty|SeqCons|) (xs: 'a seq) = if Seq.isEmpty xs then SeqEmpty else SeqCons(Seq.head xs, Seq.tail xs)

  let create: int -> int -> seq<'a> -> seq<'a> -> int -> seq<'a> -> seq<'a> -> t<'a> = fun c lenf f sf lenr r sr ->
    {
      C = c
      FrontLength = lenf
      Front = f
      StreamFront = sf
      RBackLength = lenr
      RBack = r
      StreamRBack = sr
    }

  let empty: c: int -> t<'a> = fun c ->
    create c 0 Seq.empty Seq.empty 0 Seq.empty Seq.empty

  let isEmpty: t<'a> -> bool = fun q -> q.FrontLength=0 && q.RBackLength=0

  let length: t<'a> -> int = fun q -> q.FrontLength + q.RBackLength

  let exec1: seq<'a> -> seq<'a> = function
    | SeqCons(x, s) -> s
    | s -> s

  let exec2: seq<'a> -> seq<'a> = fun x -> (exec1 >> exec1) x

  let rec rotateRev: int -> seq<'a> * seq<'a> * seq<'a> -> seq<'a> = fun c -> function
    | SeqEmpty, r, a -> Seq.append (Seq.rev r) a
    | SeqCons(x, f), r, a ->
      let a' = Seq.skip c r
      let b' = Seq.append (Seq.take c r) a |> Seq.rev
      Seq.append (Seq.singleton x) (rotateRev c (f, a', b'))

  let rec rotateDrop: int -> seq<'a> -> int -> seq<'a> -> seq<'a> = fun c f j r ->
    if j < c then rotateRev c (f, Seq.skip j r, Seq.empty)
    else
      match f with
      | SeqCons(x, f') -> Seq.append (Seq.singleton x) (rotateDrop c f' (j-c) (Seq.skip c r))
      | _ -> failwith "should not get there"

  let check: t<'a> -> t<'a> = fun q ->
    let n = length q
    if q.FrontLength > q.C * q.RBackLength + 1 then
      let i= n / 2
      let j = n - i
      let f' = Seq.take i q.Front
      let r' = rotateDrop q.C q.RBack i q.Front
      create q.C i f' f' j r' r'
    elif q.RBackLength > q.C * q.FrontLength + 1 then
      let j = n / 2
      let i = n - j
      let f' = Seq.take j q.RBack
      let r' = rotateDrop q.C q.Front j q.RBack
      create q.C i f' f' j r' r'
    else q

  let cons: 'a -> t<'a> -> t<'a> = fun x q ->
    create q.C (q.FrontLength+1) (Seq.append (Seq.singleton x) q.Front) (exec1 q.StreamFront) q.RBackLength q.RBack (exec1 q.StreamRBack)
    |> check

  let singleton: int -> 'a -> t<'a> = fun c x -> empty c |> cons x

  let head: t<'a> -> 'a = fun q ->
    match q.Front, q.RBack with
    | SeqEmpty, SeqEmpty -> failwith "empty"
    | SeqEmpty, SeqCons(x, _) -> x
    | SeqCons(x, _), _ -> x

  let tail: t<'a> -> t<'a> = fun q ->
    match q.Front, q.RBack with
    | SeqEmpty, SeqEmpty -> failwith "empty"
    | SeqEmpty, SeqCons(x, _) -> empty q.C
    | SeqCons(x, xs), _ ->
      create q.C (q.FrontLength-1) xs (exec2 q.StreamFront) q.RBackLength q.RBack (exec2 q.StreamRBack)
      |> check

  let snoc: 'a -> t<'a> -> t<'a> = fun x q ->
    create q.C q.FrontLength q.Front (exec1 q.StreamFront) (q.RBackLength+1) (Seq.append (Seq.singleton x) q.RBack) (exec1 q.StreamRBack)
    |> check

  let last: t<'a> -> 'a = fun q ->
    match q.Front, q.RBack with
    | SeqEmpty, SeqEmpty -> failwith "empty"
    | _, SeqCons(x, _) ->  x
    | SeqCons(x, _), SeqEmpty-> x

  let init: t<'a> -> t<'a> = fun q ->
    match q.Front, q.RBack with
    | SeqEmpty, SeqEmpty -> failwith "empty"
    | _, SeqEmpty -> empty q.C
    | _, SeqCons(x, xs) ->
      create q.C q.FrontLength (exec2 q.StreamFront) q.Front (q.RBackLength-1) xs (exec1 q.StreamRBack)
      |> check
