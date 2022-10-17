// http://lepensemoi.free.fr/index.php/2009/12/03/binary-search-tree
module BinarySearchTree =
  type t<'a> = E | T of (t<'a> * 'a * t<'a>)

  let empty: t<'a> = E

  let isEmpty: t<'a> -> bool = function E -> true | _ -> false

  let singleton: 'a -> t<'a> = fun x -> T(E, x, E)

  let rec contains: 'a -> t<'a> -> bool when 'a: comparison = fun x -> function
    | E -> false
    | T (a, y, b) ->
      x = y || (x > y && contains x b) || (x < y && contains x a)

  let rec insert: 'a -> t<'a> -> t<'a> = fun x -> function
    | E -> T(E, x, E)
    | T(a, y, b) as t ->
      if x = y then t
      elif x < y then T(insert x a, y, b)
      else T(a, y, insert x b)

  let rec remove: 'a -> t<'a> -> t<'a> = fun x -> function
    | E -> E
    | T(a, y, b) as t ->
      if x = y then E
      elif x < y then T(remove x a, y, b)
      else T(a, y, remove x b)
