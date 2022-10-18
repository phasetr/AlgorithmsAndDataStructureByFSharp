// http://lepensemoi.free.fr/index.php/2010/02/18/bootstrapped-queue
module BootstrappedQueue =
  type nonemptyT<'a> = {
    FrontAndSuspensionsLength : int
    Front : list<'a>
    Suspensions : t<seq<'a>>
    RBackLength : int
    RBack : list<'a>
  } with
    static member create lenfm f m lenr r = {
      FrontAndSuspensionsLength = lenfm
      Front = f
      Suspensions = m
      RBackLength = lenr
      RBack = r
    }
  and t<'a> = E | Q of nonemptyT<'a>
  with
    //polymorphic recursion cannot be achieved through let-bound functions
    //hence we use static member methods
    static member checkQ: nonemptyT<'a> -> t<'a> = fun q ->
      if q.RBackLength <= q.FrontAndSuspensionsLength then t.checkF q
      else
        let susp = t.snoc (Seq.rev q.RBack) q.Suspensions
        nonemptyT<'a>.create (q.FrontAndSuspensionsLength + q.RBackLength) q.Front susp 0 []
        |> t.checkF

    static member checkF: nonemptyT<'a> -> t<'a> = fun q ->
      match q.Front, q.Suspensions with
      | [], E -> E
      | [], m ->
        let f = t.head m |> Seq.toList
        let susp = t.tail m
        Q <| nonemptyT<'a>.create q.FrontAndSuspensionsLength f susp q.RBackLength q.RBack
      | _ -> Q q

    static member snoc: 'a -> t<'a> -> t<'a> = fun x -> function
      | E -> Q <| nonemptyT<'a>.create 1 [x] E 0 []
      | Q q ->
        let lenr = q.RBackLength+1
        let r = x::q.RBack
        nonemptyT<'a>.create q.FrontAndSuspensionsLength q.Front q.Suspensions lenr r
        |> t<'a>.checkQ

    static member head: t<'a> -> 'a = function
      | E -> failwith "empty"
      | Q q -> List.head q.Front

    static member tail: t<'a> -> t<'a> = function
      | E -> failwith "empty"
      | Q q ->
        let lenfm = q.FrontAndSuspensionsLength - 1
        let f' = List.tail q.Front
        nonemptyT<'a>.create lenfm f' q.Suspensions q.RBackLength q.RBack
        |> t<'a>.checkQ

  let empty: t<'a> = E

  let isEmpty: t<'a> -> bool = function E -> true | _ -> false

  let head: t<'a> -> 'a = fun q -> t.head q

  let tail: t<'a> -> t<'a> = fun q -> t.tail q

  let snoc: 'a -> t<'a> -> t<'a> = fun x q -> t.snoc x q
