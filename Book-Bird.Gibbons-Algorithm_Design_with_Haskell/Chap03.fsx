#r "nuget: FsUnit"
open FsUnit

module SymList =
    type SymList<'a> = list<'a> * list<'a>

    let fromSL: SymList<'a> -> list<'a> = fun (xs, ys) -> xs@(List.rev ys)
    fromSL ([1;2], [4;3]) |> should equal [1..4]

    @"IMPORTANT CONSTRAINT
    null xs ⇒ null ys ∨ single ys
    null ys ⇒ null xs ∨ single xs"
    @"DESIGN
    consSL, snocSL, headSL, lastSL, tailSL, initSL
    cons x·fromSL = fromSL·consSL x
    snoc x·fromSL = fromSL·snocSL x
    tail ·fromSL  = fromSL·tailSL
    init ·fromSL  = fromSL·initSL
    head ·fromSL  = headSL
    last ·fromSL  = lastSL"

    @"P.044
    REM: `snocSL`の`then`は上で書いた制約によって`List.rev`不要."
    let snocSL: 'a -> SymList<'a> -> SymList<'a> = fun x (xs, ys) ->
        if List.isEmpty xs then (ys, [x]) else (xs, x::ys)
    snocSL 6 ([1..3], [5;4]) |> should equal ([1; 2; 3], [6; 5; 4])
    snocSL 4 ([], [3]) |> should equal ([3], [4])

    let lastSL: SymList<'a> -> 'a = fun (xs, ys) ->
        if List.isEmpty ys then List.last xs else List.head ys
    lastSL ([1..3], []) |> should equal 3
    lastSL ([1..3], [6;5;4]) |> should equal 6

    @"P.45, complicated lastSL"
    module P045 =
        let lastSL (xs, ys) =
            if List.isEmpty ys then
                if List.isEmpty xs then failwith "lastSL of empty list"
                else List.last xs
            else List.head ys
        lastSL ([1..3], []) |> should equal 3
        lastSL ([1..3], [6;5;4]) |> should equal 6

    @"P.054, Exercise 3.2; P.056 Answer 3.2"
    let nilSL: SymList<'a> = ([], [])

    @"P.045"
    let tailSL: SymList<'a> -> SymList<'a> = fun (xs,ys) ->
        match xs with
        | [] -> if List.isEmpty ys then failwith "undefined" else nilSL
        | [x] ->
            let (us, vs) = List.splitAt (List.length ys / 2) ys
            (List.rev vs, us)
        | _ -> (List.tail xs, ys)
    tailSL ([], [1]) |> should equal (List.empty<int>, List.empty<int>)
    tailSL ([1..2], []) |> should equal ([2], List.empty<int>)
    tailSL ([1], [8;7;6;5;4]) |> should equal ([4;5;6], [8;7])

    @"P.054, Exercise 3.2; P.056 Answer 3.2
    Define the value nilSL that returns an empty symmetric list, and the
    two functions nullSL and singleSL for testing whether a symmetric list is empty or
    a singleton. Also, define lengthSL."
    let nullSL: SymList<'a> -> bool = fun (xs,ys) ->
        List.isEmpty xs && List.isEmpty ys
    nullSL nilSL |> should equal true
    nullSL ([1],[]) |> should equal false

    let singleSL: SymList<'a> -> bool = fun (xs,ys) ->
        // P.020 Answer 1.3
        let single = function
            | [x] -> true
            | _ -> false
        (List.isEmpty xs && single ys) || (List.isEmpty ys && single xs)
    singleSL ([1],[]) |> should equal true
    singleSL ([],[1]) |> should equal true
    singleSL ([1],[1]) |> should equal false

    let lengthSL: SymList<'a> -> int = fun (xs,ys) ->
        List.length xs + List.length ys
    lengthSL ([],[]) |> should equal 0
    lengthSL ([1],[]) |> should equal 1
    lengthSL ([],[1]) |> should equal 1
    lengthSL ([1],[1]) |> should equal 2

    @"P.054, Exercise 3.3; P.0 Answer 3.3
    Define the functions consSL and headSL.
    REM: `then`は上で書いた制約によって`List.rev`不要."
    let consSL: 'a -> SymList<'a> -> SymList<'a> = fun x (xs,ys) ->
        if List.isEmpty ys then ([x], xs) else (x::xs, ys)
    consSL 1 ([2..3], [4..5]) |> should equal ([1..3], [4..5])

    let headSL: SymList<'a> -> 'a = fun (xs,ys) ->
        if List.isEmpty xs then List.head ys else List.head xs
    headSL ([], [1]) |> should equal 1
    headSL ([1..3], [5;4]) |> should equal 1

    @"P.054, Exercise 3.4; P.0 Answer 3.4
    Define the function initSL."
    let initSL: SymList<'a> -> SymList<'a> = fun (xs,ys) ->
        match ys with
        | [] -> if List.isEmpty xs then failwith "undefined" else nilSL
        | [x] ->
            let (us, vs) = List.splitAt (List.length xs / 2) xs
            (us, List.rev vs)
        | _ -> (xs, List.tail ys)
    initSL ([1..2], [4;3]) |> fromSL |> should equal [1..3]

    @"P.054, Exercise 3.5; P.0 Answer 3.5
    Implement dropWhileSL so that
    dropWhile ・ fromSL = fromSL・ dropWhileSL"
    let rec dropWhileSL p xs =
        if nullSL xs then nilSL
        elif p (headSL xs) then dropWhileSL p (tailSL xs)
        else xs
    let isEven x = (x%2 = 0)
    dropWhileSL isEven ([],[]) |> should equal (List.empty<int>,List.empty<int>)
    dropWhileSL isEven ([1;2;2], [4;3;4]) |> should equal ([1;2;2], [4;3;4])
    dropWhileSL isEven ([2;3], [4;3;4]) |> should equal ([3], [4;3;4])
    dropWhileSL isEven ([2;2], [4;3;4]) |> should equal ([3], [4])

    @"P.054, Exercise 3.6; P.0 Answer 3.6
    Define initsSL with the type
    initsSL :: SymList a→SymList (SymList a)
    Write down the equation that expresses the relationship between fromSL, initsSL,
    and inits."
    let rec initsSL: SymList<'a> -> SymList<SymList<'a>> = fun xs ->
        if nullSL xs then snocSL xs nilSL
        else snocSL xs (initsSL (initSL xs))
    initsSL ([], [])

    module P054_1 =
        let inits xs =
            [ 0 .. (List.length xs) ]
            |> List.map (fun i -> List.take i xs)
        inits (fromSL ([1..3], [6;5;4])) |> should equal (List.map fromSL (fromSL (initsSL ([1..3], [6;5;4]))))

    @"P.046"
    let myabs x = if x >= 0 then x else -x
    myabs -1 |> should equal 1
    myabs 0 |> should equal 0
    myabs 1 |> should equal 1

    @"P.046"
    module P046_1 =
        let rec inits1: list<'a> -> list<list<'a>> = function
        | [] -> [[]]
        | x::xs -> [] :: List.map (fun ys -> x::ys) (inits1 xs)
        inits1 [1..3] |> should equal [[]; [1]; [1; 2]; [1; 2; 3]]

        let rec tails: list<'a> -> list<list<'a>> = function
        | [] -> [[]]
        | x::xs -> (x::xs)::(tails xs)
        tails [1;2;3;4] |> should equal [[1;2;3;4]; [2;3;4]; [3;4]; [4]; []]

        let inits2 xs = List.map List.rev (List.rev <| tails (List.rev xs))
        inits2 [1..3] |> should equal (inits1 [1..3])

        @"P.047"
        let flip f x y = f y x
        let init3 xs = List.map fromSL (List.scan (flip snocSL) nilSL xs)
        init3 [1..3] |> should equal (inits2 [1..3])

