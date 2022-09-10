#r "nuget: FsUnit"
open FsUnit
open System.Collections.Generic

type 'a tree = Nil | Tree of 'a
type wood = {key: int; priority: int; left: wood tree ; right: wood tree}
type treeCmd = Cnil | SupLeft of wood | SupRight of wood | AsIs of wood
let solve N Aa =
  let wood k p l r = {key = k; priority = p; left = l; right = r}
  let tree k p l r  = Tree (wood k p l r)
  let woodOfTree = (function Tree w -> w | Nil -> raise (Failure "woodOfTree"))

  let rightRotate: wood tree -> wood tree = function
    | Tree {key = ky; priority = py; left = Tree wx; right = c} ->
      tree  wx.key wx.priority wx.left (tree ky py wx.right c)
    | t -> t
  let leftRotate: wood tree -> wood tree = function
    | Tree {key = kx; priority = px; left = a; right = Tree wy} ->
      tree  wy.key wy.priority (tree kx px a wy.left) wy.right
    | t -> t

  let insertS t zw =
    let stk = Stack<treeCmd>()
    stk.Push Cnil
    let rec insP t =
      match t with
      | Nil -> Tree zw
      | Tree tw ->
        match (compare zw.key tw.key) with
        | 0 -> Nil
        | x when x < 0 -> (stk.Push (SupLeft tw); insP tw.left)
        | x -> (stk.Push (SupRight tw); insP tw.right) in
    let rec reconT t =
      match (stk.Pop()) with
      | SupLeft w ->
        let rt = tree w.key w.priority t w.right in
        reconT (if w.priority < (woodOfTree t).priority then rightRotate rt else rt)
      | SupRight w ->
        let rt = tree w.key w.priority w.left t in
        reconT (if w.priority < (woodOfTree t).priority then leftRotate rt else rt)
      | Cnil -> t
      | AsIs w -> Tree w in
    match insP t with
    | (Tree _) as zt -> reconT zt
    | Nil -> t

  let rec find t k =
    match t with
    | Nil -> "no"
    | Tree w ->
      match (compare k w.key) with
      | 0 -> "yes"
      | x when x < 0 -> find w.left k
      | _ -> find w.right k

  let deleteS t k =
    let stk = Stack<treeCmd>()
    stk.Push Cnil
    let rec delP t =
      match t with
      | Nil -> Nil
      | Tree tw ->
        match (compare k tw.key) with
        | 0 -> Tree tw
        | x when x < 0 -> (stk.Push (SupLeft tw); delP tw.left)
        | _ -> (stk.Push (SupRight tw); delP tw.right) in
    let rec delT t=
       match t with
       | Tree tw -> (
         match tw.left, tw.right with
         | Nil, Nil -> Nil
         | lt, Nil ->
           let rctw = woodOfTree (rightRotate t) in
           (stk.Push (SupRight rctw); delT rctw.right)
         | Nil, rt ->
           let rctw = woodOfTree (leftRotate t) in
           (stk.Push (SupLeft rctw); delT rctw.left)
         | lt, rt when (woodOfTree lt).priority > (woodOfTree rt).priority ->
           let rctw = woodOfTree (rightRotate t) in
           (stk.Push (SupRight rctw); delT rctw.right)
         | lt, rt ->
           let rctw = woodOfTree (leftRotate t) in
           (stk.Push (SupLeft rctw); delT rctw.left) )
       | Nil -> Nil
    let rec reconT t =
      match (stk.Pop()) with
      | SupLeft w ->
        let rt = reconT (tree w.key w.priority t w.right) in rt
      | SupRight w ->
        let rt = reconT (tree w.key w.priority w.left t) in rt
      | Cnil -> t
      | AsIs w -> Tree w in
    match delP t with
    | (Tree _) as zt -> (delT zt) |> (fun x -> reconT x)
    | Nil -> t

  let preorder t =
    let rec frec = function
      | Nil -> []
      | Tree w -> w.key :: frec w.left @ frec w.right
    frec t
  let inorder t =
    let rec frec = function
      | Nil -> []
      | Tree w -> frec w.left @ [w.key] @ frec w.right
    frec t
  let print t =
    let f = List.map string >> (fun l -> ""::l) >> String.concat " " >> stdout.WriteLine
    inorder t |> f; preorder t |> f

  (Nil,Aa)
  ||> Array.fold
    (fun t a ->
     match a with
     | [|"insert";n;p|] -> insertS t (wood (int n) (int p) Nil Nil)
     | [|"find";n|] -> find t (int n) |> stdout.WriteLine; t
     | [|"delete";n|] -> deleteS t (int n)
     | _ -> print t; t)

let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..N do (stdin.ReadLine().Split()) |]
solve N Aa

let N,Aa = 16,[|[|"insert";"35";"99"|];[|"insert";"3";"80"|];[|"insert";"1";"53"|];[|"insert";"14";"25"|];[|"insert";"80";"76"|];[|"insert";"42";"3"|];[|"insert";"86";"47"|];[|"insert";"21";"12"|];[|"insert";"7";"10"|];[|"insert";"6";"90"|];[|"print"|];[|"find";"21"|];[|"find";"22"|];[|"delete";"35"|];[|"delete";"99"|];[|"print"|]|]
solve N Aa
"""
 1 3 6 7 14 21 35 42 80 86
 35 6 3 1 14 7 21 80 42 86
yes
no
 1 3 6 7 14 21 42 80 86
 6 3 1 80 14 7 21 42 86
"""
