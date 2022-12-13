#r "nuget: FsUnit"
open FsUnit
#load "Chap04.fsx"

@"P.094
let sort = flatten << mktree"
module P094_1 =
    open Chap04.BinarySearchTreeBaranced
    let sort xs = xs |> mktree |> flatten
    sort [10..-1..1] |> should equal [1..10]

@"P.094 5.1 Quicksort"
module QuickSort =
    @"P.094"
    type Tree<'a> = | Null | Node of Tree<'a> * 'a * Tree<'a>

    @"P.095, List.partition"
    let partition: ('a -> bool) -> list<'a> -> list<'a> * list<'a> = fun p xs ->
        let op x (ys,zs) = if p x then (x::ys,zs) else (ys,x::zs)
        List.foldBack op xs ([],[])
    partition ((>) 2) [0..3] |> should equal ([0;1],[2;3])

    @"P.095"
    let rec flatten: Tree<'a> -> list<'a> = function
    | Null -> []
    | Node(l,x,r) -> flatten l @ [x] @ flatten r

    @"P.094"
    let rec mktree: list<'a> -> Tree<'a> = function
    | [] -> Null
    | x::xs ->
        let (ys, zs) = partition (fun a -> a < x) xs
        Node(mktree ys, x, mktree zs)
    mktree [0..10] |> flatten |> should equal [0..10]

    @"P.095"
    let qsort xs = mktree xs |> flatten

    @"P095"
    module QsortNoTree =
        let rec qsort: list<'a> -> list<'a> = function
        | [] -> []
        | x::xs ->
            let (ys,zs) = List.partition ((>) x) xs
            qsort ys @ [x] @ qsort zs
        qsort [10..-1..1] |> should equal [1..10]

@"P.096, 5.2 Mergesort"
module MergeSort =
    @"P.096"
    type Tree<'a> = | Null | Leaf of 'a | Node of Tree<'a> * Tree<'a>

    @"P.096"
    let rec merge: list<'a> -> list<'a> -> list<'a> = fun xs ys ->
        match (xs,ys) with
        | ([],_) -> ys
        | (_,[]) -> xs
        | (z::zs, w::ws) ->
          if z <= w then z :: merge zs ys
          else w :: merge xs ws
    merge [] [1..2] |> should equal [1..2]
    merge [1..2] [] |> should equal [1..2]
    merge [1..2] [3..4] |> should equal [1..4]

    @"P.096"
    let rec flatten: Tree<'a> -> list<'a> = function
    | Null -> []
    | Leaf(x) -> [x]
    | Node(t1,t2) -> merge (flatten t1) (flatten t2)

    @"P.097"
    let rec drop n xs =
        if n <= 0 || List.isEmpty xs then xs
        else drop (n-1) (List.tail xs)
    let halve xs =
        let m = List.length xs / 2
        (List.take m xs, drop m xs)
    halve [1..5] |> should equal ([1;2],[3..5])

    @"P.097"
    module HalveOtherSplitting =
        let op x (ys,zs) = (zs, x::ys)
        let halve xs = List.foldBack op xs ([],[])
        halve [1..9] |> should equal ([2;4;6;8],[1;3;5;7;9])

    @"P.096"
    module P096_Mktree =
        let rec mktree: list<'a> -> Tree<'a> = function
        | [] -> Null
        | [x] -> Leaf(x)
        | xs ->
            let (ys,zs) = halve xs
            Node(mktree ys, mktree zs)
        mktree [1..5] |> flatten |> should equal [1..5]

    @"P.097"
    module MSort1 =
        open P096_Mktree
        let msort xs = mktree xs |> flatten
        msort [10..-1..1] |> should equal [1..10]

    module MSort2 =
        open P096_Mktree
        let rec msort = function
        | [] -> []
        | [x] -> [x]
        | xs ->
            let (ys,zs) = halve xs
            merge (msort ys) (msort zs)
        msort [10..-1..1] |> should equal [1..10]

    @"P.097"
    module P097_Mktree =
        let rec mkpair n xs =
            if n = 0 then (Null,xs)
            elif n = 1 then (Leaf(List.head xs), List.tail xs)
            else
                let m = n/2
                let (t1,ys) = mkpair m xs
                let (t2,zs) = mkpair (n-m) ys
                (Node(t1,t2),zs)
        let mktree xs = fst (mkpair (List.length xs) xs)
        mktree [0..9] |> flatten |> should equal [0..9]

    @"P.098"
    module P098_Mktree =
        type Tree<'a> = | Null | Leaf of 'a | Node of Tree<'a> * Tree<'a>

        let rec pairWith f = function
        | [] -> []
        | [x] -> [x]
        | x::y::xs -> f x y :: pairWith f xs

        // From Chapter 1
        let wrap x = [x]
        let unwrap [x] = x
        let single: list<'a> -> bool = function
            | [x] -> true
            | _ -> false
        // From Reference.fsx
        let until p f x =
            let rec go x =
                if p x then x else go (f x)
            go x
        let mktree = function
        | [] -> Null
        | xs ->
            unwrap <| until single (pairWith (fun x y -> Node(x,y))) (List.map Leaf xs)

        module P098_MergeSort3 =
            let msort = function
            | [] -> []
            | xs -> unwrap (until single (pairWith merge) (List.map wrap xs))
            msort [10..-1..1] |> should equal [1..10]

        module P098_MergeSort4 =
            @"P.099"
            let runs: list<'a> -> list<list<'a>> = fun xs ->
                let op = fun x -> function
                | [] -> [[x]]
                | (y::xs)::xss ->
                    if x <= y then (x::y::xs) :: xss
                    else [x] :: (y::xs) :: xss
                List.foldBack op xs []
            @"P.098"
            let msort = function
            | [] -> []
            | xs -> unwrap (until single (pairWith merge) (runs xs))
            msort [10..-1..1] |> should equal [1..10]

        @"P.099"
        module P099_SmoothMergeSort =
            let rec runs = function
            | [x] -> [[x]]
            | x::y::xs ->
                if x <= y then upruns y (fun z -> x::z) xs
                else dnruns y [x] xs
            and upruns x f = function
            | [] -> [f [x]]
            | y::ys ->
                if x <= y then upruns y (fun z -> f (x::z)) ys
                else f [x] :: runs (y::ys)
            and dnruns x xs = function
            | [] -> [x::xs]
            | y::ys ->
                if x > y then dnruns y (x::xs) ys
                else (x::xs) :: runs (y::ys)

            let msort = function
            | [] -> []
            | xs -> unwrap (until single (pairWith merge) (runs xs))
            msort [10..-1..1] |> should equal [1..10]

        module P100_MergeSort =
            // 実際のHaskellのソートを解説
            // https://hackage.haskell.org/package/base-4.6.0.1/docs/Data-List.html
            // sortBy :: (a -> a -> Ordering) -> [a] -> [a]
            // sortOn :: Orb b => (a -> b) -> [a] -> [a]
            type Ordering = | LT | EQ | GT
            // compare :: Ord a => a -> a-> Ordering
            // sortBy compare [3,1,4] = [1,3,4]
            // sortBy (flip compare) [3,1,4] = [4,3,1]
            // cmp x y = compare (odd x, x) (odd y, y)
            // sortBy cmp [1..10] = [2,4,6,8,10,1,3,5,7,9]

@"P.101, 5.3 Heapsort"
module HeapSort =
    @"P.101"
    type Tree<'a> = | Null | Node of 'a * Tree<'a> * Tree<'a>

    @"P.096"
    let rec merge: list<'a> -> list<'a> -> list<'a> = fun xs ys ->
        match (xs,ys) with
        | ([],_) -> ys
        | (_,[]) -> xs
        | (z::zs, w::ws) ->
            if z <= w then z :: merge zs ys
            else w :: merge xs ws
    merge [] [1..2] |> should equal [1..2]
    merge [1..2] [] |> should equal [1..2]
    merge [1..2] [3..4] |> should equal [1..4]

    @"P.101"
    let rec flatten: Tree<'a> -> list<'a> = function
    | Null -> []
    | Node(x,u,v) -> x :: merge (flatten u) (flatten v)

    @"P.094"
    let partition p xs = (List.filter p xs, List.filter (fun x -> not <| p x) xs)
    let rec mktree: list<'a> -> Tree<'a> = function
    | [] -> Null
    | x::xs ->
        let (ys, zs) = partition (fun a -> a < x) xs
        Node(x, mktree ys, mktree zs)
    mktree [0..10] |> flatten |> should equal [0..10]

    @"P.101"
    let rec siftDown: 'a -> Tree<'a> -> Tree<'a> -> Tree<'a> = fun x t1 t2 ->
        match (t1,t2) with
        | (Null, Null) -> Node(x,Null,Null)
        | (Node(y,u,v), Null) ->
            if x <= y then Node(x, Node(y,u,v), Null) else Node(y, siftDown x u v, Null)
        | (Null, Node(y,u,v)) ->
            if x <= y then Node(x, Null, Node(y,u,v)) else Node(y, Null, siftDown x u v)
        | (Node(y, ul, ur), Node(z, vl, vr)) ->
            if x <= min y z then Node(x, Node(y, ul, ur), Node(z, vl, vr))
            elif y <= min x z then Node(y, (siftDown x ul ur), Node(z, vl, vr))
            else Node(z, Node(y, ul, ur), siftDown x vl vr) // z <= min x y
    @"P.101"
    let rec heapify: Tree<'a> -> Tree<'a> = function
    | Null -> Null
    | Node(x,u,v) -> siftDown x (heapify u) (heapify v)

    @"P.102"
    let hsort: list<'a> -> list<'a> = fun xs -> (flatten << heapify << mktree) xs
    hsort [4..-1..1] |> should equal [1..4]

@"P.102, 5.4 Bucketsort and Radixsort"
module BucketSortAndRadixSort =
    open MergeSort.MSort1
    type Word = list<char>
    let sortWords: list<Word> -> list<Word> = fun ws -> msort ws
    let ws1 = "bca" |> List.ofSeq
    let ws2 = "abc" |> List.ofSeq
    sortWords [ws1;ws2] |> should equal [ws2;ws1]
    @"P.103"
    let rec ordered: list<'a -> 'b> -> 'a -> 'a -> bool = fun zs x y ->
        match zs with
        | [] -> true
        | d::ds -> (d x < d y) || ((d x = d y) && ordered ds x y)
    // rose tree
    @"P.103"
    type Tree<'a> = | Leaf of 'a | Node of list<Tree<'a>>
    @"P.104, minBound, maxBoundはInt32で代替"
    let ptn: ('a -> 'b) -> list<'a> -> list<list<'a>> = fun d xs ->
        [System.Int32.MinValue..System.Int32.MaxValue] // [minBound..maxBound] in Haskell
        |> List.map (fun m -> List.filter (fun x -> d x = m) xs)
    @"P.104"
    let rec flatten: Tree<list<'a>> -> list<'a> = function
    | Leaf(xs) -> xs
    | Node(ts) -> List.collect flatten ts
    @"P.103"
    let rec mktree: list<'a -> 'b> -> list<'a> -> Tree<list<'a>> = fun zs xs ->
        match zs with
        | [] -> Leaf(xs)
        | d::ds -> Node(List.map (mktree ds) (ptn d xs))
    @"P.104"
    let bsort ds xs = flatten (mktree ds xs)
    @"P.105"
    let rec rsort: list<'a -> 'b> -> list<'a> -> list<'a> = fun zs xs ->
        match zs with
        | [] -> xs
        | d::ds -> List.concat (ptn d (rsort ds xs))
    @"P.105"
    module EfficientPtn =
        let accumArray: ('e -> 'v -> 'e) -> 'e -> ('i * 'i) -> list<'i * 'v> -> array<'i*'e> =
            fun f e (l,r) ivs ->
                [for j in [l..r] do (j, List.fold f e [for (i,v) in ivs do if i=j then yield v])]
                |> Array.ofList
        let snoc xs x = xs @ [x]
        let elems xa = Array.map (fun (_,x) -> x) xa |> List.ofArray
        @"P.105"
        let ptn: 'b * 'b -> ('a -> 'b) -> list<'a> -> list<list<'a>> = fun (l,u) d xs ->
            let xa = accumArray snoc [] (l,u) (List.zip (List.map d xs) xs)
            elems xa
        @"P.106"
        module Ptn2 =
            let ptn (l,u) d xs =
                let xa = accumArray (fun x y -> y::x) [] (l,u) (List.zip (List.map d xs) xs)
                elems xa |> List.map List.rev
        @"P.106"
        let rec rsort: 'b * 'b -> list<'a -> 'b> -> list<'a> -> list<'a> =
            fun bb fs xs ->
            match fs with
            | [] -> xs
            | d::ds -> List.concat (ptn bb d (rsort bb ds xs))
        @"P.106"
        // padding
        let pad k xs = List.replicate (k - List.length xs) '0' @ xs
        let discs: list<int> -> list<int -> char> = fun xs ->
            let k = List.max (List.map (Seq.length << string) xs)
            [0..k-1] |> List.map (fun i -> fun x -> List.item i (pad k (string x |> List.ofSeq)))
        @"本はHaskellの一般化された添え字を持つ配列前提のコードで,
        いまの自分の無理やりな直訳コードでは動かない.
        let irsort: list<'a> -> list<'a> = fun xs ->
            rsort ('0', '9') (discs xs) xs"

@"P.106, 5.5 Sorting sums"
module SortingSums =
    @"P.106"
    type A = bigint
    let sortsums: list<A> -> list<A> -> list<A> = fun xs ys ->
        List.map2 (fun x y -> x+y) xs ys |> List.sort

    @"P.108"
    module Negate =
        let negate x = - x
        let sortsubs xs ys = List.map2 (fun x y -> x-y) xs ys |> List.sort
        let sortsums xs ys = sortsubs xs (List.map negate ys)

    @"P.108"
    module SortSubs1 =
        type Label = int
        type Pair = Label*Label
        @"P.096"
        let rec merge: list<'a> -> list<'a> -> list<'a> = fun xs ys ->
            match (xs,ys) with
            | ([],_) -> ys
            | (_,[]) -> xs
            | (z::zs, w::ws) ->
                if z <= w then z :: merge zs ys
                else w :: merge xs ws

        @"P.108"
        let subs xis yis = [for (x,i) in xis do for (y,j) in yis do (x-y, (i,j))]
        // O(n^2 log n)
        module P108_1 =
            let sortsubs1 xis = List.sort (subs xis xis)

        (* TODO
        let a = [|[|1;2|];[|2;3|]|]
        a.[1].[1]
        @"P.108, P.109"
        let sortWith: list<A*Pair> -> list<A*Label> -> list<A*Label> -> list<A*Pair> =
            fun abs xis yis ->
                let labelPairs = List.map snd abs
                let a = List.zip labelPairs [0..(List.length labelPairs)] |> List.toArray
                // 本では抽象的な`compare`を使っている
                let cmp (_,(i,k)) (_,(j,l)) = a.[i].[j] <= a.[k].[l]
                List.sortBy cmp (subs xis yis)

        let rec sortsubs1: list<A*Label> -> list<A*Label> = fun xs ys ->
            let n = List.length xs
            let xis = List.zip xs [0..n-1]
            let yis = zip ys [n..]
            let abs = merge (sortsubs1 xis) (sortsubs1 yis)
        *)

@"P.111, Exercise5.3; P.114, Answer5.3"
module P111_1 =
    type Tree<'a> = | Null | Node of Tree<'a> * 'a * Tree<'a>
    let rec flatcat ys xs =
        match ys with
        | Null -> xs
        | Node(l,x,r) -> flatcat l (x::flatcat r xs)

    @"P.095, List.partition"
    let partition: ('a -> bool) -> list<'a> -> list<'a> * list<'a> = fun p xs ->
        let op x (ys,zs) = if p x then (x::ys,zs) else (ys,x::zs)
        List.foldBack op xs ([],[])

    //let qcat xs ys = flatcat (mktree xs) ys
    let rec qcat xs ys =
        match (xs,ys) with
        | ([],_) -> ys
        | (x::xs, _) ->
            let (us,vs) = partition ((>) x) xs
            qcat us (x :: qcat vs ys)

    let qsort xs = qcat xs []
    qsort [5..-1..1] |> should equal [1..5]

@"P.112, Exercise5.6; P.115, Answer5.6"
module P112_1 =
    let rec qsort = function
    | [] -> []
    | x::xs -> help x xs [] []
    and help x xs us vs =
        match xs with
        | [] -> qsort us @ [x] @ qsort vs
        | y::ys ->
            if x <= y then help x ys us (y::vs)
            else help x ys (y::us) vs
    qsort [5..-1..1] |> should equal [1..5]

@"P.112, Exercise 5.11; P.116, Answer5.11"
@"P.113, Exercise 5.13; P.116, Answer5.13"
module P113_1 =
    type Tree<'a> = | Null | Node of 'a * Tree<'a> * Tree<'a>

    let split: list<'a> -> 'a * list<'a> * list<'a> = function
    | [] -> failwith "error (in the book, undefined)"
    | x::xs ->
        let op x (y,ys,zs) = if x <= y then (x,y::zs,ys) else (y,x::zs,ys)
        List.foldBack op xs (x, [], [])
    let rec mkheap: list<'a> -> Tree<'a> = function
    | [] -> Null
    | xs ->
        let (y,ys,zs) = split xs
        Node(y, mkheap ys, mkheap zs)

@"P.113, Exercise 5.14; P.116, Answer 5.14"
module P113_2 =
    let split: list<'a> -> 'a * list<'a> * list<'a> = function
    | [] -> failwith "error (in the book, undefined)"
    | x::xs ->
        let op x (y,ys,zs) = if x <= y then (x,y::zs,ys) else (y,x::zs,ys)
        List.foldBack op xs (x, [], [])

    @"P.096"
    let rec merge: list<'a> -> list<'a> -> list<'a> = fun xs ys ->
        match (xs,ys) with
        | ([],_) -> ys
        | (_,[]) -> xs
        | (z::zs, w::ws) ->
            if z <= w then z :: merge zs ys
            else w :: merge xs ws

    let rec hsort = function
    | [] -> []
    | xs ->
        let (y,ys,zs) = split xs
        y :: merge (hsort ys) (hsort zs)
    hsort [5..-1..1] |> should equal [1..5]

@"P.113, Exercise 5.15; P.117, Answer 5.15"
module P113_3 =
    type Tree<'a> = | Null | Node of 'a * Tree<'a> * Tree<'a>
    (*
    let rec mktree = function
    | [] -> Null
    | x::xs ->
        let m = List.length xs / 2
        Node(x, mktree (List.take m xs), mktree (List.skip m xs))
    *)
    let rec mkpair n xs =
        if n = 0 then (Null, xs)
        else
            let m = (n-1) / 2
            let (l,ys) = mkpair m (List.tail xs)
            let (r,zs) = mkpair (n-1-m) ys
            (Node(List.head xs, l, r), zs)
    let mktree xs = mkpair (List.length xs) xs |> fst

@"P.114, Exercise 5.19; P.119, Answer 5.19"
module P114_1 =
    type Word = list<char>
    (*TODO
    let wsort: list<Word> -> list<Word> = function
    | [] -> []
    | xss ->
        let k = List.fold (fun acc xs -> max acc (List.length xs)) 0 xss
        let ds = [0..k-1] |> List.map (fun i -> (fun xs -> ))
    *)
