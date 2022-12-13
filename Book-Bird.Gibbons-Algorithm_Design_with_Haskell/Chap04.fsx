#r "nuget: FsUnit"
open FsUnit

@"P.063"
type nat = uint
module P063_1 =
    @"linear search"
    let search: (int -> int) -> int -> list<int> = fun f t ->
        [for x in [0..t] do if t = f x then yield x]
    search (fun x -> x*x) 10 |> should equal List.empty<int>
    search id 10 |> should equal [10]

    module ByChoose =
        let search f t =
            [0..t] |> List.choose (fun x -> if t = f x then Some x else None)
        search (fun x -> x*x) 10 |> should equal List.empty<int>
        search id 10 |> should equal [10]

module P063_2 =
    let search f t =
        let seek (a,b) = List.choose (fun x -> if t = f x then Some x else None) [a..b]
        seek (0,t)
    search (fun x -> x*x) 10 |> should equal List.empty<int>
    search id 10 |> should equal [10]

module P064_1 =
    @"binary search"
    let search f t =
        let choose (a,b) = (a+b)/2
        let rec seek (a,b) =
            let m = choose (a, b)
            if a > b then []
            elif t < f m then seek (a, m-1)
            elif t = f m then [m]
            else seek(m+1, b)
        seek (0,t)
    search (fun x -> x*x) 10 |> should equal List.empty<int>
    search id 10 |> should equal [10]

@"P.065"
module P065_0 =
    let bound: (int -> int) -> int -> int * int = fun f t ->
        let doneFunc b = t < f b
        // https://hackage.haskell.org/package/base-4.16.0.0/docs/src/GHC.Base.html#until
        let until p f =
            let rec go x = if p x then x else go (f x)
            go
        let b = until doneFunc (fun x -> x * 2) 1
        if t <= f 0 then (-1, 0) else (b / 2, b)
    bound id 3 |> should equal (2,4)
    bound id 4 |> should equal (4,8)
    bound id 9 |> should equal (8,16)

module P065_1 =
    // The same as above
    let bound: (int -> int) -> int -> int * int = fun f t ->
        let doneFunc b = t < f b
        let until p f =
            let rec go x = if p x then x else go (f x)
            go
        let b = until doneFunc (fun x -> x * 2) 1
        if t <= f 0 then (-1, 0) else (b / 2, b)

    // Linear search
    let search f t =
        let smallest (a,b) =
            [a+1..b]
            |> List.choose (fun x -> if t <= f x then Some x else None)
            |> List.head
        let x = smallest (bound f t)
        if f x = t then [x] else []
    search (fun x -> x*x) 10 |> should equal List.empty<int>
    search id 10 |> should equal [10]

module P065_2 =
    // The same as above
    let bound: (int -> int) -> int -> int * int = fun f t ->
        let doneFunc b = t < f b
        let until p f =
            let rec go x = if p x then x else go (f x)
            go
        let b = until doneFunc (fun x -> x * 2) 1
        if t <= f 0 then (-1, 0) else (b / 2, b)

    // binary search
    let search: (int -> int) -> int -> list<int> = fun f t ->
        let rec smallest (a,b) f t =
            let m = (a+b) / 2
            if a + 1 = b then b
            elif t <= f m then smallest (a,m) f t
            else smallest (m,b) f t
        let x = smallest (bound f t) f t
        if f x = t then [x] else []
    search (fun x -> x*x) 10 |> should equal List.empty<int>
    search id 10 |> should equal [10]

@"P.067, 4.2 A two-dimensional search problem"
module P067_1 =
    // linear search
    let search f t = [for x in [0..t] do for y in [0..t] do if t = f (x,y) then yield (x,y)]
    search (fun (x,y) -> (pown x 2) + (pown 3 y)) 10 |> should equal [(1,2);(3,0)]

module P067_2 =
    // linear search
    let search f t =
        [for x in [0..t] do for y in [0..t] do (x,y)]
        |> List.choose (fun (x,y) -> if t = f(x,y) then Some (x,y) else None)
    search (fun (x,y) -> (pown x 2) + (pown 3 y)) 10 |> should equal [(1,2);(3,0)]

module P068_1 =
    // decrease a number of list
    let search f t = [for x in [0..t] do for y in [t..(-1)..0] do if t = f (x,y) then yield (x,y)]
    search (fun (x,y) -> (pown x 2) + (pown 3 y)) 10 |> should equal [(1,2);(3,0)]

module P068_2 =
    let searchIn (a,b) f t = [for x in [a..t] do for y in [b..(-1)..0] do if t = f (x,y) then yield (x,y)]
    let search f t = searchIn (0,t) f t
    search (fun (x,y) -> (pown x 2) + (pown 3 y)) 10 |> should equal [(1,2);(3,0)]

