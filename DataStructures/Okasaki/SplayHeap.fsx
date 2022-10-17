// http://lepensemoi.free.fr/index.php/tag/purely-functional-data-structures/page/2
module SplayHeap =
  type t<'a> = E | T of t<'a> * 'a * t<'a>

  let empty = E

  let isEmpty: t<'a> -> bool = function E -> true | _ -> false

  let singleton: 'a -> t<'a> = fun x -> T(E, x, E)

  let rec partition: 'a -> t<'a> -> t<'a> * t<'a> when 'a: comparison = fun pivot t ->
    match t with
    | E -> (E, E)
    | T (a, x, b) ->
      if x <= pivot then
        match b with
        | E -> (t, E)
        | T(b1, y, b2) ->
          if y <= pivot then let small, big = partition pivot b2 in T(T(a, x, b1), y, small), big
          else let small, big = partition pivot b1 in T(a, x, small), T(big, y, b2)
      else
        match a with
        | E -> E, t
        | T(a1, y, a2) ->
          if y <= pivot then let small, big = partition pivot a2 in T(a1, y, small), T(big, x, b)
          else let small, big = partition pivot a1 in small, T(big, y, T(a2, x, b))

  let rec insert: 'a -> t<'a> -> t<'a> when 'a: comparison = fun x t ->
    let small, big = partition x t in T(small, x, big)

  let rec contains: 'a -> t<'a> -> bool when 'a: comparison = fun x -> function
    | E -> false
    | T (a, y, b) -> x = y || (x < y && contains x a) || contains x b

  let rec remove: 'a -> t<'a> -> t<'a> when 'a: comparison = fun x -> function
    | E -> E
    | T(a, y, b) as t ->
      if x = y then E
      elif x < y then T(remove x a, y, b)
      else T(a, y, remove x b)

  let rec findMin: t<'a> -> 'a = function
    | E -> failwith "empty"
    | T(E,x,_) -> x
    | T(a,x,b) -> findMin a

  let rec deleteMin: t<'a> -> t<'a> = function
    | E -> failwith "empty"
    | T(E,x,b) -> b
    | T(T(E,x,b), y, c) -> T(b, y, c)
    | T(T(a,x,b), y, c) -> T(deleteMin a, x, T(b,y,c))

  let rec merge: t<'a> -> t<'a> -> t<'a> when 'a: comparison = fun t1 t2 ->
    match t1, t2 with
    | E, t -> t
    | T(a,x,b), t -> let ta, tb = partition x t in T(merge a ta, x, merge b tb)

  let rec iter: ('a -> unit) -> t<'a> -> unit = fun f -> function
    | E -> ()
    | T(a, x, b) -> iter f a; f x; iter f b
