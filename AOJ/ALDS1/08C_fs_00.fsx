#r "nuget: FsUnit"
open FsUnit

type tree = Nil | Node of int * tree * tree
let solve N Aa =
  let insert x t =
    let rec frec = function
      | Nil -> Node(x,Nil,Nil)
      | Node(y,l,r) -> if x < y then Node(y,frec l,r) else Node(y,l,frec r)
    in frec t
  let find x t =
    let rec frec = function
      | Nil -> false
      | Node(y,l,r) -> if x = y then true else if x < y then frec l else frec r
    frec t
  let delete x t =
    let rec frec = function
      | Nil -> Nil
      | Node(y, l, r) ->
         if x = y then
           if l = Nil then r
           else if r = Nil then l
           else
             let rec frec1 = function
               | Nil -> failwith "not come here"
               | Node(x, Nil, _) -> x
               | Node(_, l, _) -> frec1 l
             let rec frec2 = function
               | Nil -> failwith "not come here"
               | Node(_, Nil, r) -> r
               | Node(x, l, r) -> Node(x, frec2 l, r)
             Node(frec1 r, l, frec2 r)
         else if x < y then Node(y, frec l, r)
         else Node(y, l, frec r)
    frec t

  let preorder t =
    let rec frec = function
      | Nil -> []
      | Node(x,l,r) -> x :: frec l @ frec r
    frec t
  let inorder t =
    let rec frec = function
      | Nil -> []
      | Node(x,l,r) -> frec l @ [x] @ frec r
    frec t
  let print t =
    let f = List.map string >> (fun l -> ""::l) >> String.concat " " >> stdout.WriteLine
    inorder t |> f; preorder t |> f
  let printFind x t = (if find (int x) t then "yes" else "no") |> stdout.WriteLine

  (Nil,Aa)
  ||> Array.fold
    (fun t a ->
     match a with
     | [|"insert";n|] -> insert (int n) t
     | [|"find";n|] -> printFind (int n) t; t
     | [|"delete";n|] -> delete (int n) t
     | _ -> print t; t)

let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..N do (stdin.ReadLine().Split()) |]
solve N Aa

let N,Aa = 18,[|[|"insert";"8"|];[|"insert";"2"|];[|"insert";"3"|];[|"insert";"7"|];[|"insert";"22"|];[|"insert";"1"|];[|"find";"1"|];[|"find";"2"|];[|"find";"3"|];[|"find";"4"|];[|"find";"5"|];[|"find";"6"|];[|"find";"7"|];[|"find";"8"|];[|"print"|];[|"delete";"3"|];[|"delete";"7"|];[|"print"|]|]
solve N Aa
"""
yes
yes
yes
no
no
no
yes
yes
 1 2 3 7 8 22
 8 2 1 3 7 22
 1 2 8 22
 8 2 1 22
"""