module P068_3 =
    // saddle back search
    let search f t =
        let rec searchIn (x,y) =
            let z = f(x,y)
            if t < x || y < 0 then []
            elif z < t then searchIn (x+1,y)
            elif z = t then (x,y) :: searchIn (x+1,y-1)
            else searchIn (x,y-1)
        searchIn (0,t)
    search (fun (x,y) -> (pown x 2) + (pown 3 (int y))) 10 |> should equal [(1,2);(3,0)]
    search (fun (x,y) -> (pown x 2) + y) 15 |> should equal [(0,15);(1,14);(2,11);(3,6)]

module P069_1 =
    let rec smallest (a,b) f t =
        let m = (a+b) / 2
        if a + 1 = b then b
        elif a = b then b
        elif t <= f m then smallest (a,m) f t
        else smallest (m,b) f t
    // TODO Write a saddle back search

module P072_1 =
    let rec smallest (a,b) f t =
        let m = (a+b) / 2
        if a + 1 = b then b
        elif t <= f m then smallest (a,m) f t
        else smallest (m,b) f t

    let search f t =
        let rec from (x1,y1) (x2,y2) =
            let c = (x1+x2) / 2
            let r = (y1+y2) / 2
            // TODO ここはバグ?
            // x2=-1のときsmallestが無限ループになってしまうため
            let x = if x1-1=x2 then x1 else smallest (x1-1,x2) (fun x -> f(x,r)) t
            let y = if y2-1=y1 then y2 else smallest (y2-1,y1) (fun y -> f(c,y)) t
            if x2 < x1 || y1 < y2 then []
            elif y1-y2 <= x2-x1 then row (x1,y1) (x2,y2) x
            else col (x1,y1) (x2,y2) y
        and row (x1,y1) (x2,y2) x =
            let r = (y1+y2) / 2
            let z = f(x,r)
            if z < t then from (x1,y1) (x2, r+1)
            elif z = t then (x,r)::(from (x1,y1) (x-1,r+1)) @ (from (x+1,r-1) (x2,y2))
            else from (x1,y1) (x-1,r+1) @ from (x,r-1) (x2,y2)
        and col (x1,y1) (x2,y2) y =
            let c = (x1+x2) / 2
            let z = f (c,y)
            if z < t then from (c+1,y1) (x2,y2)
            elif z = t then (c,y) :: from (x1,y1) (c-1,y+1) @ from (c+1,y-1) (x2,y2)
            else from (x1,y1) (c-1,y) @ from (c+1,y-1) (x2,y2)

        let p = smallest (-1,t) (fun y -> f(0,y)) t
        let q = smallest (-1,t) (fun x -> f(x,0)) t
        from (0,p) (q,0)

    search (fun (x,y) -> x + y) 2 |> should equal [(1, 1); (0, 2); (2, 0)]
    search (fun (x,y) -> (pown x 2) + (pown 3 (int y))) 10 |> should equal [(1,2);(3,0)]
    search (fun (x,y) -> (pown x 2) + y) 15 |> should equal [(2,11);(0,15);(1,14);(3,6)]

@"P.73 4.3 Binary search trees"
module BinarySearchTreePrototype =
    type Tree<'a> = | Null | Node of Tree<'a> * 'a * Tree<'a>

    @"P.076, テストしやすくするために先に定義"
    let partition p xs = (List.filter p xs, List.filter (fun x -> not <| p x) xs)
    let rec mktree: list<'a> -> Tree<'a> = function
    | [] -> Null
    | x::xs ->
        let (ys, zs) = partition (fun a -> a < x) xs
        Node (mktree ys, x, mktree zs)
    mktree [1..5] |> should equal (Node (Null, 1, Node (Null, 2, Node (Null, 3, Node (Null, 4, Node (Null, 5, Null))))))

    @"P.074"
    let rec size: Tree<'a> -> int = function
    | Null -> 0
    | Node (l,x,r) -> 1 + size l + size r
    mktree [1..3] |> size |> should equal 3

    @"P.074"
    let rec flatten: Tree<'a> -> list<'a> = function
    | Null -> []
    | Node (l,x,r) -> flatten l @ [x] @ flatten r
    mktree [1..3] |> flatten |> should equal [1..3]

    @"P.074"
    let rec search: ('a -> 'k) -> 'k -> Tree<'a> -> Option<'a> =
        fun key k -> function
        | Null -> None
        | Node (l,x,r) ->
            if key x < k then search key k r
            elif key x = k then Some x
            else search key k l
    mktree [1..3] |> search id 1 |> should equal (Some 1)
    mktree [1..3] |> search id 0 |> should equal None

    @"P.075"
    let rec height: Tree<'a> -> int = function
    | Null -> 0
    | Node (l,x,r) -> 1 + max (height l) (height r)
    mktree [1..3] |> height |> should equal 3

