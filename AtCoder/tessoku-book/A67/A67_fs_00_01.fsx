#r "nuget: FsUnit"
open FsUnit

(*
let N,M,Ia = 7,9,[|(1,2,12);(1,3,10);(2,6,160);(2,7,15);(3,4,1);(3,5,4);(4,5,3);(4,6,120);(6,7,14)|]
*)
type UnionFind = { par: int[]; size: int[]}
let solve N M Ia =
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

  Ia |> Array.sortBy (fun (_,_,c) -> c)
  |> Array.sumBy (fun (a,b,c) -> if unite (a-1) (b-1) then c else 0)

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = Array.init M (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1],x.[2])
solve N M Ia |> stdout.WriteLine

solve 7 9 [|(1,2,12);(1,3,10);(2,6,160);(2,7,15);(3,4,1);(3,5,4);(4,5,3);(4,6,120);(6,7,14)|] |> should equal 55
