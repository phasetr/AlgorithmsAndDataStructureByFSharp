(*
   Rabhi-Lapalme P.107
   See also ../../DataStructures/AvlTree.fsx
*)
#r "nuget: FsUnit"
open FsUnit

type 'a AVLTree = | EmptyAVL | NodeAVL of 'a * 'a AVLTree * 'a AVLTree

let emptyAVL = EmptyAVL

let rec height = function
  | EmptyAVL -> 0
  | NodeAVL(_,lf,rt) -> 1 + max (height lf) (height rt)

let rotateLeft = function
  | EmptyAVL -> EmptyAVL
  | NodeAVL(v, NodeAVL (lv,lflf,lfrt), rt) -> NodeAVL(lv, lflf, NodeAVL(v,lfrt,rt))
  | _ -> failwith "undefined"

let rotateRight = function
  | EmptyAVL -> EmptyAVL
  | NodeAVL(v,lf,NodeAVL(rv,rtlf,rtrt)) -> NodeAVL(rv,(NodeAVL(v,lf,rtlf)),rtrt)
  | _ -> failwith "undefined"

let dRotateRightLeft = function
  | NodeAVL(v,lf,NodeAVL(rv,NodeAVL(rtlv,rtlflf,rtlfrt),rtrt)) ->
    NodeAVL(rtlv,NodeAVL(v,lf,rtlflf),NodeAVL(rv,rtlfrt,rtrt))
  | _ -> failwith "undefined"

let dRotateLeftRight = function
  | NodeAVL(v,NodeAVL(lv,lflf,NodeAVL(lfrv,lfrtlf,lfrtrt)),rt) ->
    NodeAVL(lfrv,NodeAVL(lv,lflf,lfrtlf),NodeAVL(v,lfrtrt,rt))
  | _ -> failwith "undefined"

let rec addAVL i = function
  | EmptyAVL -> NodeAVL(i,EmptyAVL,EmptyAVL)
  | NodeAVL(v,lf,rt) as node ->
    if i<v then
      let NodeAVL(newlfv,_,_) as newlf = addAVL i lf
      if (height newlf - height rt) = 2
      then if i<newlfv then rotateLeft (NodeAVL(v,newlf,rt)) else dRotateLeftRight (NodeAVL(v,newlf,rt))
      else NodeAVL(v,newlf,rt)
    else
      let NodeAVL(newrtv,_,_) as newrt = addAVL i rt
      if (height newrt - height lf) = 2
      then if i>newrtv then rotateRight (NodeAVL(v,lf,newrt)) else dRotateRightLeft (NodeAVL(v,lf,newrt))
      else NodeAVL(v,lf,newrt)

let test =
  let t1 = addAVL 1 EmptyAVL
  t1 |> should equal (NodeAVL (1, EmptyAVL, EmptyAVL))
  let t2 = addAVL 0 t1
  t2 |> should equal (NodeAVL (1, NodeAVL (0, EmptyAVL, EmptyAVL), EmptyAVL))
  let t3 = addAVL 2 t1
  t3 |> should equal (NodeAVL (1, EmptyAVL, NodeAVL (2, EmptyAVL, EmptyAVL)))
  let t4 = addAVL 2 t2
  let t5 = addAVL 0 t3
  t4 |> should equal t5
