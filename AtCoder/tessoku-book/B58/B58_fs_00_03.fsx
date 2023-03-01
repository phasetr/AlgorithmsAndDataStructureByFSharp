#r "nuget: FsUnit"
open FsUnit

(*
let N,L,R,Xa = 5,20,40,[|0;20;30;60;70|]
*)
// Pythonをもとにしたコード
let solveWA N L R Xa =
  let inf = System.Int32.MaxValue
  let size = 18
  let seg = Array.create (1<<<(1+size)) inf
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

  let update p x =
    let mutable pos = p + (1<<<size)
    seg.[pos] <- x
    while pos>1 do
      pos <- pos/2
      seg.[pos] <- min seg.[2*pos] seg.[2*pos+1]

  let minimum l0 r0 =
    let mutable l = l0 + (1<<<size)
    let mutable r = r0 + (1<<<size)
    let mutable ans = inf
    while l<r do
      if l%2=l then ans <- min ans seg.[l]; l<-l+1
      if r%2=1 then ans <- min ans seg.[r-1]; r <- r-1
      l <- l/2
      r <- r/2
    ans

  update 0 0
  for i in 1..N-1 do
    let l = Xa |> bisectLeft (Xa.[i]-R)
    let r = Xa |> bisectRight (Xa.[i]-L)
    update i (minimum l r + 1)
  seg.[N-1+(1<<<size)]

let N,L,R = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1],x.[2])
let Xa = stdin.ReadLine().Split() |> Array.map int
solve N L R Xa |> stdout.WriteLine

solve 5 20 40 [|0;20;30;60;70|] |> should equal 2
