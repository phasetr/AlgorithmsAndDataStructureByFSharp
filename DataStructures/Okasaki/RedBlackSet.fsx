// http://lepensemoi.free.fr/index.php/2009/12/10/red-black-set
//- Empty nodes are considered to be black
//- red nodes don't have any red child
//- every path from the root to an empty node
//  contains the same number of black nodes
module RedBlackSet =
  type Color = Red | Black
  type t<'a> = E | T of (Color * t<'a> * 'a * t<'a>)

  let empty: t<'a> = E

  let isEmpty: t<'a> -> bool = function E -> true | _ -> false

  let rec contains: 'a -> t<'a> -> bool when 'a: comparison = fun x -> function
    | E -> false
    | T(_, t1, y, t2) -> x = y || (x < y && contains x t1) || (x > y && contains x t2)

  let private lbalance: t<'a> -> t<'a> = function
    | T(Black, T(Red, T(Red,a,x,b), y, c), z, d)
    | T(Black, T(Red,a,x, T(Red,b,y,c)),z,d) ->
      T(Red, T(Black,a,x,b),y, T(Black,c,z,d))
    | t -> t

  let private rbalance: t<'a> -> t<'a> = function
    | T(Black, a, x, T(Red, T(Red,b,y,c), z, d))
    | T(Black, a, x, T(Red, b, y, T(Red,c,z,d))) ->
      T(Red, T(Black,a,x,b), y, T(Black,c,z,d))
    | t -> t

  let rec private insertAux: 'a -> _arg1: t<'a> -> t<'a> when 'a: comparison = fun x -> function
    | E -> T(Red, E, x, E)
    | T(c, t1, y, t2) as t ->
      if x = y then t
      elif x < y then lbalance <| T(c, insertAux x t1, y, t2)
      else rbalance <| T(c, t1, y, insertAux x t2)

  let rec insert: 'a -> t<'a> -> t<'a> when 'a: comparison = fun x t ->
    match insertAux x t with
    | T(color, t1, y, t2) -> T(Black, t1, y, t2)
    | _ -> failwith "should never get there"

  let singleton: 'a -> t<'a> when 'a: comparison = fun x -> insert x E

  let rec remove: 'a -> t<'a> -> t<'a> when 'a: comparison = fun x -> function
    | E -> E
    | T(c, a, y, b) as t ->
      if x = y then E
      elif x < y then T(c, remove x a, y, b)
      else T(c, a, y, remove x b)
