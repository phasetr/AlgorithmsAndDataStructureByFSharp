#r "nuget: FsUnit"
open FsUnit

(*
let N,W,L,R,Xa = 5,65,7,37,[|5;15;30;50;55|]
*)
let solve N W L R Xa =
  let MOD = 1_000_000_007L
  let Ya = [|[|0|];Xa;[|W|]|] |> Array.concat
  let rec bl i j0 j = if Ya.[i]-R <= Ya.[j] then j elif j=N+1 then j0 else bl i j0 (j+1)
  let rec br i j0 j = if Ya.[i]-L <  Ya.[j] then j elif j=N+1 then j0 else br i j0 (j+1)
  (Array.create (N+2) 0L, Array.create (N+2) 0L)
  |> fun (dp,cdp) ->
    dp.[0]<-1L; cdp.[0]<-1L
    ((dp,cdp,0,0), [|1..N+1|]) ||> Array.fold (fun (dp,cdp,pl0,pr0) i ->
      let pl = bl i pl0 pl0
      let cdpl = if 0<pl then cdp.[pl-1] else 0L
      let pr = br i pr0 pr0
      let cdpr = if 0<pr then cdp.[pr-1] else 0L
      dp.[i] <- (cdpr-cdpl+MOD)%MOD
      cdp.[i] <- (cdp.[i-1]+dp.[i])%MOD
      (dp,cdp,pl,pr))
  |> fun (dp,_,_,_) -> dp.[N+1]

let N,W,L,R = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1],x.[2],x.[3])
let Xa = stdin.ReadLine().Split() |> Array.map int
solve N W L R Xa |> stdout.WriteLine

solve 5 65 7 37 [|5;15;30;50;55|] |> should equal 7
