// http://lepensemoi.free.fr/index.php/2009/12/03/leftist-heap
module LeftistHeap =
  type t<'a> = E | T of int * 'a * t<'a> * t<'a>

  let empty: t<'a> = E

  let isEmpty: t<'a> -> bool = function E -> true | _ -> false

  let rank: t<'a> -> int = function E -> 0 | T(r, _, _, _) -> r

  let make: 'a -> t<'a> -> t<'a> -> t<'a> = fun x a b ->
    if rank a > rank b then T(rank b + 1, x, a, b) else T(rank a + 1, x, b, a)

  let singleton: 'a -> t<'a> = fun x -> make x E E

  let rec merge: t<'a> -> t<'a> -> t<'a> when 'a: comparison = fun h1 h2 ->
    match h1, h2 with
    | E, x | x, E -> x
    | T(_, x, a1, b1), T(_, y, a2, b2) ->
      if x < y then make x a1 (merge b1 h2) else make y a2 (merge h1 b2)

  let insert: 'a -> t<'a> -> t<'a> when 'a: comparison =
    fun x h -> merge (singleton x) h

  let findMin: t<'a> -> 'a =
    function E -> failwith "empty" | T(_, x, _, _) -> x

  let removeMin: t<'a> -> t<'a> when 'a: comparison =
    function E -> failwith "empty" | T(_, _, a, b) -> merge a b
