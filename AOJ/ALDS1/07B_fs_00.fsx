#r "nuget: FsUnit"
open FsUnit

type node = {mutable parent:int; mutable left:int; mutable right:int; mutable height:int; mutable depth: int}
let solve N (Aa:int[][]) =
  let nil = -1
  let tree = Array.init 25 (fun x -> { parent=nil; left=nil; right=nil; height=0; depth=0 })

  let rec setHeight u =
    let h1 = if tree.[u].right <> nil then setHeight tree.[u].right + 1 else 0
    let h2 = if tree.[u].left <> nil then setHeight tree.[u].left + 1 else 0
    let hmax = if h1 < h2 then h2 else h1
    tree.[u].height <- hmax; hmax

  let rec setDepth u d =
    if u <> nil then
      tree.[u].depth <- d
      setDepth tree.[u].left (d+1)
      setDepth tree.[u].right (d+1)

  let rec getRoot = function
    | -1 -> nil
    | i -> if tree.[i].parent = nil then i else getRoot (i-1)

  let getSibling u =
    if tree.[u].parent = nil then nil
    else if tree.[tree.[u].parent].left  <> u && tree.[tree.[u].parent].left  <> nil then tree.[tree.[u].parent].left
    else if tree.[tree.[u].parent].right <> u && tree.[tree.[u].parent].right <> nil then tree.[tree.[u].parent].right
    else nil

  Aa |> Array.iter (fun l ->
    tree.[l.[0]].left <- l.[1]
    tree.[l.[0]].right <- l.[2]
    if l.[1] <> nil then tree.[l.[1]].parent <- l.[0]
    if l.[2] <> nil then tree.[l.[2]].parent <- l.[0]
    )

  let root = getRoot (N-1)
  setDepth root 0;
  setHeight root |> ignore

  [|0..N-1|]
  |> Array.map (fun u ->
    let ldeg = if tree.[u].left  <> nil then 1 else 0
    let rdeg = if tree.[u].right <> nil then 1 else 0
    let nodeType =
        if tree.[u].parent = nil then "root"
        else if tree.[u].left = nil && tree.[u].right = nil then "leaf"
        else "internal node"
    (u, tree.[u].parent, getSibling u, ldeg+rdeg, tree.[u].depth, tree.[u].height, nodeType))

let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..N do (stdin.ReadLine().Split() |> Array.map int) |]
let nodeToStr (u,p,s,deg,dep,h,t) = $"node {u}: parent = {p}, sibling = {s}, degree = {deg}, depth = {dep}, height = {h}, {t}"
solve N Aa |> Array.iter (nodeToStr >> stdout.WriteLine)

let N,Aa = 9,[|[|0;1;4|];[|1;2;3|];[|2;-1;-1|];[|3;-1;-1|];[|4;5;8|];[|5;6;7|];[|6;-1;-1|];[|7;-1;-1|];[|8;-1;-1|]|]
solve N Aa |> should equal [|(0,-1,-1,2,0,3,"root");(1,0,4,2,1,1,"internalnode");(2,1,3,0,2,0,"leaf");(3,1,2,0,2,0,"leaf");(4,0,1,2,1,2,"internalnode");(5,4,8,2,2,1,"internalnode");(6,5,7,0,3,0,"leaf");(7,5,6,0,3,0,"leaf");(8,4,5,0,2,0,"leaf")|]