@"P.047, 3.2 Random-access lists"
module RAList =
    type nat = uint

    module TreeNoSize =
        type Tree<'a> = | Leaf of 'a | Node of Tree<'a> * Tree<'a>
        let rec size = function
        | Leaf(x) -> 1
        | Node(t1, t2) -> size t1 + size t2
        let t = Node(Leaf(1), Node(Leaf(2), Leaf(3)))
        size t |> should equal 3

    let rec fetch: uint -> list<'a> -> 'a = fun k xs ->
        if k = 0u then List.head xs else fetch (k-1u) (List.tail xs)
    fetch 0u [1..4] |> should equal 1

    type Tree<'a> =
        | Leaf of 'a
        | Node of uint * Tree<'a> * Tree<'a>

    let size: Tree<'a> -> uint = function
        | Leaf(x) -> 1u
        | Node(n, _, _) -> n
    let t = Node(3u, Leaf(1), Node(2u, Leaf(2), Leaf(3)))
    size t |> should equal 3

    @"P.048, smart constuctor"
    let node: Tree<'a> -> Tree<'a> -> Tree<'a> = fun t1 t2 ->
        Node(size t1 + size t2, t1, t2)
    node (Leaf 1) (Leaf 2) |> should equal (Node (2u, Leaf 1, Leaf 2))

    module P048 =
        node (node (Leaf 'a') (Leaf 'b')) (node (Leaf 'c') (Leaf 'd'))
        |> should equal (Node (4u, Node (2u, Leaf 'a', Leaf 'b'), Node (2u, Leaf 'c', Leaf 'd')))

    @"P.049"
    type Digit<'a> =
        | Zero
        | One of Tree<'a>
    type RAList<'a> = list<Digit<'a>>

    @"P.049"
    let rec fromT: Tree<'a> -> list<'a> = function
    | Leaf(x) -> [x]
    | Node(_, t1, t2) -> fromT t1 @ fromT t2
    fromT (Leaf 1) |> should equal [1]
    fromT (node (Leaf 1) (Leaf 2)) |> should equal [1..2]

    @"P.049"
    let from: Digit<'a> -> list<'a> = function
    | Zero -> []
    | One(t) -> fromT t
    let fromRA: RAList<'a> -> list<'a> = fun xs -> List.collect from xs
    fromRA [Zero; Zero; One (Leaf 1)] |> should equal [1]
    fromRA [Zero; Zero; One (node (Leaf 1) (Leaf 2))] |> should equal [1;2]

    @"P.049"
    let rec fetchT: uint -> Tree<'a> -> 'a = fun k t ->
        if k = 0u then
            match t with
            | Leaf(x) -> x
            | Node(_, t1, t2) -> fetchT 0u t1
        else
            match t with
            | Node(n, t1, t2) ->
                let m = n / 2u
                if k < m then fetchT k t1 else fetchT (k-m) t2
            | Leaf(x) -> x
    fetchT 0u (Node(3u, Leaf(1), Node(2u, Leaf(2), Leaf(3)))) |> should equal 1
    fetchT 1u (Node(3u, Leaf(1), Node(2u, Leaf(2), Leaf(3)))) |> should equal 2
    fetchT 2u (Node(3u, Leaf(1), Node(2u, Leaf(2), Leaf(3)))) |> should equal 3

    let rec fetchRA: uint -> RAList<'a> -> 'a = fun k -> function
        | [] -> failwith "index too large" // P.054 Exercise 3.9; P.057 Answer 3.9
        | Zero::xs -> fetchRA k xs
        | One(t)::xs -> if k < size t then fetchT k t else fetchRA (k - size t)xs
    fetchRA 0u [One(node (Leaf 1) (Leaf 2))] |> should equal 1
    fetchRA 1u [One(node (Leaf 1) (Leaf 2))] |> should equal 2

    module P049 =
        let chk k xs = ((fetch k) <| fromRA xs) = (fetchRA k xs)
        chk 0u [One(node (Leaf 1) (Leaf 2))]
        chk 1u [One(node (Leaf 1) (Leaf 2))]
        chk 3u [One(node (Leaf 1) (Leaf 2)); Zero; One(node (Leaf 3) (Leaf 4))]

    @"P.050"
    let nullRA: RAList<'a> -> bool = List.isEmpty
    let nilRA: RAList<'a> = List.empty

    @"P.050, consRA"
    let rec inc: list<int> -> list<int> = function
        | [] -> [1]
        | 0::bs -> 1::bs
        | 1::bs -> 0::inc bs

    let rec consT: Tree<'a> -> RAList<'a> -> RAList<'a> = fun t1 -> function
        | [] -> [One(t1)]
        | Zero::xs -> One(t1)::xs
        | One(t2)::xs -> Zero::consT (node t1 t2) xs
    consT (Leaf 1) [One(Leaf 0)] |> should equal [Zero; One (Node (2u, Leaf 1, Leaf 0))]

    let consRA: 'a -> RAList<'a> -> RAList<'a> = fun x xs -> consT (Leaf x) xs
    consRA 1 [] |> should equal  [One (Leaf 1)]
    consRA 2 (consRA 1 []) |> should equal [Zero; One (Node (2u, Leaf 2, Leaf 1))]

    @"P.050, unconsRA"
    let rec dec: list<int> -> list<int> = function
        | [1] -> []
        | 1::ds -> 0::ds
        | 0::ds -> 1::dec ds

    let rec unconsT: RAList<'a> -> Tree<'a> * RAList<'a> = function
        | One(t)::xs -> if List.isEmpty xs then (t, []) else (t, Zero::xs)
        | Zero::xs ->
            match (unconsT xs) with
            | (Leaf x, ys) -> (Leaf x, Zero::ys)
            | (Node(_, t1, t2), ys) -> (t1, One(t2)::ys)
    unconsT [Zero; One (Node (2u, Leaf 2, Leaf 1))] |> should equal (Leaf 2, [One (Leaf 1)])

    let unconsRA xs =
        let (Leaf x, ys) = unconsT xs
        (x, ys)

    module P050 =
        let t1 = Leaf 'a'
        let t2 = Leaf 'b'
        let t3 = node t1 t2
        let t4 = node (Leaf 'c') (Leaf 'd')
        let t = node t3 t4
        unconsT [Zero; Zero; One t] = (t1, [One t2; One t4]) |> should equal true
        unconsT [One t] = (t, []) |> should equal true

    @"P.50; P.055, Exercise 3.10; P.057, Answer 3.10"
    let toRA: list<'a> -> RAList<'a> = fun xs ->
        List.foldBack consRA xs nilRA
    toRA [1..3] |> should equal [One (Leaf 1); One (Node (2u, Leaf 2, Leaf 3))]

    @"P.50; P.055, Exercise 3.11; P.057, Answer 3.11"
    let rec updateT: uint -> 'a -> Tree<'a> -> Tree<'a> = fun k x t ->
        if k = 0u then
            match t with
            | Leaf(_) -> Leaf x
            | Node(_, t1, t2) -> node (updateT 0u x t1) t2
        else
            match t with
            | Node(n, t1, t2) ->
                let m = n / 2u
                if k < m then Node(n, updateT k x t1, t2)
                else Node(n, t1, updateT (k-m) x t2)
            | Leaf(_) -> failwith "index is too large"
    node (Leaf 1) (node (Leaf 2) (Leaf 3)) |> updateT 0u 0
    |> should equal (node (Leaf 0) (node (Leaf 2) (Leaf 3)) )

    let rec updateRA = fun k x -> function
        | Zero::xs -> Zero::updateRA k x xs
        | One t::xs ->
            if k < size t then One(updateT k x t) :: xs
            else One t::updateRA (k - size t) x xs
    toRA [1..3] |> updateRA 0u 0 |> should equal (toRA [0;2;3])

    @"P.50; P.055, Exercise 3.12; P.058, Answer 3.12
    The symbol in the book is `//`, and this cannot be used in F#."
    let flip f x y = f y x
    let uncurry f (a,b) = f a b
    let (!/): RAList<'a> -> list<uint * 'a> -> RAList<'a> = fun xs upds ->
        List.fold (flip (uncurry updateRA)) xs upds
    (!/) (toRA [0..3]) [(1u,7); (2u,3); (3u,4); (2u,8)]
    fromRA ((!/) (toRA [0..3]) [(1u,7); (2u,3); (3u,4); (2u,8)])
    |> should equal [0;7;8;4]
    @"P.50; P.055, Exercise 3.13; P.059, Answer 3.13"
    let headRA: RAList<'a> -> 'a = fun xs -> fst (unconsRA xs)
    let tailRA: RAList<'a> -> RAList<'a> = fun xs -> snd (unconsRA xs)

