#r "nuget: FsUnit"
open FsUnit

(*
let N,K = 10,1
*)
let solve N K =
  let rec mysum acc n = if n=0 then acc else mysum (acc+n%10) (n/10)
  Array2D.create 32 300001 0
  |> fun dp ->
    for i in 1..N do dp.[0,i] <- i - mysum 0 i
    for d in 1..29 do for i in 1..N do dp.[d,i] <- dp.[d-1,dp.[d-1,i]]
    [|1..N|] |> Array.map (fun i ->
      let mutable cnum = i
      for d in 29..(-1)..0 do if ((K/(1<<<d))%2<>0) then cnum <- dp.[d,cnum]
      cnum)

let N,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
solve N K |> Array.iter stdout.WriteLine

solve 10 1 |> should equal [|0;0;0;0;0;0;0;0;0;9|]
