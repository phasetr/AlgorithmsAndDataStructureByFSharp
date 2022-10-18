// http://lepensemoi.free.fr/index.php/2010/01/21/hood-melville-queue
module HoodMelvilleQueue =
  type RotationState<'a> =
    | Idle
    | Reversing of int * list<'a> * list<'a> * list<'a> * list<'a>
    | Appending of int *list<'a> * list<'a>
    | Done of list<'a>

  type t<'a> = {
    FrontLength : int
    Front : list<'a>
    State : RotationState<'a>
    RBackLength : int
    RBack : list<'a>
  }

  let create: int -> list<'a> -> RotationState<'a> -> int -> list<'a> -> t<'a> = fun lenf f state lenr r ->
    {
      FrontLength = lenf
      Front = f
      State = state
      RBackLength = lenr
      RBack = r
    }

  let exec: RotationState<'a> -> RotationState<'a> = function
    | Reversing(ok, x::f, f', y::r, r') -> Reversing(ok+1, f, x::f', r, y::r')
    | Reversing(ok, [], f', [y], r') -> Appending(ok, f', y::r')
    | Appending(0, f', r') -> Done r'
    | Appending(ok, x::f', r') -> Appending(ok-1, f', x::r')
    | state -> state

  let invalidate: RotationState<'a> -> RotationState<'a> = function
    | Reversing(ok, f, f', r, r') -> Reversing(ok-1, f, f', r, r')
    | Appending(0, f', x::r') -> Done r'
    | Appending(ok, f', r') -> Appending(ok-1, f', r')
    | state -> state

  let exec2: t<'a> -> t<'a> = fun q ->
    match exec (exec q.State) with
    | Done newf -> {q with Front = newf ; State = Idle }
    | newstate -> {q with State = newstate }

  let check: t<'a> -> t<'a> = fun q ->
    if q.RBackLength <= q.FrontLength then exec2 q
    else
      let newstate = Reversing(0, q.Front, [], q.RBack, [])
      create (q.FrontLength + q.RBackLength) q.Front newstate 0 [] |> exec2

  let empty: unit -> t<'a> = fun () -> create 0 [] Idle 0 []

  let isEmpty: t<'a> -> bool = fun q -> q.FrontLength = 0

  let snoc: 'a -> t<'a> -> t<'a> = fun x q ->
    check {q with RBackLength = q.RBackLength + 1; RBack = x::q.RBack}

  let singleton: 'a -> t<'a> = fun x -> empty() |> snoc x

  let head: t<'a> -> 'a = fun q ->
    match q.Front with
    | hd::_ -> hd
    | _ -> failwith "empty"

  let tail: t<'a> -> t<'a> = fun q ->
    match q.Front with
    | hd::_ ->
      create (q.FrontLength-1) q.Front (invalidate q.State) q.RBackLength q.RBack
      |> check
    | _ -> failwith "empty"
