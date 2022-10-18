// http://lepensemoi.free.fr/index.php/2010/02/18/implicit-queue
module ImplicitQueue =
  type Digit<'a> = Zero | One of 'a | Two of 'a * 'a
  type t<'a> =
    | Shallow of Digit<'a>
    | Deep of Digit<'a> * Lazy<t<'a * 'a>> * Digit<'a>

  let empty: t<'a> = Shallow Zero
  let isEmpty: t<'a> -> bool = function Shallow Zero -> true | _ -> false

  type t<'a> with
    //polymorphic recursion cannot be achieved through let-bound functions
    //hence we use static member methods
    static member snoc: 'a -> t<'a> -> t<'a> = fun x -> function
      | Shallow Zero -> Shallow (One x)
      | Shallow (One y) -> Deep (Two (y, x), lazy empty, Zero)
      | Deep(f, m, Zero) -> Deep(f, m, One x)
      | Deep(f, m, One y) -> Deep(f, lazy t.snoc (y, x) (m.Force()), Zero)
      | _ -> failwith "should not get there"

    static member head: t<'a> -> 'a = function
      | Shallow Zero -> failwith "empty"
      | Shallow (One x) -> x
      | Deep(One x, m, r) -> x
      | Deep(Two(x, y), m, r) -> x
      | _ -> failwith "should not get there"

    static member tail: t<'a> -> t<'a> = function
      | Shallow Zero -> failwith "empty"
      | Shallow (One x) -> empty
      | Deep(Two(x, y), m, r) -> Deep(One y, m, r)
      | Deep(One x, q, r) ->
        let q' = q.Force()
        if isEmpty q' then Shallow r
        else let y, z = t.head q' in Deep(Two(y, z), lazy t.tail q', r)
      | _ -> failwith "should not get there"

  let snoc: 'a -> t<'a> -> t<'a> = fun x q -> t.snoc x q
  let head: t<'a> -> 'a = fun q -> t.head q
  let tail: t<'a> -> t<'a> = fun q -> t.tail q
