// http://lepensemoi.free.fr/index.php/2009/11/27/custom-stack
module CustomStack =
  type t<'a> = Nil | Cons of ('a * t<'a>)

  let empty: t<'a> = Nil

  let isEmpty: t<'a> -> bool = function Nil -> true | _ -> false

  let cons: 'a -> t<'a> -> t<'a> = fun x cs -> Cons(x, cs)

  let singleton: 'a -> t<'a> = fun x -> cons x empty

  let head: t<'a> -> 'a = function
    | Nil -> failwith "empty"
    | Cons (hd, tl) -> hd

  let tail: t<'a> -> t<'a> = function
    | Nil -> failwith "empty"
    | Cons (hd, tl) -> tl

  let rec append: t<'a> -> t<'a> -> t<'a> = fun x y ->
    match x with
    | Nil -> y
    | Cons(hd, tl) -> Cons(hd, append tl y)

  let rec set: t<'a> -> int -> 'a -> t<'a> = fun xs i x ->
    match xs, i with
    | Nil, _ -> failwith "subscript"
    | Cons(hd, tl), 0 -> Cons(x, tl)
    | Cons(hd, tl), n -> Cons(hd, set tl (i-1) x)
