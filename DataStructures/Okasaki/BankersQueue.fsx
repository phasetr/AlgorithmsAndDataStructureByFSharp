// http://lepensemoi.free.fr/index.php/2009/12/31/bankers-queue
module BankersQueue
  type t<'a> = {
    FrontLength : int
    Front : seq<'a>
    BackLength : int
    Back : seq<'a>
  }

  let empty: t<'a> = {
    FrontLength = 0
    Front = Seq.empty
    BackLength = 0
    Back = Seq.empty
  }

  let isEmpty: t<'a> -> bool = fun x -> x.FrontLength = 0

  let singleton: 'a -> t<'a> = fun x -> {
    FrontLength = 1
    Front = Seq.singleton x
    BackLength = 0
    Back = Seq.empty
  }

  let check: t<'a> -> t<'a> = fun x ->
    if x.BackLength < x.FrontLength
    then x
    else
      { FrontLength = x.BackLength + x.FrontLength
        Front = Seq.rev x.Back |> Seq.append x.Front
        BackLength = 0
        Back = Seq.empty
      }

  let snoc: 'a -> t<'a> -> t<'a> = fun x q ->
    { q with
        BackLength = q.BackLength + 1
        Back = Seq.append (seq {x}) q.Back
    } |> check

  let head: t<'a> -> 'a = function
    | {FrontLength = 0} -> failwith "empty"
    | q -> Seq.head q.Front

  let tail: t<'a> -> t<'a> = function
    | {FrontLength = 0} -> failwith "empty"
    | q ->
      {q with
        FrontLength = q.FrontLength - 1
        Front = Seq.tail q.Front
      } |> check
