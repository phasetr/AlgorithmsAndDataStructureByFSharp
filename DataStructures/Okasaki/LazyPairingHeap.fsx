// http://lepensemoi.free.fr/index.php/2010/01/07/lazy-pairing-heap
module LazyPairingHeap =
  type t<'a> = E | T of 'a * t<'a> * Lazy<t<'a>>

  let empty: t<'a> = E

  let isEmpty: t<'a> -> bool = function E -> true | _ -> false

  let singleton: 'a -> t<'a> = fun x -> T(x, E, lazy E)

  let rec merge: t<'a> -> t<'a> -> t<'a> when 'a: comparison = fun t1 t2 ->
    match t1, t2 with
    | E, h -> h
    | h, E -> h
    | T(x, _, _), T(y, _, _) ->
        if x <= y then link t1 t2 else link t2 t1

  and link: t<'a> -> t<'a> -> t<'a> when 'a: comparison = fun t1 t2 ->
    match t1, t2 with
    | T(x, E, m), a -> T(x, a, m)
    | T(x, b, m), a -> T(x, E, lazy merge (merge a b) (m.Force()))
    | _ -> failwith "should not get there"

  let insert: 'a -> t<'a> -> t<'a> when 'a: comparison = fun x a -> merge (singleton x) a

  let rec contains: 'a -> t<'a> -> bool when 'a: equality = fun x -> function
    | E -> false
    | T (y, a, b) ->
        x = y || contains x a || contains x (b.Force())

  let findMin: t<'a> -> 'a = function
    | E -> failwith "empty"
    | T(x, _, _) -> x

  let deleteMin: t<'a> -> t<'a> when 'a: comparison = function
    | E -> failwith "empty"
    | T(x, a, b) -> merge a (b.Force())

  let rec remove: t<'a> -> t<'a> -> t<'a> when 'a: comparison = fun x -> function
    | E -> E
    | T(y, a, b) as t ->
        if a = x
        then merge a (b.Force())
        else T(y, remove x a, lazy remove x (b.Force()))
