#r "nuget: FsUnit"
open FsUnit

type tree = Nil | Node of int * tree * tree
let solve N Aa =
  let insert x t =
    let rec frec = function
      | Nil -> Node(x,Nil,Nil)
      | Node(y,l,r) when x < y -> Node(y,frec l,r)
      | Node(y,l,r) -> Node (y,l,frec r)
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

  (Nil,Aa) ||> Array.fold (fun t a ->
    match a with
      | [|"insert";n|] -> insert (int n) t
      | _ -> print t; t)

let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..N do stdin.ReadLine().Split() |]
solve N Aa |> Array.map string |> String.concat " " |> stdout.WriteLine

let N,Aa = 8,[|[|"insert";"30"|];[|"insert";"88"|];[|"insert";"12"|];[|"insert";"1"|];[|"insert";"20"|];[|"insert";"17"|];[|"insert";"25"|];[|"print"|]|]
solve N Aa
"""
1 12 17 20 25 30 88
30 12 1 20 17 25 88
"""
