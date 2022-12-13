#r "nuget: FsUnit"
#load "Lib.fsx"
open FsUnit
open Lib

@"P.121, 6.1 Minimum and maximum"
module MinimumMaximum =
    @"P.121"
    let rec foldr1: ('a -> 'a -> 'a) -> list<'a> -> 'a = fun f -> function
        | [] -> failwith "error"
        | [x] -> x
        | x::xs -> f x (foldr1 f xs)
    let rec foldl1: ('a -> 'a -> 'a) -> list<'a> -> 'a = fun f -> function
        | [] -> failwith "error"
        | [x] -> x
        | x::xs -> List.fold f x xs

    @"P.121"
    let minimum xs = List.reduceBack min xs
    let maximum xs = List.reduceBack max xs
    minimum [1..10] |> should equal 1
    maximum [1..10] |> should equal 10

    @"P.122"
    module MinMax1=
        let minmax: list<'a> -> 'a * 'a = function
        | [] -> failwith "List cannot be Empty"
        | x::xs ->
            let op x (y,z) = (min x y, max x z)
            List.foldBack op xs (x,x)
        minmax [1..10] |> should equal (1,10)

    @"P.122"
    module MinMax2 =
        let minmax: list<'a> -> 'a * 'a = function
        | [] -> failwith "List cannot be Empty"
        | x::xs ->
            let op x (y,z) =
                if x < y then (x,z)
                elif z < x then (y,x)
                else (y,z)
            List.foldBack op xs (x,x)
        minmax [1..10] |> should equal (1,10)

    @"P.123, divide-and-conquer"
    module MinMax3 =
        @"P.097"
        let halve xs =
            let m = List.length xs / 2
            (List.take m xs, List.skip m xs)
        halve [1..10] |> should equal ([1..5], [6..10])
        halve [1..11] |> should equal ([1..5], [6..11])

        let rec minmax = function
        | [] -> failwith "List cannot be Empty"
        | [x] -> (x,x)
        | [x;y] -> if x <= y then (x,y) else (y,x)
        | xs ->
            let (ys,zs) = halve xs
            let (a1,b1) = minmax ys
            let (a2,b2) = minmax zs
            (min a1 a2, max b1 b2)
        minmax [1..10] |> should equal (1,10)

    @"P.123, bottom-up scheme"
    module MinMax4 =
        let rec pairWith f = function
        | [] -> []
        | [x] -> [x]
        | x::y::xs -> f x y :: pairWith f xs
        pairWith (fun x y -> x*y) [1..4]

        let rec mkPairs = function
        | [] -> []
        | [x] -> [(x,x)]
        | x::y::xs -> if x <= y then (x,y)::mkPairs xs else (y,x)::mkPairs xs

        let minmax xs =
            let op (a1,b1) (a2,b2) = (min a1 a2, max b1 b2)
            xs |> mkPairs |> Lib.until Lib.single (pairWith op) |> Lib.unwrap
        minmax [1..10] |> should equal (1,10)

@"P.124, 6.2 Selection from one set"
module SelectionFromOneSet =
    module P124_1 =
        let select: int -> list<'a> -> 'a = fun k xs ->
            List.sort xs |> List.item (k-1)
        let median xs =
            let k = (List.length xs + 1) / 2
            select k xs

        @"P.125"
        module Confirm =
            let item k xs ys =
                let n = List.length xs
                if k < n then List.item k xs else List.item (k-n) ys
            item 3 [0..4] [5..10] |> should equal 3
            item 6 [0..4] [5..10] |> should equal 6

        @"P.126"
        let rec group: int -> list<'a> -> list<list<'a>> = fun n -> function
            | [] -> []
            | xs ->
                let k = min n (List.length xs)
                let (ys, zs) = Lib.splitAt k xs
                ys :: group (min k (List.length zs)) zs
        group 5 [1..12] |> should equal [[1..5];[6..10];[11;12]]
        @"P.126"
        let medians xs =
            let middle xs = xs |> List.item ((List.length xs + 1) / 2 - 1)
            List.map (middle << List.sort) (group 5 xs)
        medians [1..12]  |> should equal [3;8;11]
        @"P.126"
        let pivot: list<'a> -> 'a = function
        | [] -> failwith "ERROR"
        | [x] -> x
        | xs ->
            let median xs = select ((List.length xs + 1) / 2) xs
            median (medians xs)

        @"P.125"
        let rec qsort = function
        | [] -> []
        | xs ->
            let (us, vs, ws) = Lib.partition3 (pivot xs) xs
            qsort us @ vs @ qsort ws
        qsort [10..-1..1] |> should equal [1..10]

        @"P.125"
        module P125 =
            let select: int -> list<'a> -> 'a = fun k xs ->
                let (us,vs,ws) = Lib.partition3 (pivot xs) xs
                let (m,n) = (List.length us, List.length vs)
                if k <= m then select k us
                elif k <= m+n then List.item (k-m-1) vs
                else select (k-m-n) ws

@"P.128, 6.3 Selection from two sets"
module SelectionFromTwoSets =
    let select: int -> list<'a> -> list<'a> -> 'a = fun k xs ys ->
        List.item k (Lib.merge xs ys)

    @"P.128"
    module P128 =
        let rec select k = fun As Bs ->
            match (As,Bs) with
            | ([],_) -> List.item k Bs
            | (_,[]) -> List.item k As
            | _ ->
                let p = (List.length As) / 2
                let q = (List.length Bs) / 2
                let (xs, a::ys) = Lib.splitAt p As
                let (us, b::vs) = Lib.splitAt q Bs
                if a <= b && k <= p+q then select k As us
                elif a <= b && k > p+q then select (k-p-1) ys Bs
                elif b <= a && k <= p+q then select k xs Bs
                else select (k-q-1) As vs

    @"P.129, binary search tree"
    module P129 =
        type Tree<'a> = | Null | Node of int * Tree<'a> * 'a * Tree<'a>
        let size = function
        | Null -> 0
        | Node(s,_,_,_) -> s
        let rec flatten = function
        | Null -> []
        | Node(_,l,x,r) -> flatten l @ [x] @ flatten r

        let select: int -> Tree<'a> -> Tree<'a> -> 'a = fun k t1 t2 ->
            Lib.merge (flatten t1) (flatten t2) |> List.item k

    module P130 =
        open BinarySearchTree
        let size = function
        | Null -> 0
        | Node(s,_,_,_) -> s
        module P129 =
            let select: int -> Tree<'a> -> Tree<'a> -> 'a = fun k t1 t2 ->
                Lib.merge (flatten t1) (flatten t2) |> List.item k

        @"P.130"
        let index t k = List.item k (flatten t)

        @"P.130"
        let rec select k t1 t2 =
            match (t1,t2) with
            | (_,Null) -> index t1 k
            | (Null,_) -> index t2 k
            | (Node(h1,l1,a,r1), Node(h2,l2,b,r2)) ->
                let (p,q) = (size l1, size l2)
                if a<=b && k<=p+q then select k (Node(h1,l1,a,r1)) l2
                elif a<=b && k>p+q then select (k-p-1) r1 (Node(h2,l2,b,r2))
                elif b<=a && k<=p+q then select k l1 (Node(h2,l2,b,r2))
                else select (k-q-1) (Node(h1,l1,a,r1)) r2

        module Index =
            let size = function
            | Null -> 0
            | Node(s,_,_,_) -> s

            let index t k =
                match t with
                | Null -> failwith "ERROR"
                | Node(_,l,x,r) ->
                    let p = size l
                    if k < p then index l k
                    elif k = p then x
                    else index r (k-p-1)

        let (<<=): list<'a> -> list<'a> -> bool = fun xs ys ->
            List.forall id [for x in xs do for y in ys do x <= y]
        [1..3] <<= [4..6] |> should equal true
        [1..3] <<= [2..4] |> should equal false

@"P.131, 6.4 Selection from the complement of a set"
module SelectionFromComplementOfSet =
    let sample = [08;23;09;00;12;11;01;10;13;07;41;04;14;21;05;17;03;19;02;06]

    // In the book, this function is defined by an operator `\\`
    let dbslash: list<'a> -> list<'a> -> list<'a> = fun xs ys ->
        List.filter (fun x -> not (List.contains x ys)) xs
    dbslash [1..3] [2..4] |> should equal [1]
    dbslash [1..3] [4..5] |> should equal [1..3]

    @"Find the smallest natural number not in this list."
    @"P.132"
    module P132_1 =
        let select: list<int> -> int = fun xs ->
            let m = List.max xs + 1
            List.head (dbslash [0..m] xs)
        select [1..5] |> should equal 0
        select [0..5] |> should equal 6

    module P132_2 =
        let select: list<int> -> int = fun xs ->
            let m = List.max xs + 1
            List.head (dbslash [0..m] (List.sort xs))
        select [1..5] |> should equal 0
        select [0..5] |> should equal 6

    module P133_1 =
        let rec selectFrom k = function
        | [] -> k
        | x::xs -> if k=x then selectFrom (k+1) xs else k
        let select xs = selectFrom 0 (List.sort xs)
        select [1..5] |> should equal 0
        select [0..5] |> should equal 6

    @"P.132: select by csort in Answer 5.17, using accumArray"

    @"P.135"
    module P135_1 =
        let rec selectFrom a (n,xs) =
            let b = a + 1 + (n / 2)
            let (ys,zs) = List.partition ((>) b) xs
            let l = List.length ys
            if n = 0 then a
            elif l = b-a then selectFrom b (n-l,zs)
            else selectFrom a (l,ys)
        let select xs = selectFrom 0 (List.length xs, xs)
        select [1..6] |> should equal 0
        select [0..6] |> should equal 7

@"P.135, Exercise 6.1;  P.137, Answer 6.1"
@"P.135, Exercise 6.2;  P.137, Answer 6.2"
module P135_2 =
    let pair: (('a -> 'b) * ('a -> 'c)) -> 'a -> 'b * 'c =
        fun (f,g) x -> (f x, g x)
    let cross: (('a -> 'c) * ('b -> 'd)) -> ('a * 'b) -> ('c * 'd) =
        fun (f,g) (x,y) -> (f x, g y)
    let chk f g x y z =
        let a = cross (pair (f,g) x) (y,z)
        let b = (f x y, g x z)
        a = b
@"P.135, Exercise 6.3;  P.137, Answer 6.3"
@"P.136, Exercise 6.4;  P.137, Answer 6.4"
@"P.136, Exercise 6.5;  P.137, Answer 6.5"
@"P.136, Exercise 6.6;  P.137, Answer 6.6"
@"P.136, Exercise 6.7;  P.137, Answer 6.7"
@"P.136, Exercise 6.8;  P.138, Answer 6.8"
@"P.136, Exercise 6.9;  P.138, Answer 6.9"
@"P.136, Exercise 6.10; P.138, Answer 6.10"
@"P.136, Exercise 6.11; P.139, Answer 6.11"
@"P.136, Exercise 6.12; P.139, Answer 6.12"
@"P.136, Exercise 6.13; P.140, Answer 6.13"
@"P.136, Exercise 6.14; P.140, Answer 6.14"
@"P.136, Exercise 6.15; P.140, Answer 6.15"
module P140_1 =
    let select: int -> array<'a> -> array<'a> -> 'a = fun k xa ya ->
        let rec search k (lx,rx) (ly,ry) =
            let p = (lx+rx) / 2
            let q = (ly+ry) / 2
            let a = xa.[p]
            let b = ya.[q]
            if lx = rx+1 then ya.[ly+k]
            elif ly = ry+1 then xa.[lx+k]
            elif a <= b && k+lx+ly <= p+q then search k (lx,rx) (ly,q-1)
            elif a <= b && k+lx+ly >  p+q then search (k+lx-p-1) (p+1,rx) (ly,ry)
            elif b <= a && k+lx+ly <= p+q then search k (lx,p-1) (ly,ry)
            else search (k+ly-q-1) (lx,rx) (q+1, ry)
        search k (0, Array.length xa - 1) (0, Array.length ya - 1)
    select 3 [|0..5|] [|0..2|] |> should equal 1
