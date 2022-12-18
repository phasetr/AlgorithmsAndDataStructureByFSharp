#r "nuget: FsUnit"
open FsUnit
(*
let N,M,K,Xa,Ya = 4,4,1,[|(2,1);(1,3);(3,2);(3,4)|],[|(4,1)|]
let N,M,K,Xa,Ya = 5,10,0,[|(1,2);(1,3);(1,4);(1,5);(3,2);(2,4);(2,5);(4,3);(5,3);(4,5)|],[||]
let N,M,K,Xa,Ya = 10,9,3,[|(10,1);(6,7);(8,2);(2,5);(8,4);(7,3);(10,9);(6,4);(5,8)|],[|(2,6);(7,5);(3,1)|]
*)

type UnionFind = { par: int[]; size: int[]}
let solve N M K Xa Ya =
  let uf = { par = Array.init N id; size = Array.create N 1 }

  let rec root x =
    if uf.par.[x] = x then x
    else let r = root uf.par.[x] in uf.par.[x] <- r; r
  let find x y = root x = root y
  let unite x y =
    let rx,ry = root x, root y
    if rx=ry then false
    else
      let large,small = if uf.size.[rx]<uf.size.[ry] then ry,rx else rx,ry
      uf.par.[small] <- large
      uf.size.[large] <- uf.size.[large]+uf.size.[small]
      uf.size.[small] <- 0
      true
  let size x = let rx = root x in uf.size.[rx]

  let Fa = Array.init N (fun _ -> ResizeArray<int>())
  Xa |> Array.iter (fun (a0,b0) ->
    let a,b = a0-1,b0-1
    Fa.[a].Add(b); Fa.[b].Add(a); unite a b |> ignore)
  let Ba = Array.init N (fun _ -> ResizeArray<int>())
  Ya |> Array.iter (fun (c0,d0) ->
    let c,d = c0-1,d0-1
    Ba.[c].Add(d); Ba.[d].Add(c))

  [|0..N-1|]
  |> Array.map (fun i ->
    let blocks = Ba.[i].ToArray() |> Array.sumBy (fun b -> if find i b then 1 else 0)
    size i - Fa.[i].Count - blocks - 1)

let N,M,K = stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1],x.[2]
let Xa = Array.init M (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
let Ya = Array.init K (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N M K Xa Ya |> Array.map string |> String.concat " " |> stdout.WriteLine

solve 4 4 1 [|(2,1);(1,3);(3,2);(3,4)|] [|(4,1)|] |> should equal [|0;1;0;1|]
solve 5 10 0 [|(1,2);(1,3);(1,4);(1,5);(3,2);(2,4);(2,5);(4,3);(5,3);(4,5)|] [||] |> should equal [|0;0;0;0;0|]
solve 10 9 3 [|(10,1);(6,7);(8,2);(2,5);(8,4);(7,3);(10,9);(6,4);(5,8)|] [|(2,6);(7,5);(3,1)|] |> should equal [|1;3;5;4;3;3;3;3;1;0|]
