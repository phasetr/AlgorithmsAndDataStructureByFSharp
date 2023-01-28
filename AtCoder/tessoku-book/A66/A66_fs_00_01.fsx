#r "nuget: FsUnit"
open FsUnit

(*
let N,Q,Qa = 3,4,[|(1,1,2);(2,1,3);(1,2,3);(2,2,3)|]
let N,Q,Qa = 12,12,[|(2,9,11);(1,1,7);(1,1,4);(2,3,6);(1,3,5);(2,3,5);(1,10,12);(1,4,8);(1,8,11);(2,10,12);(1,5,9);(2,6,8)|]
*)
type UnionFind = { par: int[]; size: int[]}
let solve N Q Qa =
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

  ([],Qa) ||> Array.fold (fun acc (t,u,v) ->
    if t=1 then unite (u-1) (v-1) |> ignore; acc
    else let s = if find (u-1) (v-1) then "Yes" else "No" in s::acc)
  |> List.rev

let N,Q = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Qa = Array.init Q (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1],x.[2])
solve N Q Qa |> List.iter stdout.WriteLine

solve 3 4 [|(1,1,2);(2,1,3);(1,2,3);(2,2,3)|] |> should equal ["No";"Yes"]
solve 12 12 [|(2,9,11);(1,1,7);(1,1,4);(2,3,6);(1,3,5);(2,3,5);(1,10,12);(1,4,8);(1,8,11);(2,10,12);(1,5,9);(2,6,8)|] |> should equal ["No";"No";"Yes";"Yes";"No"]
