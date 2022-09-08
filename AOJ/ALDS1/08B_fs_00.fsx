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
    let f = List.map string >> String.concat " " >> stdout.WriteLine
    inorder t |> f; preorder t |> f
  let printFind x t = (if find (int x) t then "yes" else "no") |> stdout.WriteLine

  (Nil,Aa) ||> Array.fold (fun t a ->
    match a with
      | [|"insert";n|] -> insert (int n) t
      | [|"find";n|] -> printFind (int n) t; t
      | _ -> print t; t)

let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..N do (stdin.ReadLine().Split()) |]
solve N Aa |> Array.map string |> String.concat " " |> stdout.WriteLine

let N,Aa = 10,[|[|"insert";"30"|];[|"insert";"88"|];[|"insert";"12"|];[|"insert";"1"|];[|"insert";"20"|];[|"find";"12"|];[|"insert";"17"|];[|"insert";"25"|];[|"find";"16"|];[|"print"|]|]
solve N Aa
"""
yes
no
1 12 17 20 25 30 88
30 12 1 20 17 25 88
"""
