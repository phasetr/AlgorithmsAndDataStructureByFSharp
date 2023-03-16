#r "nuget: FsUnit"
open FsUnit

(*
let N,K,Ia = 5,0,[|(0,4);(1,2);(3,7);(5,9);(7,8)|]
let N,K,Ia = 9,1000,[|(0,1000);(1000,2000);(2000,3000);(3000,4000);(4000,5000);(5000,6000);(6000,7000);(7000,8000);(8000,9000)|]
*)
let solveWA N K Ia =
  let T = 200_000
  let mutable Ja = Ia |> Array.map (fun (l,r) -> (l,r+K))
  let cntL =
    let cntL = Array.create T 0
    let mutable now = 0
    Ja <- Ja |> Array.sortBy snd
    Ja |> Array.iter (fun (l,r) -> if now<=l then cntL.[r] <- cntL.[now]+1 ; now <- r)
    for i in 0..(T-2) do cntL.[i+1] <- max (cntL.[i+1]) (cntL.[i])
    cntL
  let cntR =
    let cntR = Array.create T 0
    let mutable now = T-1
    Ja |> Array.sortByDescending fst
    |> Array.iter (fun (l,r) -> if now>=r then cntR.[l] <- cntR.[now]+1 ; now <- l)
    for i in (T-2)..(-1)..0 do cntR.[i] <- max (cntR.[i]) (cntR.[i+1])
    cntR
  Ia |> Array.map (fun (l,r) -> cntL.[l]+1+cntR.[r])

let solve N K Ia =
  let m = 86400
  let X = Array.create (m+1) 0
  let mutable G = (Array.init (m+1) (fun _ -> ResizeArray<int>()), Ia) ||> Array.fold (fun G (l,r) -> G.[r].Add(l); G)
  let mutable t = -1
  for i in 1..m do
    X.[i] <- X.[i-1]
    for l in G.[i] do t <- max t (max (l-K) 0)
    if t>=0 then X.[i] <- max X.[i] (X.[t]+1)

  let Y = Array.create (m+1) 0
  G <- (Array.init (m+1) (fun _ -> ResizeArray<int>()), Ia) ||> Array.fold (fun G (l,r) -> G.[l].Add(r); G)
  t <- m+1
  for i in (m-1)..(-1)..0 do
    Y.[i] <- Y.[i+1]
    for r in G.[i] do t <- min t (min (r+K) m)
    if t<=m then Y.[i] <- max Y.[i] (Y.[t]+1)

  Ia |> Array.map (fun (l,r) -> X.[max (l-K) 0] + 1 + Y.[min (r+K) m])

let N = stdin.ReadLine() |> int
let K = stdin.ReadLine() |> int
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N K Ia |> Array.iter stdout.WriteLine

solve 5 0 [|(0,4);(1,2);(3,7);(5,9);(7,8)|] |> should equal [|2;3;3;2;3|]
solve 9 1000 [|(0,1000);(1000,2000);(2000,3000);(3000,4000);(4000,5000);(5000,6000);(6000,7000);(7000,8000);(8000,9000)|] |> should equal [|5;4;5;4;5;4;5;4;5|]