module BinarySearchTreeBaranced =
    type Tree<'a> = | Null | Node of int * Tree<'a> * 'a * Tree<'a>

    @"P.076"
    let height: Tree<'a> -> int = function
    | Null -> 0
    | Node (h,_,_,_) -> h

    @"P.076"
    let node: Tree<'a> -> 'a -> Tree<'a> -> Tree<'a> = fun l x r ->
        let h = 1 + max (height l) (height r)
        Node (h,l,x,r)

    @"P.077"
    let rotr = function
    | Node (_, (Node (_, ll, y, rl)), x, r) -> node ll y (node rl x r)
    @"P.078"
    let rotl = function
    | Node (_, ll, y, (Node (_, lrl, z, rrl))) -> node (node ll y lrl) z rrl

    @"P.078"
    let bias: Tree<'a> -> int = function
    | Null -> 0
    | Node (_,l,x,r) -> height l - height r
    @"P.079
    heightが3以上違う木を食わせるとエラーが起きる"
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

    @"P.076"
    let rec insert: 'a -> Tree<'a> -> Tree<'a> = fun x -> function
        | Null -> node Null x Null
        | Node (h,l,y,r) ->
            if x < y then balance (insert x l) y r
            elif x = y then Node (h,l,y,r)
            else balance l y (insert x r)
    let mktree: list<'a> -> Tree<'a> = fun xs ->
        List.foldBack insert xs Null
    mktree [1..3] |> should equal (Node (2, Node (1, Null, 1, Null), 2, Node (1, Null, 3, Null)))

    @"P.074"
    let rec flatten: Tree<'a> -> list<'a> = function
    | Null -> []
    | Node (_,l,x,r) -> flatten l @ [x] @ flatten r
    mktree [1..3] |> flatten |> should equal [1..3]

    @"P.080"
    let sort: list<'a> -> list<'a> = fun xs -> xs |> mktree |> flatten
    sort [4..-1..0] |> should equal [0..4]

    @"P.079
    本の定義のSetは4.4で`type Set<'a> = Tree<'a>`とする前提."
    let rec balanceR: Tree<'a> -> 'a -> Tree<'a> -> Tree<'a> = function
    | Node (_,l,y,r) -> fun x t2 ->
        if height r >= height t2 + 2 then balance l y (balanceR r x t2)
        else balance l y (node r x t2)
    @"P.087, Exercise 4.16; P.091 Answer 4.16"
    let rec balanceL: Tree<'a> -> 'a -> Tree<'a> -> Tree<'a> = fun t1 x -> function
    | Node (_,l,y,r) ->
        if height l >= height t1 + 2 then balance (balanceL t1 x l) y r
        else balance (node t1 x l) y r

    @"P.080"
    let gbalance: Tree<'a> -> 'a -> Tree<'a> -> Tree<'a> = fun t1 x t2 ->
        let h1 = height t1
        let h2 = height t2
        if abs (h1-h2) <= 2 then balance t1 x t2
        elif h2+2 < h1 then balanceR t1 x t2
        elif h1+2 < h2 then balanceL t1 x t2
        else failwith "Some error"

@"P.081, 4.4 Dynamic sets"
module DynamicSet =
    open BinarySearchTreeBaranced

    @"P.081"
    type Set<'a> = Tree<'a>

    @"P.081"
    let rec isMember: 'a -> Set<'a> -> bool = fun x -> function
        | Null -> false
        | Node (_,l,y,r) ->
            if x < y then isMember x l
            elif x = y then true
            else isMember x r

    @"P.082"
    let rec deleteMin: Set<'a> -> 'a * Set<'a> = function
    | Node(_,Null,x,r) -> (x,r)
    | Node(_,l,x,r) ->
        let (y,t) = deleteMin l
        (y, balance t x r)

    @"P.082"
    let combine: Set<'a> -> Set<'a> -> Set<'a> = fun l r ->
        match (l,r) with
        | (_, Null) -> l
        | (Null, _) -> r
        | _ ->
            let (x,t) = deleteMin r
            balance l x t

    @"P.082"
    type Piece<'a> =
    | LP of Set<'a> * 'a
    | RP of 'a * Set<'a>

    @"P.083"
    let pieces: 'a -> Set<'a> -> list<Piece<'a>> = fun x t ->
        let rec addPiece t ps =
            match t with
            | Null -> ps
            | Node(_,l,y,r) ->
                if x < y then addPiece l (RP(y, r)::ps)
                else addPiece r (LP(l, y)::ps)
        addPiece t []
    @"P.083"
    let sew: list<Piece<'a>> -> Set<'a> * Set<'a> = fun ps ->
        let step (t1,t2) = function
        | LP(t,x) -> (gbalance t x t1, t2)
        | RP(x,t) -> (t1, gbalance t2 x t)
        List.fold step (Null, Null) ps
    @"P.082"
    let split: 'a -> Set<'a> -> Set<'a> * Set<'a> = fun x t ->
        pieces x t |> sew

    @"P.081"
    let rec delete: 'a -> Set<'a> -> Set<'a> = fun x -> function
        | Null -> Null
        | Node (_,l,y,r) ->
            if x < y then balance (delete x l) y r
            elif x = y then combine l r
            else balance l y (delete x r)

    @"P.082, specialized combine"
    module Combine =
        let combine: Set<'a> -> Set<'a> -> Set<'a> = fun l r ->
            match (l,r) with
            | l,Null -> l
            | Null,r -> r
            | l,r ->
                let (x,t) = deleteMin r
                balance l x t

