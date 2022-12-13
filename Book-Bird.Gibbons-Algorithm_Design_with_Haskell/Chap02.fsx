#r "nuget: FsUnit"
open FsUnit

@"P.025, 2.1 Asymptotic notation"
@"P.027, 2.2 Estimating running times"
module P030_1 =
    let concat1 xss = List.foldBack (@) xss []
    let concat2 xss = List.fold (@) [] xss
    concat1 [[1];[2];[3]] |> should equal [1;2;3]
    concat2 [[1];[2];[3]] |> should equal [1;2;3]

module P030_2 =
    let rec concat1 = function
    | [] -> []
    | xs::xss -> xs @ concat1 xss
    concat1 [[1];[2];[3]] |> should equal [1;2;3]

    let rec step ws = function
    | [] -> ws
    | xs::xss -> step (ws@xs) xss
    let concat2 xss = step [] xss
    concat2 [[1..2]; [3..5]; [6..9]] |> should equal [1..9]

module P031 =
    let rec inserts x = function
    | [] -> [[x]]
    | y::ys -> (x::y::ys) :: (List.map (fun z -> y::z) (inserts x ys))
    let perms1 xs = List.foldBack (List.collect << inserts) xs [[]]

    inserts 0 [1..2] |> should equal [[0; 1; 2]; [1; 0; 2]; [1; 2; 0]]
    perms1 [1..3] |> should equal [[1; 2; 3]; [2; 1; 3]; [2; 3; 1]; [1; 3; 2]; [3; 1; 2]; [3; 2; 1]]

    let rec picks = function
    | [] -> []
    | x::xs -> (x,xs) :: [for (y,ys) in picks xs do (y, x::ys)]
    let rec perms2 = function
    | [] -> [[]]
    | xs -> List.collect subperms (picks xs)
    and subperms (x,ys) = List.map (fun z -> x::z) (perms2 ys)

    picks [1..3] |> should equal [(1, [2; 3]); (2, [1; 3]); (3, [1; 2])]
    perms2 [1..3] |> should equal [[1; 2; 3]; [1; 3; 2]; [2; 1; 3]; [2; 3; 1]; [3; 1; 2]; [3; 2; 1]]

@"P.032, 2.3 Running times in context"
module P033 =
    let rec inits: list<'a> -> list<list<'a>> = function
    | [] -> [[]]
    | x::xs -> [] :: List.map (fun z -> x::z) (inits xs)
    inits (List.ofSeq "abcd") |> should equal  [[]; ['a']; ['a'; 'b']; ['a'; 'b'; 'c']; ['a'; 'b'; 'c'; 'd']]

    let rec tails: list<'a> -> list<list<'a>> = function
    | [] -> [[]]
    | x::xs -> (x::xs) :: tails xs
    tails (List.ofSeq "abcd") |> should equal  [['a'; 'b'; 'c'; 'd']; ['b'; 'c'; 'd']; ['c'; 'd']; ['d']; []]

