#r "nuget: FsUnit"
open FsUnit

/// P.155, 8.1 Divide-and-conquer
/// P.157
let divideAndConquer: ('p -> bool) -> ('p -> 's) -> ('p -> 'p list) -> ('p -> 's list -> 's) -> 'p -> 's =
  fun ind solve divide combine ->
    let rec dc pb = if ind pb then solve pb else combine pb (List.map dc (divide pb))
    dc

// From Section6.3.4
let rec merge: 'a list -> 'a list -> 'a list = fun a b ->
  match (a,b) with
    | [],b -> b
    | a,[] -> a
    | (x::xs), (y::ys) ->
      if x<=y then x :: merge xs b else y :: merge a ys

/// P.157, 8.1.2 Mergesort
let msort: 'a list -> 'a list = fun xs ->
  let ind xs = List.length xs <= 1
  let divide xs = let n = List.length xs / 2 in [ List.take n xs; List.skip n xs ]
  let combine n = function
    | [l1;l2] -> merge l1 l2
    | _ -> failwith "undefined"
  divideAndConquer ind id divide combine xs

/// P.158 8.1.3 Quicksort
let qsort: 'a list -> 'a list = fun xs ->
  let ind xs = List.length xs <= 1
  let divide = function
    | x::xs -> [ List.filter ((>=) x) xs ; List.filter ((<) x) xs]
    | _ -> failwith "undefined"
  let combine xs ls =
    match (xs, ls) with
      | (x::_), [l1;l2] -> l1 @ [x] @ l2
      | _, _ -> failwith "undefined"
  divideAndConquer ind id divide combine xs

let () =
  msort [10..-1..1] |> should equal [1..10]
  qsort [10..-1..1] |> should equal [1..10]
  merge [] [1..3] |> should equal [1..3]
  merge [1..3] [] |> should equal [1..3]
  merge [1..3] [4..6] |> should equal [1..6]
