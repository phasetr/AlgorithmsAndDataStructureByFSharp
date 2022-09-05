#r "nuget: FsUnit"
open FsUnit

let solve N Aa =
  let nil = -1

  let treeInfo N (Aa:int[][]) =
    let mutable pma = Array.create N nil
    let mutable tma = Array.create N (nil,nil)
    Aa |> Array.iter (fun x ->
      let (i,l,r) = x.[0],x.[1],x.[2]
      tma.[i] <- (l,r)
      if l <> nil then pma.[l] <- i
      if r <> nil then pma.[r] <- i)
    (pma |> Array.findIndex ((=) nil), tma)

  let rec preOrder n (tv:(int*int)[]) =
    if n=nil then [] else let (l,r) = tv.[n] in [n] @ preOrder l tv @ preOrder r tv
  let rec inOrder n (tv:(int*int)[]) =
    if n=nil then [] else let (l,r) = tv.[n] in inOrder l tv @ [n] @ inOrder r tv
  let rec postOrder n (tv:(int*int)[]) =
    if n=nil then [] else let (l,r) = tv.[n] in postOrder l tv @ postOrder r tv @ [n]

  let (root, tv) = treeInfo N Aa in [| preOrder root tv; inOrder root tv; postOrder root tv |]

let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..N do (stdin.ReadLine().Split |> Array.map int) |]
let orders = solve N Aa
stdout.WriteLine "Preorder"
orders.[0] |> List.map string |> String.concat " " |> fun s -> $" {s}" |> stdout.WriteLine
stdout.WriteLine "Inorder"
orders.[1] |> List.map string |> String.concat " " |> fun s -> $" {s}" |> stdout.WriteLine
stdout.WriteLine "Postorder"
orders.[2] |> List.map string |> String.concat " " |> fun s -> $" {s}" |> stdout.WriteLine

let N,Aa = 9,[|[|0;1;4|];[|1;2;3|];[|2;-1;-1|];[|3;-1;-1|];[|4;5;8|];[|5;6;7|];[|6;-1;-1|];[|7;-1;-1|];[|8;-1;-1|];|]
solve N Aa |> should equal [|[0;1;2;3;4;5;6;7;8];[2;1;3;0;6;5;7;4;8];[2;3;1;6;7;5;8;4;0]|]
