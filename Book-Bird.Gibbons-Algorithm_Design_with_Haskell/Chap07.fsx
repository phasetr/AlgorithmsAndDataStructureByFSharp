#r "nuget: FsUnit"
#load "Lib.fsx"
open FsUnit
open Lib

@"P.141, PART THREE, GREEDY ALGORITHMS"
@"Chapter 7, Greedy algorithms on lists"
@"P.145, 7.1 A generic greedy algorithm"
(*
module GenericGreedyAlgorithm =
    type Component = Component
    type Candidate = Candidate

    @"P.145"
    let minWith: ('a -> 'b) -> list<'a> -> 'a = fun f xs ->
        let smaller f x y = if f x <= f y then x else y
        List.reduceBack (smaller f) xs
    @"P.146"
    //extend::Component -> Candidate -> [Candidate]
    @"P.146
    c0: some default partial candidate for an empty list of candidates
    extend: some function"
    @"candidates::Component -> Candidate -> [Candidate]"
    let candidates: list<Component> -> list<Candidate> = fun xs ->
        let step x cs = List.collect (extend x) cs
        List.foldBack step xs [c0]

    @"P.145"
    let mcc: list<Component> -> Candidate = minWith (cost << candidates)
*)

@"P.145"
let minWith: ('a -> 'b) -> list<'a> -> 'a = fun f xs ->
    let smaller f x y = if f x <= f y then x else y
    List.reduceBack (smaller f) xs

@"P.153"
let maxWith: ('a -> 'b) -> list<'a> -> 'a = fun f xs ->
    let larger f x y = if f x <= f y then y else x
    List.reduceBack (larger f) xs

@"P.147, 7.2 Greedy sorting algorithms"
module GreedySortingAlgorithms =
    @"P.147"
    let pairs xs =
        let rec f xs =
            match xs with
            | [] -> []
            | y::ys -> (y,ys) :: f ys
        f xs |> List.choose (fun (y,ys) ->
            if List.isEmpty ys then None
            else Some (ys |> List.map (fun z -> (y,z))))
        |> List.concat
    pairs [1..3] |> should equal [(1,2);(1,3);(2,3)]
    pairs [1..4] |> should equal [(1,2);(1,3);(1,4);(2,3);(2,4);(3,4)]

    @"P.147, inversion count"
    let ic: list<'a> -> int = fun xs ->
        pairs xs |> List.filter (fun (x,y) -> x > y) |> List.length
    ic [7;1;2;3] |> should equal 3
    ic [3;2;1;7] |> should equal 3

    @"P.148"
    let rec extend: 'a -> list<'a> -> list<list<'a>> = fun x -> function
        | [] -> [[x]]
        | y::xs -> (x::y::xs) :: List.map (fun z -> y::z) (extend x xs)
    let perms: list<'a> -> list<list<'a>> = fun xs ->
        List.foldBack (List.collect << extend) xs [[]]
    perms [1..3] |> should equal [[1;2;3];[2;1;3];[2;3;1];[1;3;2];[3;1;2];[3;2;1]]

    @"P.147"
    let sort: list<'a> -> list<'a> = fun xs -> minWith ic (perms xs)
    sort [4..-1..1] |> should equal [1..4]

    @"P.148, TODO"
    let gstep x xs = minWith ic (extend x xs)
    gstep 6 [7;1;2;3] |> should equal [7;1;2;3;6]
    gstep 6 [3;2;1;7] |> should equal [3;2;1;6;7]

    module P148 =
        @"P.148
        minWith ic (map (gstep x) xss) = gstep x (minWith ic xss)"
        let xss = [[7;1;2;3];[3;2;1;7]]
        minWith ic xss |> should equal [7;1;2;3]
        gstep 6 (minWith ic xss) |> should equal [7;1;2;3;6]
        minWith ic (List.map (gstep 6) xss) |> should equal [3;2;1;6;7]

    module P149_1 =
        let f x xs = minWith ic (List.map (gstep x) (perms xs))
        let g x xs = gstep x (minWith ic (perms xs))
        let h x xs = f x xs = g x xs
        h 1 [1..3] |> should equal true

    module P1492_2 =
        let f xs = minWith id xs
        f [1..4] |> should equal 1
        f [4..-1..1] |> should equal 1

    @"P.150"
    module P150_1 =
        let rec gstep x = function
        | [] -> [x]
        | y::xs -> if x <= y then x::y::xs else y::gstep x xs
        let sort xs = List.foldBack gstep xs []
        sort [4..-1..1] |> should equal [1..4]

    @"P.150"
    module P150_2 =
        let rec picks = function
        | [] -> []
        | x::xs -> (x,xs) :: [for (y,ys) in picks xs do (y, x::ys)]

        let rec perms = function
        | []-> [[]]
        | x::xs -> List.collect subperms (picks xs)
        and subperms (x,ys) = List.map (fun z -> x::z) (perms ys)

        let pick xs = List.min (picks xs)
        let rec sort = function
        | [] -> []
        | xs ->
            let (x,ys) = pick xs
            x :: sort ys
        sort [4..-1..1] |> should equal [1..4]

