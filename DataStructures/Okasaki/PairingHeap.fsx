// http://lepensemoi.free.fr/index.php/2009/12/17/pairing-heap
module PairingHeap =
  type t<'a> = E | T of 'a * list<t<'a>>

  let empty: t<'a> = E

  let isEmpty: t<'a> -> bool = function E -> true | _ -> false

  let singleton: 'a -> t<'a> = fun x -> T(x, [])

  let merge: t<'a> -> t<'a> -> t<'a> when 'a: comparison = fun t1 t2 ->
    match t1, t2 with
    | E, h -> h
    | h, E -> h
    | T(x, xs), T(y, ys) -> if x <= y then T(x, t2::xs) else T(y, t1::ys)

  let insert: 'a -> t<'a> -> t<'a> when 'a: comparison = fun x t -> merge (singleton x) t

  let rec mergePairs: list<t<'a>> -> t<'a> when 'a: comparison = function
    | [] -> E
    | [x] -> x
    | x::y::tl -> merge (merge x y) (mergePairs tl)

  let rec contains: 'a -> t<'a> -> bool when 'a: equality = fun x -> function
    | E -> false
    | T (a, ys) -> x = a || List.exists (contains x) ys

  let rec findMin: t<'a> -> 'a = function
    | E -> failwith "empty"
    | T(x, _) -> x

  let rec deleteMin: t<'a> -> t<'a> when 'a: comparison = function
    | E -> failwith "empty"
    | T(x, xs) -> mergePairs xs

  let rec remove: 'a -> t<'a> -> t<'a> when 'a: comparison = fun x -> function
    | E -> E
    | T(a, ys) as t -> if a = x then mergePairs ys else T(a, List.map (remove x) ys)
