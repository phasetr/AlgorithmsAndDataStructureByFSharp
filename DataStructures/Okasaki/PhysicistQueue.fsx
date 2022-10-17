// http://lepensemoi.free.fr/index.php/2009/12/31/physicist-queue
module PhysicistsQueue =
  type t<'a> = {
    Prefix : seq<'a>
    FrontLength : int
    Front : seq<'a>
    RBackLength : int
    RBack : seq<'a>
  }

  let empty: t<'a> = {
    Prefix = Seq.empty
    FrontLength = 0
    Front = Seq.empty
    RBackLength = 0
    RBack = Seq.empty
  }

  let isEmpty: t<'a> -> bool = fun q -> q.FrontLength = 0

  let checkw: t<'a> -> t<'a> =
    fun q -> if Seq.isEmpty q.Prefix then {q with Prefix = q.Front} else q

  let check: t<'a> -> t<'a> = fun q ->
    if q.RBackLength < q.FrontLength then checkw q
    else
      { Prefix = q.Front
        FrontLength = q.RBackLength + q.FrontLength
        Front = q.RBack |> Seq.rev |> Seq.append q.Prefix
        RBackLength = 0
        RBack = Seq.empty
      }

  let snoc: 'a -> t<'a> -> t<'a> = fun x q ->
    { q with
        RBackLength = q.RBackLength + 1
        RBack = Seq.append (seq {x}) q.RBack
    } |> check

  let singleton: 'a -> t<'a> = fun x -> empty |> snoc x

  let head: t<'a> -> 'a = fun q -> Seq.head q.Prefix

  let tail: t<'a> -> t<'a> = fun q ->
    if Seq.isEmpty q.Prefix then failwith "empty"
    else
      {q with
        FrontLength = q.FrontLength - 1
        Front = q.Front |> Seq.tail
      } |> check
