// P.020, Answer 1.3
module Lib =
    type nat = uint
    let length = List.length
    let map = List.length
    let filter = List.filter
    let foldr f e xs = List.foldBack f xs e
    let label = List.indexed
    let foldl f e xs = List.fold f e xs
    let flip f x y = f y x
    let odd x = x%2=1
    let even x = x%2=0
    let uncurry f (a,b) = f a b

    let perms xs =
        let rec inserts: 'a -> 'a list -> 'a list list = fun x -> function
            | [] -> [[x]]
            | y::ys -> (x::y::ys) :: List.map (fun z -> y::z) (inserts x ys)
        let step x xss = List.collect (inserts x) xss
        List.foldBack step xs [[]]
    perms [1..3]

    let wrap: 'a -> list<'a> = fun x -> [x]
    let unwrap: list<'a> -> 'a = fun x -> x.[0]
    let single: list<'a> -> bool = function
        | [x] -> true
        | _ -> false

    // Haskell Prelude
    let until p f x =
        let rec go x =
            if p x then x else go (f x)
        go x

    // P.033
    let rec inits: list<'a> -> list<list<'a>> = function
    | [] -> [[]]
    | x::xs -> [] :: List.map (fun z -> x::z) (inits xs)

    let rec tails: list<'a> -> list<list<'a>> = function
    | [] -> [[]]
    | x::xs -> (x::xs) :: tails xs

    // P.035
    let rec iterate f x = seq {
        yield x
        yield! iterate f (f x)
    }

    // P.086, Exercise4.10; P.089, Answer4.10
    let partition3: 'a -> list<'a> -> list<'a>*list<'a>*list<'a> = fun y xs ->
        let op x (us,vs,ws) =
            if x < y then (x::us,vs,ws)
            elif x = y then (us,x::vs,ws)
            else (us,vs,x::ws)
        List.foldBack op xs ([],[],[])

    // P.096
    let rec merge: list<'a> -> list<'a> -> list<'a> = fun xs ys ->
        match (xs,ys) with
        | ([],_) -> ys
        | (_,[]) -> xs
        | (z::zs, w::ws) ->
          if z <= w then z :: merge zs ys
          else w :: merge xs ws

    // P.123
    let rec pairWith f = function
    | [] -> []
    | [x] -> [x]
    | x::y::xs -> f x y :: pairWith f xs

    // P.126 エラー回避のために別途定義
    let splitAt n xs =
        let k = min n (List.length xs)
        (List.take k xs, List.skip k xs)

    // P.145
    let minWith: ('a -> 'b) -> list<'a> -> 'a = fun f xs ->
        let smaller f x y = if f x <= f y then x else y
        List.reduceBack (smaller f) xs

    // P.153
    let maxWith: ('a -> 'b) -> list<'a> -> 'a = fun f xs ->
        let larger f x y = if f x <= f y then y else x
        List.reduceBack (larger f) xs

module SymList =
    type SymList<'a> = list<'a> * list<'a>

    let fromSL: SymList<'a> -> list<'a> = fun (xs, ys) -> xs@(List.rev ys)

    let snocSL: 'a -> SymList<'a> -> SymList<'a> = fun x (xs, ys) ->
        if List.isEmpty xs then (ys, [x]) else (xs, x::ys)

    let lastSL: SymList<'a> -> 'a = fun (xs, ys) ->
        if List.isEmpty ys then List.last xs else List.head ys

    let nilSL: SymList<'a> = ([], [])

    let tailSL: SymList<'a> -> SymList<'a> = fun (xs,ys) ->
        match xs with
        | [] -> if List.isEmpty ys then failwith "undefined" else nilSL
        | [x] ->
            let (us, vs) = List.splitAt (List.length ys / 2) ys
            (List.rev vs, us)
        | _ -> (List.tail xs, ys)

    let nullSL: SymList<'a> -> bool = fun (xs,ys) ->
        List.isEmpty xs && List.isEmpty ys

    let singleSL: SymList<'a> -> bool = fun (xs,ys) ->
        let single = function
            | [x] -> true
            | _ -> false
        (List.isEmpty xs && single ys) || (List.isEmpty ys && single xs)

    let lengthSL: SymList<'a> -> int = fun (xs,ys) ->
        List.length xs + List.length ys

    let consSL: 'a -> SymList<'a> -> SymList<'a> = fun x (xs,ys) ->
        if List.isEmpty ys then ([x], xs) else (x::xs, ys)

    let headSL: SymList<'a> -> 'a = fun (xs,ys) ->
        if List.isEmpty xs then List.head ys else List.head xs

    let initSL: SymList<'a> -> SymList<'a> = fun (xs,ys) ->
        match ys with
        | [] -> if List.isEmpty xs then failwith "undefined" else nilSL
        | [x] ->
            let (us, vs) = List.splitAt (List.length xs / 2) xs
            (us, List.rev vs)
        | _ -> (xs, List.tail ys)

    let rec dropWhileSL p xs =
        if nullSL xs then nilSL
        elif p (headSL xs) then dropWhileSL p (tailSL xs)
        else xs

    let rec initsSL: SymList<'a> -> SymList<SymList<'a>> = fun xs ->
        if nullSL xs then snocSL xs nilSL
        else snocSL xs (initsSL (initSL xs))

