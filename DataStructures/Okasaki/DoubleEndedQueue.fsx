// http://lepensemoi.free.fr/index.php/2009/12/17/double-ended-queue
module DoubleEndedQueue =
  type t<'a> = list<'a> * list<'a>

  let empty: unit -> t<'a> = fun () -> [], []

  let isEmpty: t<'a> -> bool = function [], [] -> true | _ -> false

  let singleton: 'a -> t<'a> = fun x -> [x], []

  let rec private splitAux: int -> list<'a> -> list<'a> -> t<'a> = fun n r acc ->
    match r with
    | hd::tl when List.length acc < n -> splitAux n tl (hd::acc)
    | _ -> List.rev r, List.rev acc

  let private split: list<'a> -> t<'a> = fun r -> splitAux (List.length r / 2) r []

  let private checkf: t<'a> -> t<'a> = function
    | [], r -> split r
    | deq -> deq

  let private checkr: t<'a> -> t<'a> = function
    | f, [] -> let a, b = split f in b, a
    | deq -> deq

  //insert, inspect and remove the front element

  let cons: 'a -> t<'a> -> t<'a> = fun x (f, r) -> checkr (x::f, r)

  let rec head: t<'a> -> 'a = function
    | [], [] -> failwith "empty"
    | hd::tl, _ -> hd
    | [], xs -> List.rev xs |> List.head

  let rec tail: t<'a> -> t<'a> = function
    | [], [] -> failwith "empty"
    | hd::tl, r -> checkf (tl, r)
    | [], r -> split r |> tail

  //insert, inspect and remove the last element

  let snoc: 'a -> t<'a> -> t<'a> = fun x (f, r) -> checkf (f, x::r)

  let rec last: t<'a> -> 'a = function
    | [], [] -> failwith "empty"
    | xs, [] -> List.rev xs |> List.head
    | _, hd::tl -> hd

  let rec init: t<'a> -> t<'a> = function
    | [], [] -> failwith "empty"
    | f, hd::tl -> checkr (f, tl)
    | f, [] ->  split f |> init
