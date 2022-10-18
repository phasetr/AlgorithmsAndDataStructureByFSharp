// http://lepensemoi.free.fr/index.php/2010/02/11/alternative-binary-random-access-list
module AlternativeBinaryRandomAccessList =
  type t<'a> =
    | Nil
    | Zero of t<'a * 'a>
    | One of 'a * t<'a * 'a>

    // polymorphic recursion cannot be achieved through let-bound functions
    // hence we use static member methods
    static member cons: 'a -> t<'a> -> t<'a> = fun x -> function
      | Nil -> One (x, Nil)
      | Zero ps -> One (x, ps)
      | One(y, ps) ->  Zero(t.cons (x,y) ps)

    static member uncons: t<'a> -> 'a * t<'a> = function
      | Nil -> failwith "empty"
      | One(x, Nil) -> (x, Nil)
      | One(x, ps) -> (x, Zero ps)
      | Zero ps -> let (x,y), ps' = t.uncons ps in (x, (One (y, ps')))

    static member lookup: int -> t<'a> -> 'a = fun i -> function
      | Nil -> failwith "subscript"
      | One(x, ps) -> if i = 0 then x else t.lookup (i-1) (Zero ps)
      | Zero ps -> let (x, y) = t.lookup (i/2) ps in if i%2=0 then x else y

    static member fupdate: ('a -> 'a) * int * t<'a> -> t<'a> = function
      | f, i, Nil -> failwith "subscript"
      | f, 0, One(x, ps) -> One(f x, ps)
      | f, i, One (x, ps) -> t.cons x (t.fupdate (f, i-1, Zero ps))
      | f, i, Zero ps ->
        let f' (x, y) = if i%2= 0 then f x, y else x, f y
        Zero(t.fupdate(f', i/2, ps))

  let empty: t<'a> = Nil

  let isEmpty: t<'a> -> bool = function Nil -> true | _ -> false

  let cons: 'a -> t<'a> -> t<'a> = fun x xs -> t.cons x xs

  let uncons: t<'a> -> 'a * t<'a> = fun x -> t.uncons x

  let head: t<'a> -> 'a = fun xs -> let x, _ = uncons xs in x

  let tail: t<'a> -> t<'a> = fun xs -> let _, xs'  =uncons xs in xs'

  let rec lookup: 'a -> (int -> t<'b> -> 'b) = fun i -> t.lookup

  let update: int -> 'a -> t<'a> -> t<'a> = fun i y xs -> t.fupdate ((fun x -> y), i, xs)
