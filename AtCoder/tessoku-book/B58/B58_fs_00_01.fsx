#r "nuget: FsUnit"
open FsUnit

(*
let N,L,R,Xa = 5,20,40,[|0;20;30;60;70|]
*)
let solve N L R (Xa:int[]) =
  let size =
    let mutable size = 1
    while size<N do size <- size*2
    size
  let update position x (dat:int[]) =
    let mutable pos = position + size - 1
    dat.[pos] <- x
    while pos>=2 do
      pos <- pos/2
      dat.[pos] <- min dat.[pos*2] dat.[pos*2+1]
  let rec query l r a b u (dat:int[]) =
    if r<=a || b<=l then 1000000000
    elif l<=a && b<=r then dat.[u]
    else
      let m = (a+b)/2
      let al = query l r a m (u*2) dat
      let ar = query l r m b (u*2+1) dat
      min al ar
  let lowerBound x (Xa:int[]) =
    let mutable l = 0
    let mutable r = N-1
    while l<=r do let c = (l+r)/2 in if Xa.[c]<x then l <- c+1 else r <- c-1
    l

  Array.create (N+1) 0
  |> fun dp ->
    let dat = Array.create (1+size*2) 0
    update 1 0 dat
    for i in 2..N do
      let posL = 1 + lowerBound (Xa.[i-1]-R) Xa
      let posR = lowerBound (Xa.[i-1]-L+1) Xa
      dp.[i] <- 1 + (query posL (posR+1) 1 (size+1) 1 dat)
      update i dp.[i] dat
    dp.[N]

let N,L,R = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1],x.[2])
let Xa = stdin.ReadLine().Split() |> Array.map int
solve N L R Xa |> stdout.WriteLine

solve 5 20 40 [|0;20;30;60;70|] |> should equal 2
