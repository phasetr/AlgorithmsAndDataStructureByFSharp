#r "nuget: FsUnit"
open FsUnit

(*
let N,L,R,Xa = 5,20,40,[|0;20;30;60;70|]
*)
// 本のC++をもとにした
let solveWA N L R Xa =
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
  let bisectLeft x (Xa:'a[]) =
    let rec bsearch l r =
      if r<=l then l
      else let m = l+(r-l)/2 in if Xa.[m] < x then bsearch (m+1) r else bsearch l m
    Xa |> Array.length |> bsearch 0
  let bisectRight x (Xa:'a[]) =
    let rec bsearch l r =
      if r<=l then l
      else let m = l+(r-l)/2 in if x < Xa.[m] then bsearch l m else bsearch (m+1) r
    Xa |> Array.length |> bsearch 0

  Array.create (N+1) 0
  |> fun dp ->
    let dat = Array.create (1+size*2) 0
    update 1 0 dat
    for i in 2..N do
      let posL = Xa |> bisectLeft (Xa.[i-1]-R)
      let posR = Xa |> bisectRight (Xa.[i-1]-L)
      dp.[i] <- 1 + (query posL (posR+1) 1 (size+1) 1 dat)
      update i dp.[i] dat
    dp.[N]

let N,L,R = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1],x.[2])
let Xa = stdin.ReadLine().Split() |> Array.map int
solve N L R Xa |> stdout.WriteLine

solve 5 20 40 [|0;20;30;60;70|] |> should equal 2