@"P.151, 7.3 Coin-changing"
module CoinChanging =
    @"P.152"
    type Denom = int
    type Tuple = list<int>
    let usds: list<Denom> = [100;50;25;10;5;1]
    let ukds: list<Denom> = [200;100;50;20;10;5;2;1]

    @"P.152"
    let amount: list<Denom> -> Tuple -> int = fun ds cs ->
        List.sum (List.map2 (*) ds cs)
    amount usds [2;1;0;0;1;1] |> should equal 256

    @"P.153"
    let count: list<int> -> int = List.sum
    let rec mktuples: list<Denom> -> int -> list<Tuple> = fun Ds n ->
        match Ds with
        | [] -> [[]]
        | [1] -> [[n]]
        | d::ds -> [for c in [0..(n/d)] do
            for cs in mktuples ds (n-c*d) do c::cs]
    let mkchange: list<Denom> -> int -> Tuple = fun ds n ->
        minWith count (mktuples ds n)
    List.length (mktuples usds 256) |> should equal 6620
    List.length (mktuples ukds 256) |> should equal 223195

    @"P.153"
    module P153_1 =
        let mkchange ds n = List.max (mktuples ds n)
        mkchange [1] 1 |> should equal [1]

        let rec mktuples: list<Denom> -> int -> list<Tuple> = fun Ds n ->
            match Ds with
            | [] -> [[]]
            | [1] -> [[n]]
            | d::ds ->
                let extend ds c = List.map (fun x -> c::x) (mktuples ds (n-c*d))
                List.collect (extend ds) [0..n/d]

    "P.155"
    module P155_1 =
        let mkchange: list<Denom> -> int -> Tuple = fun xs n ->
            match xs with
            | [] -> []
            | [1] -> [n]
            | d::ds ->
                let c = n/d
                c::mkchange ds (n-c*d)

        mkchange ukds 256 |> should equal [1;0;1;0;0;1;0;1]
        mkchange usds 256 |> should equal [2;1;0;0;1;1]
        mkchange [7;3;1] 54 |> should equal [7;1;2]

