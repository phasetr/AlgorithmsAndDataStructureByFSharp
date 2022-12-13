#r "nuget: FsUnit"
#load "Lib.fsx"
open FsUnit
open Lib

@"P.177 Chapter 8 Greedy algorithms on trees"
@"P.177 8.1 Minimum-height trees"
module MinimumHeightTrees =
    type Tree<'a> = Leaf of 'a | Node of Tree<'a> * Tree<'a>

    @"P.177"
    let rec size: Tree<'a> -> int = function
    | Leaf(x) -> 1
    | Node(u,v) -> size u + size v

    @"P.178, essentially flatten"
    let rec fringe: Tree<'a> -> list<'a> = function
    | Leaf(x) -> [x]
    | Node(u,v) -> fringe u @ fringe v

    @"P.178"
    let rec mktree: list<'a> -> Tree<'a> = function
    | [] -> failwith "Empty list"
    | [x] -> Leaf x
    | xs ->
        let (ys, zs) = List.splitAt (List.length xs / 2) xs
        Node (mktree ys, mktree zs)
    mktree [1..4] |> fringe |> should equal [1..4]

    @"P.178"
    module UsingMergeSort =
        let rec pairWith f = function
            | [] -> []
            | [x] -> [x]
            | x::y::xs -> f (x,y) :: pairWith f xs
        let mktree xs =
            xs |> List.map Leaf
            |> Lib.until Lib.single (pairWith Node)
            |> Lib.unwrap
        mktree [1..5] |> fringe |> should equal [1..5]

    @"P.178"
    let rec cost: Tree<int> -> int = function
    | Leaf(x) -> x
    | Node(u,v) -> 1 + max (cost u) (cost v)