@"P.035, 2.4 Amortised running times"
module P035_1 =
    let foldr f e xs = List.foldBack f xs e
    // List.skipWhile in F#
    let rec dropWhile: ('a -> bool) -> list<'a> -> list<'a> = fun p xs ->
        match xs with
        | [] -> []
        | y::ys -> if p y then dropWhile p ys else xs
    dropWhile (fun x -> x < 3) [0..5] |> should equal [3;4;5]

    let insert p x xs = x :: dropWhile (p x) xs
    insert (=) 4 [4;4;2;1;1;1;2;5] |> should equal [4; 2; 1; 1; 1; 2; 5]
    insert (=) 1 [1;1;2;5] |> should equal [1; 2; 5]
    insert (=) 2 [5] |> should equal [2;5]
    let build: ('a -> 'a -> bool) -> list<'a> -> list<'a> = fun p xs -> foldr (insert p) [] xs
    build (=) [4;4;4;2;1;1;1;2;5] |> should equal [4;2;1;2;5]

@"P.35, inc, iterate, bits"
module P035_2 =
    let rec inc xs =
        if Seq.isEmpty xs then seq [1]
        else
            let (y, ys) = (Seq.head xs, Seq.tail xs)
            if y = 0 then Seq.append (seq [1]) ys
            else Seq.append (seq [1]) (inc ys)
    inc (seq [1;1;1]) |> should equal (seq [1;1;1;1])
    let rec iterate f x = seq {
        yield x
        yield! iterate f (f x)
    }
    (iterate ((*) 2) 1) |> Seq.take 3 |> should equal (seq [1;2;4])

    let bits: int -> seq<seq<int>> = fun n ->
        Seq.take n (iterate inc (seq []))
    bits 3 |> should equal (seq [seq []; seq [1]; (seq [1; 1])])

@"P.37, prune"
module P037 =
    @"haskell until
    https://hackage.haskell.org/package/base-4.16.0.0/docs/Prelude.html#v:until"
    let until: ('a -> bool) -> ('a -> 'a) -> 'a -> 'a = fun p f x ->
        let rec go y = if p y then y else go (f y)
        go x
    until (fun x -> x%2=0) (fun x -> x+1) 1 |> should equal 2

    @"Haskell init, not List.init
    https://hackage.haskell.org/package/base-4.16.0.0/docs/Prelude.html#v:init"
    let rec init: list<'a> -> list<'a> = function
    | [] -> failwith "Undefined"
    | [x] -> []
    | x::xs -> x :: init xs
    init [1] |> should equal List.empty<int>
    init [1;2;3;4] |> should equal [1;2;3]

    let prune: (list<'a> -> bool) -> list<'a> -> list<'a> = fun p xs ->
        let doneFunc xs = List.isEmpty xs || p xs
        let cut x xs = until doneFunc init (x::xs)
        List.foldBack cut xs []

    let ordered xs = (List.sort xs) = xs
    ordered [1..3] |> should equal true
    ordered [1;3;2] |> should equal false
    prune ordered [3;7;8;2;3] |> should equal [3;7;8]

@"P.38, Exercise 2.1, No code"
@"P.38, Exercise 2.2, No code"
@"P.39, Exercise 2.3, No code"
@"P.39, Exercise 2.4, No code"
@"P.39, Exercise 2.5, No code"
@"P.39, Exercise 2.6, No code"
@"P.39, Exercise 2.7, No code"
@"P.39, Exercise 2.8, No code"
@"P.39, Exercise 2.9; P.41, Answer 2.9"
module P039_1 =
    let op1 xs y = if List.isEmpty xs then y else List.head xs
    let chk1 xs ys = (List.head (xs @ ys)) = op1 xs (List.head ys)
    chk1 [1..2] [3..4] |> should equal true
    let fusionChk2 xss = (List.concat xss |> List.head) = (List.foldBack op1 xss 0)
    fusionChk2 [[1..2]; [3..4]] |> should equal true

@"P.39, Exercise 2.10"
module P039_2 =
    @"P.22, Answer 1.15"
    let rec remove x = function
    | [] -> []
    | y::ys -> if x=y then ys else y::(remove x ys)
    remove 1 [1;1] |> should equal [1]
    remove 1 [1;3] |> should equal [3]
    remove 1 [2;3] |> should equal [2;3]

    let rec perms3 = function
    | [] -> [[]]
    | xs ->
        let subperms x = List.map (fun ys -> x::ys) (perms3 (remove x xs))
        List.collect subperms xs
    perms3 [1..3] |> should equal  [[1;2;3]; [1;3;2]; [2;1;3]; [2;3;1]; [3;1;2]; [3;2;1]]

@"P.39, Exercise 2.11, No code"
@"P.39, Exercise 2.12, P.42, Answer 2.12"
module P039_3 =
    let rec help: (list<'a> -> 'b) -> list<'a> -> list<'b> = fun f -> function
        | [] -> f [] :: []
        | x::xs -> f [] :: help (fun y -> (x::y) |> f) xs
    help id [1..2] |> should equal  [[]; [1]; [1; 2]]
    help id [1..3] |> should equal  [[]; [1]; [1; 2]; [1;2;3]]
    let inits xs = help id xs
    inits [1..2] |> should equal  [[]; [1]; [1; 2]]
    inits [1..3] |> should equal  [[]; [1]; [1; 2]; [1;2;3]]

@"P.40, Exercise 2.13, No code"
@"P.40, Exercise 2.14; P.40, Answer 2.14"
module P040_1 =
    @"haskell iterate
    http://fssnip.net/18/title/Haskell-function-iterate
    iterate :: (a -> a) -> a -> [a]
    iterate f x = x : iterate f (f x)"
    let rec iterate f x = seq {
        yield x
        yield! iterate f (f x)
    }
    Seq.take 10 (iterate ((*) 2) 1) |> should equal (seq [1;2;4;8;16;32;64;128;256;512])

    let tailsl1 xs = xs |> iterate List.tail |> Seq.takeWhile (fun x -> Seq.isEmpty x |> not)
    tailsl1 [1..3] |> should equal [[1; 2; 3]; [2; 3]; [3]]

@"P.40, Exercise 2.15, No code"