module RAList =
    module Tree =
        type Tree<'a> =
            | Leaf of 'a
            | Node of uint * Tree<'a> * Tree<'a>

        let size: Tree<'a> -> Lib.nat = function
            | Leaf(x) -> 1u
            | Node(n, _, _) -> n

        let node: Tree<'a> -> Tree<'a> -> Tree<'a> = fun t1 t2 ->
            Node(size t1 + size t2, t1, t2)

        let rec fromT: Tree<'a> -> list<'a> = function
        | Leaf(x) -> [x]
        | Node(_, t1, t2) -> fromT t1 @ fromT t2

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

    type Digit<'a> =
        | Zero
        | One of Tree.Tree<'a>
    type RAList<'a> = list<Digit<'a>>

    let from: Digit<'a> -> list<'a> = function
    | Zero -> []
    | One(t) -> Tree.fromT t

    let fromRA: RAList<'a> -> list<'a> = fun xs ->
        List.collect from xs

    let rec fetchRA: uint -> RAList<'a> -> 'a = fun k -> function
        | [] -> failwith "index too large" // P.054 Exercise 3.9; P.057 Answer 3.9
        | Zero::xs -> fetchRA k xs
        | One(t)::xs -> if k < Tree.size t then Tree.fetchT k t else fetchRA (k - Tree.size t)xs

    let nullRA: RAList<'a> -> bool = List.isEmpty
    let nilRA: RAList<'a> = List.empty

    let rec consT: Tree.Tree<'a> -> RAList<'a> -> RAList<'a> = fun t1 -> function
        | [] -> [One(t1)]
        | Zero::xs -> One(t1)::xs
        | One(t2)::xs -> Zero::consT (Tree.node t1 t2) xs

    let rec unconsT: RAList<'a> -> Tree.Tree<'a> * RAList<'a> = function
        | One(t)::xs -> if List.isEmpty xs then (t, []) else (t, Zero::xs)
        | Zero::xs ->
            match (unconsT xs) with
            | (Tree.Leaf x, ys) -> (Tree.Leaf x, Zero::ys)
            | (Tree.Node(_, t1, t2), ys) -> (t1, One(t2)::ys)

    let consRA: 'a -> RAList<'a> -> RAList<'a> = fun x xs ->
        consT (Tree.Leaf x) xs

    let unconsRA xs =
        let (Tree.Leaf x, ys) = unconsT xs
        (x, ys)

    let toRA: list<'a> -> RAList<'a> = fun xs ->
        List.foldBack consRA xs nilRA

    let rec updateRA = fun k x -> function
        | Zero::xs -> Zero::updateRA k x xs
        | One t::xs ->
            if k < Tree.size t then One(Tree.updateT k x t) :: xs
            else One t::updateRA (k - Tree.size t) x xs

    let (!/): RAList<'a> -> list<uint * 'a> -> RAList<'a> = fun xs upds ->
        List.fold (Lib.flip (Lib.uncurry updateRA)) xs upds

    let headRA: RAList<'a> -> 'a = fun xs -> fst (unconsRA xs)
    let tailRA: RAList<'a> -> RAList<'a> = fun xs -> snd (unconsRA xs)

