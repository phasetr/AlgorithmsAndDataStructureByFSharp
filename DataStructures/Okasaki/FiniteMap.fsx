// http://lepensemoi.free.fr/index.php/2009/12/03/finite-map
#load "BinarySearchTree.fsx"
open BinarySearchTree
module FiniteMap =
  type t<'a, 'b> = BinarySearchTree.t<'a * 'b>

  let empty: t<'a,'b> = BinarySearchTree.empty

  let isEmpty = BinarySearchTree.isEmpty

  let singleton: 'a -> 'b -> BinarySearchTree.t<'a*'b> = fun k v -> BinarySearchTree.singleton (k, v)

  let rec containsKey: 'a -> t<'a*'b> -> bool when 'a: comparison = fun key -> function
    | E -> false
    | T (a, (k, v), b) ->
      key = k || (key < k && containsKey key a) || (key > k && containsKey key b)

  let rec containsValue: 'b -> t<'a*'b> -> bool when 'b: comparison = fun x -> function
    | E -> false
    | T (a, (k, v), b) ->
      x = v || (x < v && containsValue x a) || (x > v && containsValue x b)

  let rec tryFind: 'a -> t<'a*'b> -> option<'b> when 'a: comparison = fun key -> function
    | E -> None
    | T (a, (k, v), b) ->
      if key = k then Some v
      elif key < k then tryFind key a
      else tryFind key b

  let rec find: 'a -> t<'a*'b> -> 'b when 'a: comparison = fun key -> function
    | E -> failwith "not found"
    | T (a, (k, v), b) ->
      if key = k then v
      elif key < k then find key a
      else find key b

  let rec insert: 'a -> 'b -> t<'a*'b> -> t<'a*'b> when 'a: comparison = fun k v -> function
    | E -> T(E, (k,v), E)
    | T(a, (k', v'), b) as t ->
      if k = k' then t
      elif k < k' then T(insert k v a, (k',v'), b)
      else T(a, (k',v'), insert k v b)

  let rec replace: 'a -> 'b -> t<'a * 'b> -> t<'a * 'b> when 'a: comparison = fun k v -> function
    | E -> T(E, (k,v), E)
    | T(a, (k', v'), b) as t ->
      if k = k' then T(a, (k,v), b)
      elif k < k' then T(insert k v a, (k',v'), b)
      else T(a, (k',v'), insert k v b)

  let rec remove: 'a -> t<'a*'b> -> t<'a*'b> = fun key -> function
    | E -> E
    | T(a, (k, v), b) as t ->
      if k = key then E
      elif key < k then T(remove key a, (k,v), b)
      else T(a, (k,v), remove key b)
