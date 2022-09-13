#r "nuget: FsUnit"
open FsUnit

let solve N (Pa: float[]) (Qa: float[]) =
  let mutable memo = Array2D.create 500 500 -9.9
  let mutable memo2 = Array2D.create 500 500 -9.9

  let pqsum ib ie =
    if memo2.[ib,ie] >= 0.0 then memo2.[ib,ie]
    else let s = (Array.sum Pa.[ib..ie]) + (Array.sum Qa.[ib..(ie+1)]) in (memo2.[ib,ie] <- s; s)
  let rec min_cost1 ib ie it =
    if ib = ie then Qa.[ib] + Qa.[ib+1]
    else if ie = it then Qa.[it+1] + min_cost ib (ie-1)
    else if ib = it then Qa.[it]   + min_cost (ib+1) ie
    else min_cost ib (it-1) + min_cost (it+1) ie
  and min_cost ib ie =
    if memo.[ib,ie] >= 0.0 then memo.[ib,ie]
    else
      let m = (9.9,[|ib..ie|]) ||> Array.fold (fun acc it -> min acc (min_cost1 ib ie it + pqsum ib ie))
      memo.[ib,ie] <- m; m

  min_cost 0 (N-1)

let N = stdin.ReadLine() |> int
let Pa = stdin.ReadLine().Split() |> Array.map int
let Qa = stdin.ReadLine().Split() |> Array.map int
solve N Pa Qa |> stdout.WriteLine

let near0 x y = (abs (x-y)) < 0.000_1
let N,Pa,Qa = 5,[|0.1500;0.1000;0.0500;0.1000;0.2000|],[|0.0500;0.1000;0.0500;0.0500;0.0500;0.1000|]
near0 (solve N Pa Qa) 2.75000000 |> should be True
let N,Pa,Qa = 7,[|0.0400;0.0600;0.0800;0.0200;0.1000;0.1200;0.1400|],[|0.0600;0.0600;0.0600;0.0600;0.0500;0.0500;0.0500;0.0500|]
near0 (solve N Pa Qa) 3.1200 |> should be True