@"P.157, 7.4 Decimal fractions in TeX"
module DecimalFractionsInTeX =
    // Digit is an integer d in 0 \leq d < 10
    type Digit = Int
    @"P.157"
    let shiftr: int -> double -> double = fun d r -> ((double d) + r) / 10.0
    shiftr 3 2.0 |> should equal 0.5
    let fraction: list<int> -> double = fun xs -> List.foldBack shiftr xs 0.0
    fraction [1;2;3] |> should equal 0.123

    @"P.157, 2^{17} = 131072"
    let scale: double -> int = fun r -> floor ((131072.0*r + 1.0) / 2.0) |> int
    let intern: list<int> -> int = scale << fraction

    module P157_1 =
        let halve n = (n+1) / 2
        let convert r = floor (131072.0 * r) |> int
        let scale x = halve (convert x)
        let shiftn d n = (131072*d + n) / 10
        let intern: list<int> -> int = fun xs -> halve <| List.foldBack shiftn xs 0

    @"P.160"
    let rec decimals: int * int -> list<list<int>> = fun (a,b) ->
        if a <= 0 then [[]]
        else
            let w = 131072
            let l = max 0 ((10*a) / w)
            let u = max 9 ((10*b) / w )
            [for d in [l..u] do for ds in decimals (10*a - w*d, 10*b - w*d) do d::ds]
    @"P.159"
    let externs n = decimals (2*n-1, 2*n+1)
    @"P.158, extern in the Book"
    let extrn: int -> list<int> = fun n -> minWith List.length (externs n)

    @"P.160"
    module P160_1 =
        let rec decimal: int * int -> list<int> = fun (a,b) ->
            if a <= 0 then []
            else
                let w = 131072
                let d = (10*b)/ w
                d :: decimal (10*a-w*d, 10*b-w*d)
        let externs n = decimals (2*n-1, 2*n+1)
        @"P.160, extern in the book"
        let extrn xs = List.max (externs xs)

@"P.161, 7.5 Nondeterministic functions and refinement"
@"P.165, 7.6 Summary"
@"P.166, Exercise7.1;  P.170, Answer7.1"
module P170_1 =
    module Simple =
        let minWith f xs = List.minBy f xs
        @"
        minWith1 f = minimumBy cmp
            where cmp x y = compare (f x) (f y)
        "
    @"
    minwith2 f = snd . minimumBY cmp . map tuple
      where
        tuple x = (f x, x)
        cmp (x,_) (y,_) = compare x y
    "
@"P.166, Exercise7.2;  P.170, Answer7.2"
module P171_1 =
    module Simple =
        let minsWith f xs =
            xs |> List.filter (fun x -> List.forall (fun y -> f x <= f y) xs)
        minsWith id [1..3] |> should equal [1]
        minsWith (fun x -> if x=1||x=2 then 1 else x) [1..10] |> should equal [1;2]

    module Efficient =
        let minsWith f xs =
            let tuple x = (f x, x)
            let step x = function
            | [] -> [x]
            | y::ys ->
                let a = fst x
                let b = fst y
                if a < b then [x]
                elif a = b then x::y::ys
                else y::ys
            List.map tuple xs
            |> Lib.foldr step []
            |> List.map snd
        minsWith id [1..3] |> should equal [1]
        minsWith (fun x -> if x=1||x=2 then 1 else x) [1..10] |> should equal [1;2]

@"P.166, Exercise7.3;  P.170, Answer7.3"
module P171_2 =
    let chk f xss =
        List.reduceBack f (List.collect id xss) = List.reduceBack f (List.map (List.reduceBack f) xss)
    chk (fun x y -> x*y) [[1;2];[3;4]]

@"P.167, Exercise7.4;  P.170, Answer7.4"
module P171_3 =
    let cp: list<'a> -> list<'b> ->  list<'a * 'b> = fun xs ys ->
        [for x in xs do for y in ys do (x,y)]
    let rec interleave: list<'a>*list<'a> -> list<list<'a>> = function
        | (xs,[]) -> [xs]
        | ([],ys) -> [ys]
        | (x::xs, y::ys) ->
            List.map (fun z -> x::z) (interleave (xs, y::ys))
            @ List.map (fun z -> y::z) (interleave (x::xs, ys))
    let rec perms: list<'a> -> list<list<'a>> = function
    | [] -> [[]]
    | [x] -> [[x]]
    | xs ->
        let (ys,zs) = List.splitAt (List.length xs / 2) xs
        let yss = perms ys
        let zss = perms zs
        List.collect interleave (cp yss zss)
    perms [1..3] |> should equal [[1;2;3];[2;1;3];[2;3;1];[1;3;2];[3;1;2];[3;2;1]]
