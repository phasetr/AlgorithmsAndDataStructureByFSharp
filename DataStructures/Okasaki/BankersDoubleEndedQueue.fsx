// http://lepensemoi.free.fr/index.php/2010/02/11/bankers-double-ended-queue
module BankersDequeue =
  type t<'a> = {
    C : int // c > 1
    FrontLength : int
    Front : seq<'a>
    RBackLength : int
    RBack : seq<'a>
  }
  let (|SeqEmpty|SeqCons|) (xs: 'a seq) = if Seq.isEmpty xs then SeqEmpty else SeqCons(Seq.head xs, Seq.tail xs)

  let create: int -> int -> seq<'a> -> int -> seq<'a> -> t<'a> = fun c lenf f lenr r ->
    {
      C = c
      FrontLength = lenf
      Front = f
      RBackLength = lenr
      RBack = r
    }

  let empty: int -> t<'a> = fun c -> create c 0 Seq.empty 0 Seq.empty

  let isEmpty: t<'a> -> bool = fun q -> q.FrontLength=0 && q.RBackLength=0

  let length: t<'a> -> int = fun q -> q.FrontLength + q.RBackLength

  let check: t<'a> -> t<'a> = fun q ->
    let n = length q
    if q.FrontLength > q.C * q.RBackLength + 1 then
      let i = n/2
      let j = n-i
      let f' = Seq.take i q.Front
      let r' = Seq.skip i q.Front |> Seq.rev |> Seq.append q.RBack
      create q.C i f' j r'
    elif q.RBackLength > q.C * q.FrontLength + 1 then
      let j = n/2
      let i = n-j
      let f' = Seq.take j q.RBack
      let r' = Seq.skip j q.RBack |> Seq.rev |> Seq.append q.Front
      create q.C i f' j r'
    else q

  let cons: 'a -> t<'a> -> t<'a> = fun x q ->
    create q.C (q.FrontLength+1) (Seq.append (Seq.singleton x) q.Front) q.RBackLength q.RBack
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
    | SeqCons(x, xs), _ -> create q.C (q.FrontLength-1) xs q.RBackLength q.RBack |> check

  let snoc: 'a -> t<'a> -> t<'a> = fun x q ->
    create q.C q.FrontLength q.Front (q.RBackLength+1) (Seq.append (Seq.singleton x) q.RBack)
    |> check

  let last: t<'a> -> 'a = fun q ->
    match q.Front, q.RBack with
    | SeqEmpty, SeqEmpty -> failwith "empty"
    | _, SeqCons(x, _) ->  x
    | SeqCons(x, _), SeqEmpty -> x

  let init: t<'a> -> t<'a> = fun q ->
    match q.Front, q.RBack with
    | SeqEmpty, SeqEmpty -> failwith "empty"
    | _, SeqEmpty -> empty q.C
    | _, SeqCons(x, xs) -> create q.C q.FrontLength q.Front (q.RBackLength-1) xs |> check
