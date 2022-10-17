// http://lepensemoi.free.fr/index.php/2009/12/10/batched-queue
module BatchedQueue =
  type t<'a> = {
    Front : list<'a>
    RBack : list<'a>
  }

  let create: list<'a> -> list<'a> -> t<'a> = fun f r -> { Front = f; RBack = r}

  let empty: unit -> t<'a> = fun () -> create ([]: list<'a>) ([]: list<'a>)

  let isEmpty: t<'a> -> bool = fun q -> List.isEmpty q.Front

  let private checkf: list<'a> * list<'a> -> t<'a> = function
    | [], r -> create (List.rev r) []
    | f, r -> create f r

  let head: t<'a> -> 'a = fun q -> List.head q.Front

  let tail: t<'a> -> t<'a> = fun q ->
    match q.Front with
    | hd::tl -> checkf (tl, q.RBack)
    | _ -> failwith "empty"

  let snoc: 'a -> t<'a> -> t<'a> = fun x q -> checkf (q.Front, x :: q.RBack)

  let singleton: 'a -> t<'a> = fun x -> empty() |> snoc x