@"P.167, Exercise7.5;  P.170, Answer7.5"
@"
minimum (map (x:) [ ]) = ⊥
x:minimum [ ] = x:⊥"
@"P.167, Exercise7.6;  P.170, Answer7.6"
@"P.167, Exercise7.7;  P.170, Answer7.7"
@"P.167, Exercise7.8;  P.170, Answer7.8"
@"P.167, Exercise7.9;  P.170, Answer7.9"
@"P.167, Exercise7.10; P.170, Answer7.10"
module P173_1 =
    let rec pick = function
    | [] -> failwith "error"
    | [x] -> (x, [])
    | x::xs ->
        let (y,ys) = pick xs
        if x <= y then (x,xs) else (y,x::ys)
    pick [1..3]

@"P.167, Exercise7.11; P.170, Answer7.11"
module P173_2 =
    @"P.152"
    type Denom = int
    type Tuple = list<int>
    let rec mktuples: list<Denom> -> int -> list<Tuple> = fun xs n ->
        match xs with
        | [] -> failwith "error"
        | [1] -> [[n]]
        | d::ds ->
            let m = n / d
            [for c in [m..(-1)..0] do for cs in mktuples ds (n-c*d) do c::cs]

@"P.167, Exercise7.12; P.173, Answer7.12"
@"P.168, Exercise7.13; P.174, Answer7.13"
@"P.168, Exercise7.14; P.174, Answer7.14"
module P174_1 =
    type Denom = int
    type Weights = list<int>
    type Tuple = list<int>
    let weight: Weights -> Tuple -> int = fun ws cs ->
        List.sum (List.map2 (*) ws cs)

    let mktuples: list<Denom> -> int -> list<Tuple> = fun ds n ->
        let finish: list<'a*int> -> list<'a> = fun xs ->
            xs |> List.filter (fun (cs,r) -> r=0) |> List.map fst
        let extend: Denom -> Tuple*int -> list<Tuple*int> = fun d (cs,r) ->
            [for c in [0..(r/d)] do (cs@[c], r-c*d)]
        finish (Lib.foldr (List.collect << extend) [([], n)] (List.rev ds))

    let mkchangew: Weights -> list<Denom> -> int -> Tuple = fun ws ds n ->
        mktuples ds n |> Lib.minWith (weight ws)

    let mkchange ds n =
        let gstep d (cs,r) =
            let c = r / d
            (cs@[c], r-c*d)
        fst (Lib.foldr gstep ([], n) (List.rev ds))

    let ukws = [1200;950;800;500;650;325;712;356]
    let ukds: list<Denom> = [200;100;50;20;10;5;2;1]
    let test = [for n in [1..200] do if (mkchange ukds n) <> (mkchangew ukws ukds n) then yield n]

    mkchange ukds 2 = [0;0;0;0;0;0;1;0]
    mkchangew ukws ukds 2 = [0;0;0;0;0;0;0;2]

@"P.168, Exercise7.15; P.170, Answer7.15"
@"P.168, Exercise7.16; P.170, Answer7.16"
@"P.168, Exercise7.17; P.170, Answer7.17"
@"P.168, Exercise7.18; P.170, Answer7.18"
@"P.168, Exercise7.19; P.170, Answer7.19"
@"P.169, Exercise7.20; P.170, Answer7.20"
@"P.169, Exercise7.21; P.170, Answer7.21"
@"P.169, Exercise7.22; P.170, Answer7.22"
@"P.169, Exercise7.23; P.170, Answer7.23"
@"P.169, Exercise7.24; P.170, Answer7.24"
@"P.170, Exercise7.25; P.170, Answer7.25"