@"P.051, 3.3 Arrays"
@"Haskell array
array::Ix i => (i,i) -> [(i,e)] -> Array i e
listArray:: Ix i => (i,i) -> [e] -> Array i e
accumArray:: Ix i => (e -> v -> e) -> e -> (i,i) -> [(i,v)] -> Array i e"
let accumArray: ('e -> 'v -> 'e) -> 'e -> ('i * 'i) -> list<'i * 'v> -> array<'i*'e> = fun f e (l,r) ivs ->
    [for j in [l..r] do (j, List.fold f e [for (i,v) in ivs do if i=j then yield v])]
    |> Array.ofList
accumArray (+) 0 (1,3) [(1,20);(2,30);(1,40);(2,50)]
|> should equal [|(1, 60); (2, 80); (3, 0)|]

module P052_1 =
    let accumArray: ('e -> 'v -> 'e) -> 'e -> ('i * 'i) -> list<'i * 'v> -> array<'i*'e> =
        fun f e (l,r) ivs ->
        [|l..r|]
        |> Array.map (fun j -> (j, List.fold f e [for (i,v) in ivs do if i=j then yield v]))
    accumArray (+) 0 (1,3) [(1,20);(2,30);(1,40);(2,50)] |> should equal [|(1, 60); (2, 80); (3, 0)|]

module P052_2 =
    let filtermap j ivs = [for (i,v) in ivs do if i=j then yield v]
    let accumArray: ('e -> 'v -> 'e) -> 'e -> ('i * 'i) -> list<'i * 'v> -> array<'i*'e> =
        fun f e (l,r) ivs ->
        [|l..r|]
        |> Array.map (fun j -> (j, List.fold f e (filtermap j ivs)))
    accumArray (+) 0 (1,3) [(1,20);(2,30);(1,40);(2,50)] |> should equal [|(1, 60); (2, 80); (3, 0)|]

module P052_3 =
    let filtermap j ivs = List.choose (fun (i,v) -> if i = j then Some v else None) ivs
    let accumArray: ('e -> 'v -> 'e) -> 'e -> ('i * 'i) -> list<'i * 'v> -> array<'i*'e> =
        fun f e (l,r) ivs ->
        [|l..r|]
        |> Array.map (fun j -> (j, List.fold f e (filtermap j ivs)))
    accumArray (+) 0 (1,3) [(1,20);(2,30);(1,40);(2,50)] |> should equal [|(1, 60); (2, 80); (3, 0)|]

module P052_4 =
    let filtermap j ivs = List.choose (fun (i,v) -> if i = j then Some v else None) ivs
    let accumArray: ('e -> 'v -> 'e) -> 'e -> ('i * 'i) -> list<'i * 'v> -> array<'i*'e> =
        fun f e (l,r) ivs ->
        [|l..r|]
        |> Array.map (fun j -> (j, List.fold f e (filtermap j ivs)))
    let flip f x y = f y x
    let cons x y = x::y
    accumArray (flip cons) [] ('A', 'C') [('A', "Apple"); ('A', "Apricot")]
    |> should equal [|('A', ["Apricot"; "Apple"]); ('B', []); ('C', [])|]

module P052_5 =
    let filtermap j ivs = List.choose (fun (i,v) -> if i = j then Some v else None) ivs
    let accumArray: ('e -> 'v -> 'e) -> 'e -> ('i * 'i) -> list<'i * 'v> -> array<'i*'e> =
        fun f e (l,r) ivs ->
        [|l..r|]
        |> Array.map (fun j -> (j, List.fold f e (filtermap j ivs)))

    /// ソートした上で先頭のm個を取る
    let sort: int -> list<int> -> list<int> = fun m xs ->
        let copy (x,k) = List.replicate k x
        let assocs xs = xs |> Array.mapi (fun i x -> (i, snd x)) |> List.ofArray

        let rep = List.replicate (List.length xs) 1
        let a = accumArray (+) 0 (0, m) (List.zip xs rep)
        List.collect copy (assocs a)
    sort 5 [3;2;1] |> should equal [1;2;3]

@"P.53"
let assocs xs = xs |> Array.mapi (fun i x -> (i, x)) |> List.ofArray
let elems: array<'e> -> list<'e> = fun xs -> List.map snd (assocs xs)
elems [|2;3;1;4|]

@"P.054, Exercise 3.1; P.074, Answer 3.1"
module P054_1 =
    open SymList
    let flip f x y = f y x
    List.fold (flip snocSL) nilSL (Seq.toList "abcd") |> should equal (['a'], ['d';'c';'b'])
    List.foldBack consSL (Seq.toList "abcd") nilSL |> should equal (['a';'b';'c'], ['d'])
    consSL 'a' (snocSL 'd' (List.foldBack consSL (seq "bc" |> List.ofSeq) nilSL)) |> should equal (['a';'b'], ['d';'c'])
@"P.054, Exercise 3.7; P.075 Answer 3.7"
module P054_2 =
    let flip f x y = f y x
    let cons x ys = x::ys
    let inits xs = List.map List.rev (List.scan (flip cons) [] xs)
    inits [1;2;3] |> should equal [[]; [1]; [1; 2]; [1; 2; 3]]
@"P.054, Exercise 3.8, P.075 Answer 3.8"
module P054_3 =
    open RAList
    let rec fromT: Tree<'a> -> list<'a> = function
    | Leaf(x) -> [x]
    | Node(_, t1, t2) -> fromT t1 @ fromT t2

    module newFromT =
        let rec fromTs: list<Tree<'a>> -> list<'a> = function
        | [] -> []
        | Leaf(x)::ts -> x::(fromTs ts)
        | (Node(_,t1,t2))::ts -> fromTs (t1::t2::ts)
        let fromT t = fromTs [t]

@"P.055, Exercise 3.14"
let listArray = Array.ofList
5 |> fun n -> listArray (List.scan (*) 1 [1..n]) |> should equal [|1;1;2;6;24;120|]
List.scan (*) 1 [1..5]

@"P.055, Exercise 3.15
TODO
一般化された添え字を持てるHaskelと違ってF#の配列の添え字はただの整数なので実装が面倒。
書き直しは保留。"
let ivs = [(1,20);(2,30);(1,40);(2,50)]
let accum: ('e->'v->'e) -> array<'e> -> list<'i*'v> -> array<'e> = fun f a ivs ->
    let toJ j = [for (i,v) in ivs do if i=j then yield v]
    a |> Array.mapi (fun j x -> List.fold f (a.[j]) (toJ j))
accum (+) [|0..3|] ivs |> should equal [|0; 61; 82; 3|]
