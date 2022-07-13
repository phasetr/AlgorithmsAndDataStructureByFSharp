(* Rabhi-Lapalme, P.100 *)
#r "nuget: FsUnit"
open FsUnit

type BinTree<'a when 'a: comparison> =
  | EmptyBT
  | NodeBT of 'a * 'a BinTree * 'a BinTree

let emptyTree = EmptyBT

let btEmpty = function
  | EmptyBT -> true
  | _ -> false

let rec inTree v1 = function
  | EmptyBT -> false
  | NodeBT (v, lf, rt) ->
    if v1 = v then true
    elif v1 < v then inTree v1 lf
    else inTree v1 rt

let rec addTree v1 = function
  | EmptyBT -> NodeBT(v1, EmptyBT, EmptyBT)
  | NodeBT (v, lf, rt) ->
    if v1 = v then NodeBT(v, lf, rt)
    elif v1 < v then NodeBT(v, (addTree v1 lf), rt)
    else NodeBT(v, lf, (addTree v1 rt))

let buildTree xs = List.foldBack addTree xs EmptyBT

let rec buildTree' = function
  | [] -> EmptyBT
  | lf ->
    let n = (List.length lf) / 2
    let l1, l2 = List.splitAt n lf
    //let l1 = List.take n lf
    //let x :: l2 = List.drop n lf
    NodeBT(List.head l2, buildTree' l1, buildTree' (List.tail l2))

let rec minTree = function
  | NodeBT (v, EmptyBT, _) -> Some v
  | NodeBT (_, lf, _) -> minTree lf
  | _ -> None

let rec delTree v1 = function
  | EmptyBT -> EmptyBT
  | NodeBT (v, lf, EmptyBT) as node -> if v1 = v then lf else node
  | NodeBT (v, EmptyBT, rt) as node -> if v1 = v then rt else node
  | NodeBT (v, lf, rt) ->
      if v1 < v then NodeBT(v, delTree v1 lf, rt)
      elif v1 > v then NodeBT(v, lf, delTree v1 rt)
      else
        let k = minTree rt
        match k with
          | Some x -> NodeBT(x, lf, delTree x rt)
          | _      -> NodeBT(v1, lf, rt)

let rec inorder = function
  | EmptyBT -> []
  | NodeBT (v, lf, rt) -> (inorder lf) @ (v :: inorder rt)

let test =
  EmptyBT |> printfn "%A"
  EmptyBT |> btEmpty |> should be True
  EmptyBT |> addTree 1 |> should equal (NodeBT (1,EmptyBT,EmptyBT))
  EmptyBT |> addTree 1 |> addTree 2  |> should equal (NodeBT (1,EmptyBT,NodeBT (2,EmptyBT,EmptyBT)))
  EmptyBT |> addTree 1 |> inTree 1 |> should be True
  EmptyBT |> addTree 1 |> inTree 2 |> should be False

  buildTree [] |> minTree |> should equal None
  buildTree [3;2;1] |> should equal (NodeBT (1,EmptyBT,NodeBT(2,EmptyBT,NodeBT(3,EmptyBT,EmptyBT))))
  buildTree [3;2;1] |> inorder |> should equal [1;2;3]
  buildTree [3;2;1] |> minTree |> should equal (Some 1)
  buildTree [3;2;1] |> delTree 1 |> should equal (NodeBT (2,EmptyBT,NodeBT (3,EmptyBT,EmptyBT)))
  buildTree [3;2;1] |> delTree 4 |> should equal (NodeBT (1,EmptyBT,NodeBT (2,EmptyBT,NodeBT (3,EmptyBT,EmptyBT))))