@"P.085, Exercise4.1;  P.087, Answer4.1"
@"P.085, Exercise4.2;  P.087, Answer4.2"
@"P.085, Exercise4.3;  P.087, Answer4.3"
@"P.085, Exercise4.4;  P.088, Answer4.4"
@"P.085, Exercise4.5;  P.088, Answer4.5"
@"P.085, Exercise4.6;  P.088, Answer4.6"
@"P.085, Exercise4.7;  P.089, Answer4.7"
module P088_1 =
    open BinarySearchTreeBaranced
    let rec flatcat: Tree<'a> -> list<'a> -> list<'a> = fun t xs ->
        match t with
        | Null -> xs
        | Node(_,l,x,r) -> flatcat l (x :: flatcat r xs)

@"P.086, Exercise4.8;  P.089, Answer4.8"
@"P.086, Exercise4.9;  P.089, Answer4.9"
module P089_01 =
    let partition p xs =
        let op x (ys,zs) = if p x then (x::ys,zs) else (ys,x::zs)
        List.foldBack op xs ([],[])

@"P.086, Exercise4.10; P.089, Answer4.10"
module P089_02 =
    let partition3: 'a -> list<'a> -> list<'a>*list<'a>*list<'a> = fun y xs ->
        let op x (us,vs,ws) =
            if x < y then (x::us,vs,ws)
            elif x = y then (us,x::vs,ws)
            else (us,vs,x::ws)
        List.foldBack op xs ([],[],[])

@"P.086, Exercise4.11; P.090, Answer4.11"
@"P.086, Exercise4.12; P.090, Answer4.12"
@"P.086, Exercise4.13; P.090, Answer4.13"
module P090_1 =
    let rec merge: list<'a> -> list<'a> -> list<'a> = fun xs ys ->
        match (xs,ys) with
        | ([],ys) -> ys
        | (xs,[]) -> xs
        | (z::zs,w::ws) ->
            if z < w then z :: merge zs ys
            elif z = w then z :: merge zs ws
            else w :: merge xs ws

@"P.086, Exercise4.14; P.090, Answer4.14"
module P090_2 =
    open BinarySearchTreeBaranced
    open DynamicSet
    open P090_1

    module Union1 =
        let union: Set<'a> -> Set<'a> -> Set<'a> = fun t1 t2 ->
            List.foldBack insert (flatten t2) t1

    let rec from (l,r) (xa: array<'a>) =
        let m = (l+r) / 2
        if l=r then Null else node (from (l,m) xa) (xa.[m]) (from (m+1,r) xa)
    let build xs =
        let n = List.length xs
        from (0,n) (List.toArray xs)
    let union t1 t2 = build (merge (flatten t1) (flatten t2))

@"P.087, Exercise4.15; P.091, Answer4.15"
@"P.087, Exercise4.16; P.091, Answer4.16"
module P091_1 =
    open BinarySearchTreeBaranced
    open DynamicSet
    let rec balanceL: Set<'a> -> 'a -> Set<'a> -> Set<'a> = fun t1 x -> function
        | Null -> Null
        | Node (_,l,y,r) ->
            if height l >= height t1 + 2 then balance (balanceL t1 x l) y r
            else balance (node t1 x l) y r

@"P.087, Exercise4.17; P.091, Answer4.17"
module P091_2 =
    open BinarySearchTreeBaranced
    open P089_01
    let pair f (x,y) = (f x, f y)
    let split x xs = flatten xs |> partition (fun a -> a <= x) |> pair mktree
