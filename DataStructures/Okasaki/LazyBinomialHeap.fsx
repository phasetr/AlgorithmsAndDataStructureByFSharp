#r "nuget: FsUnit"
open FsUnit

exception Empty
exception Subscript
exception NotFound

// http://lepensemoi.free.fr/index.php/2009/12/10/binomial-heap
// http://lepensemoi.free.fr/index.php/2009/12/31/lazy-binomial-heap
type BinomialTree<'a> = Node of (int * 'a * list<BinomialTree<'a>>)
type t<'a> = Lazy<list<BinomialTree<'a>>>

let empty() = lazy []

// let isEmpty (x: t<'a>) = x.Force() = []
let isEmpty: t<'a> -> bool = fun x -> x.Force() = []

let rank (Node(r, _, _)) = r

let root (Node(_, x, _)) = x

let link (Node(r, x1, xs1) as n1) (Node(_, x2, xs2) as n2) =
  if x1 <= x2 then Node(r+1, x1, n2 :: xs1)
  else Node(r+1, x2, n1 :: xs2)

let rec insertTree t = function
  | [] -> [t]
  | hd::tl as t' -> if rank t < rank hd then t::t' else insertTree (link t hd) tl

let singletonTree x = Node(0, x, [])

let singleton x = lazy [singletonTree x]

// let insert x t = lazy insertTree (singletonTree x) (Lazy.force t)
// let insert x (t: t<'a>) = lazy insertTree (singletonTree x) (t.Force())
let insert: 'a -> t<'a> -> t<'a> = fun x t -> lazy insertTree (singletonTree x) (t.Force())

let rec mrg h1 h2 =
  match h1, h2 with
  | [], x | x, [] -> x
  | hd1::tl1, hd2::tl2 ->
      if rank hd1 < rank hd2 then hd1 :: mrg tl1 h2
      elif rank hd1 > rank hd2 then hd2 :: mrg h1 tl2
      else insertTree (link hd1 hd2) (mrg tl1 tl2)

let merge (h1: t<'a>) (h2: t<'a>) = lazy mrg (h1.Force()) (h2.Force())

(*
let rec private removeMinTree = function
  | [] -> raise Empty
  | [t] -> t, []
  | hd::tl ->
    let hd', tl'= removeMinTree tl
    if root hd <= root hd' then hd, tl else hd', hd::tl'
*)

let rec removeMinTree = function
  | [] -> failwith "remove from an empty tree"
  | [t] -> t, []
  | hd::tl ->
    let hd', tl'= removeMinTree tl
    if root hd <= root hd' then hd, tl else hd', hd::tl'

let findMin h = let (t, _) = removeMinTree h in root t

// let removeMin h = let Node(_, x, xs1), xs2 = removeMinTree (Lazy.force h) in lazy mrg (List.rev xs1) xs2
// let removeMin (h: t<'a>) = let Node(_, x, xs1), xs2 = removeMinTree (h.Force()) in lazy mrg (List.rev xs1) xs2
let removeMin: t<'a> -> Lazy<BinomialTree<'a> list> when 'a: comparison = fun h ->
  let Node(_, x, xs1), xs2 = removeMinTree (h.Force()) in lazy mrg (List.rev xs1) xs2
