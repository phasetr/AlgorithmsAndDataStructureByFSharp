// http://lepensemoi.free.fr/index.php/2010/02/05/binary-random-access-list
module BinaryRandomAccessList =
  type Tree<'a> =
    | Leaf of 'a
    | Node of int * Tree<'a> * Tree<'a>

  type t<'a> = list<option<Tree<'a>>>

  let empty: t<'a> = []

  let isEmpty: t<'a> -> bool = List.isEmpty

  let size: Tree<'a> -> int = function
    | Leaf _ -> 1
    | Node (w, _, _) -> w

  let link: Tree<'a> -> Tree<'a> -> Tree<'a> = fun t1 t2 ->
    Node(size t1 + size t2, t1, t2)

  let rec consTree: Tree<'a> * t<'a> -> t<'a> = function
    | t, [] -> [Some t]
    | t, None::ts -> Some t :: ts
    | t1, Some t2 :: ts -> None :: consTree ((link t1 t2) , ts)

  let rec unconsTree: t<'a> -> Tree<'a> * t<'a> = function
    | [] -> failwith "empty"
    | [Some t] -> t, []
    | Some t :: ts -> t, None::ts
    | None::ts ->
      match unconsTree ts with
      | Node(_, t1, t2), ts' -> t1, Some t2::ts'
      | _ -> failwith "should never get there"

  let cons: 'a -> t<'a> -> t<'a> = fun x ts -> consTree ((Leaf x), ts)

  let singleton: 'a -> t<'a> = fun x -> empty |> cons x

  let head: t<'a> -> 'a = function
    | Some (Leaf x) :: _ -> x
    | [] -> failwith "empty"
    | _ -> failwith "should not get there"

  let tail: t<'a> -> t<'a> = fun ts -> let _, ts' = unconsTree ts in ts'

  let rec lookupTree: int * Tree<'a> -> 'a = function
    | 0, Leaf x -> x
    | i, Leaf x -> failwith "subscript"
    | i, Node(w, t1, t2) ->
      if i < w / 2 then lookupTree (i, t1) else lookupTree (i - w/2, t2)

  let rec updateTree: int * 'a * Tree<'a> -> Tree<'a> = function
    | 0, y, Leaf x -> Leaf y
    | i, y, Leaf x -> failwith "subscript"
    | i, y, Node(w, t1, t2) ->
      if i < w / 2 then Node(w, updateTree (i, y, t1) , t2)
      else Node(w, t1, updateTree (i - w/2, y, t2))

  let rec lookup: int -> t<'a> -> 'a = fun i -> function
    | [] -> failwith "subscript"
    | None::ts -> lookup i ts
    | Some t::ts -> if i < size t then lookupTree (i, t) else lookup (i - size t) ts

  let rec update: int -> 'a -> t<'a> -> t<'a> = fun i y -> function
    | []  -> failwith "subscript"
    | None::ts -> None :: update i y ts
    | Some t::ts ->
      if i < size t then let a = Some <| updateTree (i, y, t) in  a :: ts
      else (Some t) :: update (i - size t) y ts