module BinarySearchTree =
    type Tree<'a> = | Null | Node of int * Tree<'a> * 'a * Tree<'a>

    // P.074
    let rec flatten: Tree<'a> -> list<'a> = function
    | Null -> []
    | Node (_,l,x,r) -> flatten l @ [x] @ flatten r

    // P.076
    let height: Tree<'a> -> int = function
    | Null -> 0
    | Node (h,_,_,_) -> h

    // P.076
    let node: Tree<'a> -> 'a -> Tree<'a> -> Tree<'a> = fun l x r ->
        let h = 1 + max (height l) (height r)
        Node (h,l,x,r)

    // P.077
    let rotr = function
    | Null -> Null
    | Node (_, (Node (_, ll, y, rl)), x, r) -> node ll y (node rl x r)
    // P.078
    let rotl = function
    | Null -> Null
    | Node (_, ll, y, (Node (_, lrl, z, rrl))) -> node (node ll y lrl) z rrl

    // P.078
    let bias: Tree<'a> -> int = function
    | Null -> 0
    | Node (_,l,x,r) -> height l - height r

    // P.079
    let balance: Tree<'a> -> 'a -> Tree<'a> -> Tree<'a> = fun t1 x t2 ->
        let h1 = height t1
        let h2 = height t2
        let rotateR t1 x t2 =
            if 0 <= bias t1 then rotr (node t1 x t2)
            else rotr (node (rotl t1) x t2)
        let rotateL t1 x t2 =
            if bias t2 < 0 then rotl (node t1 x t2)
            else rotl (node t1 x (rotr t2))
        if abs (h1-h2) <= 1 then node t1 x t2
        elif h1 = h2+2 then rotateR t1 x t2
        elif h2 = h1+2 then rotateL t1 x t2
        else failwith "The difference of heights of t1 and t2 are bigger than 2"

    // P.076
    let rec insert: 'a -> Tree<'a> -> Tree<'a> = fun x -> function
        | Null -> node Null x Null
        | Node (h,l,y,r) ->
            if x < y then balance (insert x l) y r
            elif x = y then Node (h,l,y,r)
            else balance l y (insert x r)
    let mktree: list<'a> -> Tree<'a> = fun xs ->
        List.foldBack insert xs Null

// P.111, Exercise 5.1, Pl14, Answer 5.1
module MergeSortTree =
    type Tree<'a> = | Null | Leaf of 'a | Node of Tree<'a> * Tree<'a>
    // P.096
    let rec flatten: Tree<'a> -> list<'a> = function
    | Null -> []
    | Leaf(x) -> [x]
    | Node(t1,t2) -> Lib.merge (flatten t1) (flatten t2)

    let halve xs =
        let m = List.length xs / 2
        (List.take m xs, List.skip m xs)

    let rec mktree: list<'a> -> Tree<'a> = function
    | [] -> Null
    | [x] -> Leaf(x)
    | xs ->
        let (ys,zs) = halve xs
        Node(mktree ys, mktree zs)

module HeapSortTree =
    type Tree<'a> = | Null | Node of 'a * Tree<'a> * Tree<'a>
    // P.094
    let rec mktree: list<'a> -> Tree<'a> = function
    | [] -> Null
    | x::xs ->
        let (ys, zs) = List.partition (fun a -> a < x) xs
        Node(x, mktree ys, mktree zs)
    // P.101
    let rec flatten: Tree<'a> -> list<'a> = function
    | Null -> []
    | Node(x,u,v) -> x :: Lib.merge (flatten u) (flatten v)

module OddOneOutTree =
    type Tree<'a>= | Null | Node of 'a * list<Tree<'a>>

module QuickSortTree =
    type Tree<'a> = | Null | Node of Tree<'a> * 'a * Tree<'a>
    // P.095
    let rec flatten: Tree<'a> -> list<'a> = function
    | Null -> []
    | Node(l,x,r) -> flatten l @ [x] @ flatten r

    // P.094
    let rec mktree: list<'a> -> Tree<'a> = function
    | [] -> Null
    | x::xs ->
        let (ys, zs) = List.partition (fun a -> a < x) xs
        Node(mktree ys, x, mktree zs)

module BucketSortTree =
    type Tree<'a> = | Leaf of 'a | Node of list<Tree<'a>>
    // P.104
    let rec flatten: Tree<list<'a>> -> list<'a> = function
    | Leaf(xs) -> xs
    | Node(ts) -> List.collect flatten ts

    // P.104, minBound, maxBoundはInt32で代替
    let ptn: ('a -> 'b) -> list<'a> -> list<list<'a>> = fun d xs ->
        [System.Int32.MinValue..System.Int32.MaxValue] // [minBound..maxBound] in Haskell
        |> List.map (fun m -> List.filter (fun x -> d x = m) xs)
    // P.103
    let rec mktree: list<'a -> 'b> -> list<'a> -> Tree<list<'a>> = fun zs xs ->
        match zs with
        | [] -> Leaf(xs)
        | d::ds -> Node(List.map (mktree ds) (ptn d xs))
