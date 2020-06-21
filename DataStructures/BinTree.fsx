(* Rabhi-Lapalme, P.100 *)

module BinTree =
    type BinTree<'a when 'a: comparison> =
        | EmptyBT
        | NodeBT of 'a * 'a BinTree * 'a BinTree

    let emptyTree = EmptyBT

    let btEmpty =
        function
        | EmptyBT -> true
        | _ -> false

    let rec inTree v1 tree =
        match tree with
        | EmptyBT -> false
        | NodeBT (v, lf, rt) ->
            if v = v1 then true
            else if v < v1 then inTree v1 lf
            else inTree v1 rt

    let rec addTree v1 tree =
        match tree with
        | EmptyBT -> NodeBT(v1, EmptyBT, EmptyBT)
        | NodeBT (v, lf, rt) ->
            if v = v1 then NodeBT(v, lf, rt)
            else if v < v1 then NodeBT(v, (addTree v1 lf), rt)
            else NodeBT(v, lf, (addTree v1 rt))

    let rec buildTree =
        function
        | [] -> EmptyBT
        | lf ->
            let n = (List.length lf) / 2
            let l1, l2 = List.splitAt n lf
            //let l1 = List.take n lf
            //let x :: l2 = List.drop n lf
            NodeBT(List.head l2, buildTree l1, buildTree (List.tail l2))

    let rec inorder =
        function
        | EmptyBT -> []
        | NodeBT (v, lf, rt) -> List.append (inorder lf) (v :: inorder rt)

    let rec minTree tree =
        match tree with
        | NodeBT (v, EmptyBT, _) -> Some v
        | NodeBT (_, lf, _) -> minTree lf
        | _ -> None

    let rec delTree v tree =
        match tree with
        | EmptyBT -> EmptyBT
        | NodeBT (v1, lf, EmptyBT) -> if v = v1 then lf else EmptyBT
        | NodeBT (v1, EmptyBT, rt) -> if v = v1 then rt else EmptyBT
        | NodeBT (v1, lf, rt) ->
            if v1 < v then
                NodeBT(v, delTree v1 lf, rt)
            else if v1 > v then
                NodeBT(v, lf, delTree v1 rt)
            else
                let k = minTree rt
                match k with
                | Some x -> NodeBT(x, lf, delTree x rt)
                | _ -> NodeBT(v1, lf, rt)


// test
open BinTree

EmptyBT |> printfn "%A"
EmptyBT |> btEmpty |> printfn "%A"
EmptyBT |> addTree 1 |> printfn "%A"
EmptyBT |> addTree 1 |> addTree 2 |> printfn "%A"
EmptyBT |> addTree 1 |> inTree 1 |> printfn "%A"
EmptyBT |> addTree 1 |> inTree 2 |> printfn "%A"

buildTree [] |> minTree |> printfn "%A"
buildTree [ 3; 2; 1 ] |> printfn "%A"
buildTree [ 3; 2; 1 ] |> inorder |> printfn "%A"
buildTree [ 3; 2; 1 ] |> minTree |> printfn "%A"
buildTree [ 3; 2; 1 ] |> delTree 1 |> printfn "%A"
buildTree [ 3; 2; 1 ] |> delTree 4 |> printfn "%A"
