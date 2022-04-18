#r "nuget: FsUnit"
open FsUnit

// cf. https://qiita.com/7shi/items/1e2a66bf8e8c7f0bd70f
module Bubble1 =
    /// Move the min value to rightmost.
    let rec bswap = function
        | [] -> []
        | [x] -> [x]
        | zs ->
            let (x,xs) = (List.head zs, List.tail zs)
            let (y,ys) = bswap xs |> fun x -> (List.head x, List.tail x)
            if y<x then y::x::ys else x::y::ys

    /// bubble sort
    let rec bsort = function
        | [] -> []
        | xs ->
            let (y,ys) = bswap xs |> fun x -> (List.head x, List.tail x)
            y::bsort ys

    bswap [4;3;1;5;2] |> should equal [1;4;3;2;5]
    bsort [4;3;1;5;2] |> should equal [1..5]
    bsort [5;4;3;2;1] |> should equal [1..5]

// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_A/review/3094870/little_Haskeller/Haskell
module Bubble2 =
    let swap i (b,xs,m) =
        let (sorted,unsorted) = List.splitAt i xs
        let (x,y,zs) = (List.head unsorted, unsorted.[1], unsorted.[2..])
        if y<x
        then (true, sorted@y::x::zs, m+1)
        else (b,    xs,              m)
    let rec bubble (b,xs,m) =
        if b then
            let n = (List.length xs) - 2
            let res = List.foldBack swap [0..n] (false,xs,m)
            bubble res
        else (xs,m)
    let bsort xs = bubble (true,xs,0)

    List.foldBack swap [0..3] (false,[5;3;2;4;1],0) |> should equal (true,[1;5;3;2;4],4)
    @"処理をしない[5;3;2;4;1]もリストに積まれるため,
    次のscanBackの結果のリストの要素数は5であって4ではないことに注意."
    List.scanBack swap [0..3] (false,[5;3;2;4;1],0) |> List.length |> should equal 5
    List.foldBack swap [0..3] (true,[1;5;3;2;4],4) |> should equal (true,[1;2;5;3;4],6)
    List.foldBack swap [0..3] (true,[1;2;5;3;4],6) |> should equal (true,[1;2;3;5;4],7)
    List.foldBack swap [0..3] (true,[1;2;3;5;4],7) |> should equal (true, [1;2;3;4;5],8)
    bsort [5;3;2;4;1] |> should equal ([1..5],8)
    bsort [5;2;4;6;1;3] |> should equal ([1..6],9)

module Bubble3 =
    @"Bubble2で処理したリストの変遷を追う.
    上記でのscanBackの処理にあたる."
    let swap i (b,xss) =
        let (sorted,unsorted) = List.splitAt i (List.head xss)
        let (x,y,zs) = (List.head unsorted, unsorted.[1], unsorted.[2..])
        if y<x
        then (true, (sorted@y::x::zs)::xss)
        else (b,    xss)
    let rec bubble (b,xss) =
        if b then
            let n = (List.length (List.head xss)) - 2
            let res = List.foldBack swap [0..n] (false,xss)
            bubble res
        else xss
    let bsort xs = bubble (true,[xs]) |> List.distinct
    bsort [5;3;2;4;1] |> List.rev |> List.iter (printfn "%A")
