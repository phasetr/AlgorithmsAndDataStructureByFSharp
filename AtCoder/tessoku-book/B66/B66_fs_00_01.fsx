#r "nuget: FsUnit"
open FsUnit

(*
let N,M,Ia,Q,Qa = 3,2,[|(1,2);(2,3)|],4,[|[|2;2;3|];[|1;2|];[|2;1;3|];[|1;1|]|]
let N,M,Ia,Q,Qa = 12,7,[|(8,11);(1,7);(10,12);(1,4);(4,8);(5,9);(3,5)|],12,[|[|2;6;8|];[|1;6|];[|2;10;12|];[|1;1|];[|1;5|];[|1;3|];[|2;3;5|];[|1;7|];[|2;3;6|];[|1;4|];[|1;2|];[|2;9;11|]|]
let N,M,Ia,Q,Qa = 4,3,[|(1,2);(2,3);(3,4)|],7,[|[|2;1;2|];[|2;1;3|];[|2;1;4|];[|1;2|];[|2;1;2|];[|2;1;3|];[|2;1;4|]|]
*)
type UnionFind = { par: int[]; size: int[]}
let solve N M (Ia:(int*int)[]) Q (Qa:int[][]) =
  let uf = { par = Array.init (N+1) id; size = Array.create (N+1) 1 }
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

  let set =
    let s = System.Collections.Generic.HashSet<int>()
    for i in 1..N do s.Add(i) |> ignore
    for q in Qa do if q.[0] = 1 then s.Remove(q.[1]) |> ignore
    for i in 1..M do if s.Contains(i) then (unite (fst Ia.[i-1]) (snd Ia.[i-1]) |> ignore)
    s
  ([], Array.rev Qa) ||> Array.fold (fun acc qa ->
    if qa.[0]=1 then let x = qa.[1] in unite (fst Ia.[x-1]) (snd Ia.[x-1]); acc
    else (if find (qa.[1]) (qa.[2]) then "Yes" else "No")::acc)

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = Array.init M (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
let Q = stdin.ReadLine() |> int
let Qa = Array.init Q (fun _ -> stdin.ReadLine().Split() |> Array.map int)
solve N M Ia Q Qa |> List.iter stdout.WriteLine

solve 3 2 [|(1,2);(2,3)|] 4 [|[|2;2;3|];[|1;2|];[|2;1;3|];[|1;1|]|] |> should equal ["Yes";"No"]
solve 12 7 [|(8,11);(1,7);(10,12);(1,4);(4,8);(5,9);(3,5)|] 12 [|[|2;6;8|];[|1;6|];[|2;10;12|];[|1;1|];[|1;5|];[|1;3|];[|2;3;5|];[|1;7|];[|2;3;6|];[|1;4|];[|1;2|];[|2;9;11|]|] |> should equal ["No";"Yes";"Yes";"No";"No"]
solve 4 3 [|(1,2);(2,3);(3,4)|] 7 [|[|2;1;2|];[|2;1;3|];[|2;1;4|];[|1;2|];[|2;1;2|];[|2;1;3|];[|2;1;4|]|] |> should equal ["Yes";"Yes";"Yes";"Yes";"No";"No"]
