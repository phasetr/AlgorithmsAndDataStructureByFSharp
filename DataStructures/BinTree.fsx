// Rabhi-Lapalme, P.100
module BinTree =
    type BinTree<'a when 'a: comparison> =
        | EmptyBT
        | NodeBT of 'a * 'a BinTree * 'a BinTree

    let emptyTree = EmptyBT

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
