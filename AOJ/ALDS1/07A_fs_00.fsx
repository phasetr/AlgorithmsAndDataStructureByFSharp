#r "nuget: FsUnit"
open FsUnit

type node = {p: int option; cs: int[]}
let solve N (Xa:array<array<int>>) =
  let mutable tree = Array.create N {p = None; cs = Array.empty}
  for x in Xa do
    let id,rs = x.[0],x.[2..]
    tree.[x.[0]] <- let n = tree.[id] in {n with cs=rs}
    rs |> Array.iter (fun r -> let n = tree.[r] in tree.[r] <- {n with p = Some id})
  done
  tree
let printTree tree =
  let stringOfList ls = let s = Array.map string ls |> String.concat ", " in $"[{s}]"
  let infOfParent n =
    match n.p with
      | None -> (-1)
      | Some x -> x
  let typeOfNode = function
    | {p = None} -> "root"
    | {cs = [||]} -> "leaf"
    | _ -> "internal node"
  let lengthOfNode tr n =
    let rec iter d = function
      | {p = Some x} -> iter (d+1) (Array.get tr x)
      | _ -> d
    iter 0 n
  Array.iteri (fun i x ->
               let pi = infOfParent x in
               let sl = stringOfList x.cs in
               let tn = typeOfNode x in
               let ln = lengthOfNode tree x in
               printf "node %d: parent = %d, depth = %d, %s, %s\n" i pi ln tn sl) tree

let N = stdin.ReadLine() |> int
let Xa = [| for i in 1..N do (stdin.ReadLine().Split |> Array.map int) |]
solve N Xa |> printTree

solve 4 [|[|1;3;3;2;0|];[|0;0|];[|3;0|];[|2;0|]|] |> should equal [|{ p = Some 1; cs = [||] }; { p = None; cs = [|3; 2; 0|] }; { p = Some 1; cs = [||] }; { p = Some 1; cs = [||] }|]
solve 13 [|[|0;3;1;4;10|];[|1;2;2;3|];[|2;0|];[|3;0|];[|4;3;5;6;7|];[|5;0|];[|6;0|];[|7;2;8;9|];[|8;0|];[|9;0|];[|10;2;11;12|];[|11;0|];[|12;0|]|]
