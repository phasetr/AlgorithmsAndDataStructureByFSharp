#r "nuget: FsUnit"
open FsUnit

@"P.5, 1.1 Basic types and functions"

@"P.006"
type nat = uint

let length: 'a list -> nat = fun xs -> List.length xs |> uint
length [1..3] |> should equal 3

let rec map: ('a -> 'b) -> 'a list -> 'b list = fun f ys ->
    match ys with
    | [] -> []
    | x::xs -> f x :: map f xs
map (fun x -> x+1) [1..3] |> should equal [2..4]

let rec filter: ('a -> bool) -> 'a list -> 'a list = fun p ys ->
    match ys with
    | [] -> []
    | x::xs -> if p x then x::filter p xs else filter p xs
filter (fun x -> x%2 = 0) [1..4] |> should equal [2;4]


// REMARK: The order of arguments fo Haskell `foldr` and F# `foldBack` is different!!
// For Haskell, `perms1 = foldr (concatMap . inserts) [[ ]]`
let rec foldr: ('a -> 'b -> 'b) -> 'b -> 'a list -> 'b = fun f e ys ->
    match ys with
    | [] -> e
    | x::xs -> f x (foldr f e xs)
foldr (fun x y -> x+y) 0 [1..3] |> should equal 6
foldr (fun x y -> x-y) 0 [1..3] |> should equal 2
foldr (fun x y -> x-y) 1 [1..3] |> should equal 1
// foldr + e [x,y,z] = x+(y+(z+e))
// foldr - e [x,y,z] = x-(y-(z-e))
foldr (fun x y -> x::y) [] [1..3] |> should equal [1..3]
List.foldBack (fun x y -> x::y) [1..3] [] |> should equal [1..3]

let label xs = List.zip [0..(List.length xs-1)] xs
label [10;20;30] |> should equal [(0,10);(1,20);(2,30)]
List.indexed [10;20;30] |> should equal (label [10;20;30])

module P007_1 =
    let succ _ n = n+(uint 1) |> uint
    let length: 'a list -> nat = fun xs -> foldr succ (uint 0) xs
    length [1..3] |> should equal 3

let rec foldl: ('b -> 'a -> 'b) -> 'b -> 'a list -> 'b = fun f e ys ->
    match ys with
    | [] -> e
    | x::xs -> foldl f (f e x) xs
// foldl + e [x,y,z] = ((e+x)+y)+z
foldl (fun x y -> x+y) 0 [1;2;3] |> should equal 6
foldl (fun x y -> x-y) 0 [1;2;3] |> should equal -6

module P007_2 =
    let succ n _ = n+(uint 1) |> uint
    let length: 'a list -> nat = fun xs -> foldl succ (uint 0) xs
    length [1;2;3] |> should equal 3

module P007_3 =
    let flip f x y = f y x
    let foldl f e = foldr (flip f) e << List.rev
    foldl (fun x y -> x+y) 0 [1;2;3] |> should equal 6
    foldl (fun x y -> x-y) 0 [1;2;3] |> should equal -6

@"P.7, 1.2 Processing lists"
@"TODO
What is the bottom in F#?

let undefined() = lazy (raise (NotImplementedException()))

let (<<) x _ = x
let head xs =
    foldr (<<) undefined xs
head [1;2;3] |> should equal 1
"

@"List.concat in F#"
let concat1 xs = foldr (@) [] xs
let concat2: 'a list list -> 'a list = fun xs -> foldl (@) [] xs
concat1 [[1..2]; [3..4]] |> should equal [1..4]
concat2 [[1..2]; [3..4]] |> should equal [1..4]

@"List.scan in F#"
let rec scanl: ('b -> 'a -> 'b) -> 'b -> 'a list -> 'b list = fun f e -> function
    | [] -> [e]
    | x::xs -> e :: scanl f (f e x) xs
scanl (+) 1 [2;3;4] |> should equal [1;3;6;10]
@"scanl (+) e [x,y,z] = [e, e+x, (e+x)+y, ((e+x)+y)+z), ..."

@"P.9, 1.3 Inductive and recursive definitions"
let rec inserts: 'a -> 'a list -> 'a list list = fun x -> function
    | [] -> [[x]]
    | y::ys -> (x::y::ys) :: List.map (fun z -> y::z) (inserts x ys)
inserts 1 [2..3] |> should equal [[1; 2; 3]; [2; 1; 3]; [2; 3; 1]]

let rec perms1: 'a list -> 'a list list = function
    | [] -> [[]]
    | x::xs -> [for ys in perms1 xs do
                for zs in inserts x ys do zs]
perms1 [1;2;3] |> should equal [[1; 2; 3]; [2; 1; 3]; [2; 3; 1]; [1; 3; 2]; [3; 1; 2]; [3; 2; 1]]

module P010_1 =
    // 上で定義した`inserts`と同じ
    let rec inserts: 'a -> 'a list -> 'a list list = fun x -> function
        | [] -> [[x]]
        | y::ys -> (x::y::ys) :: List.map (fun z -> y::z) (inserts x ys)
    inserts 1 [2..3] |> should equal [[1; 2; 3]; [2; 1; 3]; [2; 3; 1]]

    let step x xss = List.collect (inserts x) xss
    step 1 [[1;2]; [3;4]] |> should equal [[1; 1; 2]; [1; 1; 2]; [1; 2; 1]; [1; 3; 4]; [3; 1; 4]; [3; 4; 1]]
    let perms1 xs = foldr step [[]] xs
    perms1 [1;2;3] |> should equal   [[1; 2; 3]; [2; 1; 3]; [2; 3; 1]; [1; 3; 2]; [3; 1; 2]; [3; 2; 1]]

module P010_2 =
    // 上で定義した`inserts`と同じ
    let rec inserts: 'a -> 'a list -> 'a list list = fun x -> function
        | [] -> [[x]]
        | y::ys -> (x::y::ys) :: List.map (fun z -> y::z) (inserts x ys)
    inserts 1 [2..3] |> should equal [[1; 2; 3]; [2; 1; 3]; [2; 3; 1]]

    // collect in F#
    let concatMap: ('a -> 'b list) -> 'a list -> 'b list = fun f -> (List.concat << List.map f)
    concatMap    (fun x -> [1..(x+1)]) [1..3] |> should equal [1;2;1;2;3;1;2;3;4]
    List.collect (fun x -> [1..(x+1)]) [1..3] |> should equal [1;2;1;2;3;1;2;3;4]

    let step x xss = (inserts >> List.collect) x xss
    step 1 [[1;2]; [3;4]] |> should equal [[1; 1; 2]; [1; 1; 2]; [1; 2; 1]; [1; 3; 4]; [3; 1; 4]; [3; 4; 1]]

    // REMARK: The order of arguments fo Haskell `foldr` and F# `foldBack` is different!!
    // For Haskell, `perms1 = foldr (concatMap . inserts) [[ ]]`
    let perms1: 'a list -> 'a list list = fun xs -> List.foldBack (List.collect << inserts) xs [[]]
    perms1 [1..3] |> should equal [[1; 2; 3]; [2; 1; 3]; [2; 3; 1]; [1; 3; 2]; [3; 1; 2]; [3; 2; 1]]

let rec picks: 'a list -> ('a * 'a list) list = function
    | [] -> []
    | x::xs -> (x, xs) :: [for (y,ys) in picks xs do (y, x::ys)]
picks [1;2;3] |> should equal  [(1, [2; 3]); (2, [1; 3]); (3, [1; 2])]
let rec perms2: list<'a> -> list<list<'a>> = function
    | [] -> [[]]
    | xs -> [for (x, ys) in picks xs do for zs in perms2 ys do x::zs]
perms2 [1;2;3] |> should equal [[1; 2; 3]; [1; 3; 2]; [2; 1; 3]; [2; 3; 1]; [3; 1; 2]; [3; 2; 1]]

module P010_3 =
    // 上で定義した`picks`と同じ
    let rec picks: 'a list -> ('a * 'a list) list = function
        | [] -> []
        | x::xs -> (x, xs) :: [for (y,ys) in picks xs do (y, x::ys)]
    picks [1;2;3] |> should equal  [(1, [2; 3]); (2, [1; 3]); (3, [1; 2])]
    // 相互再帰関数, mutual recursion
    let rec perms2: list<'a> -> list<list<'a>> = function
        | [] -> [[]]
        | xs -> List.collect subperms (picks xs)
    and subperms: 'a * list<'a> -> list<list<'a>> = fun (x, ys) ->
        List.map (fun zs -> x :: zs) (perms2 ys)
    perms2 [1;2;3] |> should equal [[1; 2; 3]; [1; 3; 2]; [2; 1; 3]; [2; 3; 1]; [3; 1; 2]; [3; 2; 1]]

let rec until: ('a -> bool) -> ('a -> 'a) -> 'a -> 'a = fun p f x ->
    if p x then x else until p f (f x)
until (fun x -> x > 100) (fun x -> x*2) 1 |> should equal 128
let isOdd x = x % 2 = 1
until isOdd (fun x -> x / 2) 400 |> should equal 25

// In the book, notuntil is `while`
let notuntil p = until (not << p)
notuntil (fun x -> x < 100) (fun x -> x*2) 1 |> should equal 128

@"P.011, 1.4 Fusion
We have the follwoing rules in Haskell notation.

- `map f . map g = map (f . g)`
- `concatMap f . map g = concatMap (f . g)`
- `foldr f e . map g = foldr (f . g) e`
- `h (foldr f e xs) = foldr g (h e) xs`
  where, for all finite lists `xs`, `h (f x y) = g x (h y)`
- `foldr f e . concat = foldr (flip (foldr f)) e`
"

@"P.014, 1.5 Accumulating and tupling"

@"P.014, collapse
Given a list xss of lists of integers, consider the
problem of concatenating the shortest prefix of xss whose total sum is positive.
If no sum is positive, then the whole list is concatenated."
let collapse: list<list<int>> -> list<int> =
    let rec help xs xss =
        if List.sum xs > 0 || List.isEmpty xss then xs
        else help (xs @ List.head xss) (List.tail xss)
    fun xss -> help [] xss
collapse [[1]; [-3]; [2;4]] |> should equal [1]
collapse [[-2;1]; [-3]; [2;4]] |> should equal [-2;1;-3;2;4]
collapse [[-2;1]; [3]; [2;4]] |> should equal [-2;1;3]

module P014 =
    let labelsum xss = List.zip (List.map List.sum xss) xss
    let cat (s, xs) (t, ys) = (s+t, xs@ys)
    let rec help (s, xs) xss =
        if s > 0 || List.isEmpty xss then xs
        else help (cat (s, xs) (List.head xss)) (List.tail xss)
    let collapse xss = help (0, []) (labelsum xss)
    @"P.015
    collapse [[−5,3],[−2],[−4],[−4,1]] = ((([ ]++[−5,3])++[−2])++[−4])++[−4,1]"

    labelsum [[1]; [-3]; [2;4]] |> should equal [(1, [1]); (-3, [-3]); (6, [2; 4])]
    cat (1, [1;2]) (3, [3;4]) |> should equal (4, [1;2;3;4])
    collapse [[1]; [-3]; [2;4]] |> should equal [1]
    collapse [[-2;1]; [-3]; [2;4]] |> should equal [-2;1;-3;2;4]
    collapse [[-2;1]; [3]; [2;4]] |> should equal [-2;1;3]

module P015 =
    // 上で定義した関数と同じ
    let labelsum xss = List.zip (List.map List.sum xss) xss
    let rec help (s, f) xss =
        if s > 0 || List.isEmpty xss then f
        else
            let (t, xs) = List.head xss
            help (s+t, f << (fun ys -> xs@ys)) (List.tail xss)
    let collapse xss = (help (0, id) (labelsum xss)) []

    collapse [[1]; [-3]; [2;4]] |> should equal [1]
    collapse [[-2;1]; [-3]; [2;4]] |> should equal [-2;1;-3;2;4]
    collapse [[-2;1]; [3]; [2;4]] |> should equal [-2;1;3]

@"P.019, Answer 1.1
maximum, minimum ::Ord a ⇒ [a] → a
take, drop::Nat → [a] → [a]
takeWhile,dropWhile::(a → Bool) → [a] → [a]
inits,tails::[a] → [[a]]
splitAt::Nat → [a] → ([a],[a])
span::(a → Bool) → [a] → ([a],[a])
null::[a] → Bool
all::(a → Bool) → [a] → Bool
elem::Eq a ⇒ a → [a] → Bool
(!!)::[a] → Nat → a
zipWith::(a → b → c) → [a] → [b] → [c]

In Haskell8.0,
maximum,minimum::(Foldable t,Ord a) ⇒ t a → a

foldr ::(a → b → b) → b → t a → b"

@"P.020, Answer 1.2"
let uncons: list<'a> -> option<'a * list<'a>> = function
    | [] -> None
    | x::xs -> Some (x, xs)
uncons List.empty<int> |> should equal None
uncons [1;2;3] |> should equal (Some (1, [2;3]))

@"P.020, Answer 1.3"
let wrap: 'a -> list<'a> = fun x -> [x]
wrap 1 |> should equal [1]

let unwrap: list<'a> -> 'a = fun x -> x.[0]
unwrap [1] |> should equal 1

let single: list<'a> -> bool = function
    | [x] -> true
    | _ -> false
single [1] |> should equal true
single [] |> should equal false
single [1;2] |> should equal false

@"P.020, Answer 1.4"
let flip f x y = f y x
@"List.rev in F#"
let reverse: list<'a> -> list<'a> = fun xs ->
    List.fold (flip (fun x y -> x::y)) [] xs
reverse [1;2;3] |> should equal [3;2;1]

@"P.020, Answer 1.5"
module P020_1 =
    let map f xs =
        let op x xs = f x::xs
        List.foldBack op xs []
    map (fun x -> x + 1) [0..2] |> should equal [1..3]

    let filter p xs =
        let op x xs = if p x then x::xs else xs
        List.foldBack op xs []
    filter (fun x -> x%2 = 0) [0..5] |> should equal [0;2;4]

@"P.020, Answer 1.6
Express foldr f e·filter p as an instance of foldr."
module P020_2 =
    let foldr f e xs = List.foldBack f xs e
    let check f p e xs =
        let op x y = if p x then f x y else y
        let lhs xs = foldr f e (List.filter p xs)
        let rhs xs = foldr op e xs
        lhs xs = rhs xs
    check (+) (fun x -> x%2 = 0) 0 [1..3]

@"P.020, Answer 1.7"
module P020_3 =
    let foldr f e xs = List.foldBack f xs e
    let takeWhile: ('a -> bool) -> list<'a> -> list<'a> = fun p ->
        let op x xs = if p x then x::xs else []
        foldr op []
    takeWhile (fun x -> x%2 = 0) [2;3;4;5] |> should equal [2]

@"P.021, Answer 1.8"
let dropWhileEnd: ('a -> bool) -> list<'a> -> list<'a> = fun p xs ->
    let op x xs = if p x && List.isEmpty xs then [] else x::xs
    List.foldBack op xs []
dropWhileEnd (fun x -> x%2=0) [1;4;3;6;2;4] |> should equal [1;4;3]

@"P.021, Answer 1.9"
module P021_1 =
    let head: list<'a> -> 'a = function
    | [] -> failwith "Empty list."
    | x::xs -> x
    head [1;2;3] |> should equal 1

    let tail: list<'a> -> list<'a> = function
    | [] -> failwith "Empty list."
    | x::xs -> xs
    tail [1;2;3] |> should equal [2;3]

    let rec last: list<'a> -> 'a = function
    | [] -> failwith "Empty list"
    | [x] -> x
    | _::xs -> last xs
    last [1;2;3] |> should equal 3

    let rec init: list<'a> -> list<'a> = function
    | [] -> failwith "Empty list"
    | [x] -> []
    | x::xs -> x :: init xs
    init [1;2;3] |> should equal [1;2]

@"P.021, Answer 1.10
When `foldr f e xs = foldl f e xs` for any finite xs?
=> one example: f is associative and e is identity"

@"P.021, Answer 1.11"
let shiftl n d = 10*n + d
let integer = List.fold shiftl 0
integer [1;4;8;4;9;3] |> should equal 148493
@"I do not understand `fraction` in F#.
`fraction [1,4,8,4,9,3] = 0.148493`

`fraction = foldr shiftr 0 where shiftr d x = (fromIntegral d +x)/10`

let shiftr d x = (d+x) / 10
let fraction xs = List.foldBack shiftr xs 0
fraction [1;4;8;4;9;3]"

@"P.021, Answer 1.12"
module P021_2 =
    let inits xs =
        [0 .. (List.length xs)]
        |> List.map (fun i -> List.take i xs)
    let chkL f e xs =
        let lhs = List.map (List.fold f e) (inits xs)
        let rhs = List.scan f e xs
        lhs = rhs
    chkL (+) 5 [1;2;3;4] |> should equal true

    let rec tails: list<'a> -> list<list<'a>> = function
    | [] -> [[]]
    | x::xs -> (x::xs)::(tails xs)
    let foldr f e xs = List.foldBack f xs e
    let chkR f e xs =
        let lhs = List.map (foldr f e) (tails xs)
        let rhs = List.scanBack f xs e
        lhs = rhs
    chkR (+) 5 [1;2;3;4]

@"P.022, Answer 1.13"
module P021_3 =
    type nat = uint

    let rec apply1: nat -> ('a -> 'a) -> 'a -> 'a = fun n f ->
        if n = 0u then id
        else f << (apply1 (n-1u) f)
    apply1 3u (fun x -> x+1) 0 |> should equal 3

    let rec apply2: nat -> ('a -> 'a) -> 'a -> 'a = fun n f ->
        if n = 0u then id
        else (apply2 (n-1u) f) << f
    apply2 3u (fun x -> x+1) 0 |> should equal 3

@"P.022, Answer 1.14"
module P022_1 =
    let foldr f e xs = List.foldBack f xs e
    let inserts x =
        let step y yss =
            let ys = List.tail (List.head yss)
            (x::y::ys) :: List.map (fun zs -> y::zs) yss
        foldr step [[x]]
    inserts 1 [2;3;4] |> should equal [[1; 2; 3; 4]; [2; 1; 3; 4]; [2; 3; 1; 4]; [2; 3; 4; 1]]

@"P.022, Answer 1.15"
let rec remove: 'a -> list<'a> -> list<'a> = fun x -> function
    | [] -> []
    | y::ys -> if x=y then ys else y::(remove x ys)
remove 1 [1;2;3] |> should equal [2;3]
remove 1 [2;3;4] |> should equal [2;3;4]
let rec perms3 = function
    | [] -> [[]]
    | xs -> [for x in xs do
             for ys in perms3 (remove x xs) do
             x::ys]
perms3 [1;2;3] |> should equal [[1; 2; 3]; [1; 3; 2]; [2; 1; 3]; [2; 3; 1]; [3; 1; 2]; [3; 2; 1]]

@"P.022, Answer 1.16 We would have to show the validity of fusion when the input is the
undefined list ⊥. Since foldr f e ⊥ = ⊥ we require that h has to be a strict function,
returning the undefined value if the argument is undefined."
module P022 =
    let replace x = if (x%2=0) then x else 0
    let f x y = 2*x + y
    let foldr f e xs = List.foldBack f xs e
    let chk xs =
        let lhs = foldr f 0 xs |> replace
        let rhs = foldr f 0 xs
        lhs = rhs
    chk [1..3] |> should equal true
    chk [1..10] |> should equal true
    chk [100..1000] |> should equal true

@"P.23, Answer 1.18
`h (foldl f e xs) = foldl g (h e) xs`
for all finite lists xs provided that
`h (f y x) = g (h y) x`
for all `y` and `x`."

@"P.023, Answer 1.19
No, it is false. Haskell is a lazy language in which only those values
which contribute to the answer are computed. In the best case of `collapse` the
remaining sums are discarded so they are never computed."

@"P.023, Answer 1.20
We can take `op f xs ys = f (xs ++ ys)`, though of course we cannot
concatenate an infinite list of lists this way."
module P023_2 =
    let op f xs ys = f (xs@ys)
    let chk xss =
        let lhs = List.concat xss
        let rhs = List.fold (op id) [] xss
        lhs = rhs
    chk [[1];[2];[3]] |> should equal true
    chk [[1..3];[4..8];[9..12]] |> should equal true

@"P.023, Answer 1.21"
module P023_3 =
    module Steep1 =
        let rec steep: list<int> -> bool = function
        | [] -> true
        | x::xs -> (x > List.sum xs) && steep xs
        steep [1;2;3] |> should equal false
        steep [4..2] |> should equal true

    module Steep2 =
        let rec faststeep: list<int> -> int * bool = function
        | [] -> (0, true)
        | x::xs ->
            let (s,b) = faststeep xs
            (x+s, x > s && b)
        let steep = snd << faststeep
        steep [1;2;3] |> should equal false
        steep [4..2] |> should equal true
