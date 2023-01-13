#r "nuget: FsUnit"
open FsUnit

(*
let N = 100
*)
open System
let solve N Aa =
  let Q = 1000
  let Ranq (r:Random) = [|r.Next(N);r.Next(N);r.Next(N)+1|]
  let Init r = Array.init Q (fun _ -> Ranq(r))
  let rec GetNext (r:Random) cur min max dmin dmax =
    let next = cur + r.Next(dmin,dmax)
    if min<=next && next<=max then next else GetNext r cur min max dmin dmax
  let Move (r:Random) (a:int[][]) (b:int[][]) (prev:int[]) =
    [|GetNext r prev.[0] 0 99 -3 4; GetNext r prev.[1] 0 99 -3 4; GetNext r prev.[2] 1 100 -5 6|]
  let Calc (a:int[][]) (ans:int[][]) =
    let n = a.Length
    let mutable sum = 200_000_000
    let b = Array.init n (fun i -> a.[i])
    for i in 0..b.Length-1 do
      for j in 0..b.Length-1 do
        for k in 0..ans.Length-1 do
          b.[i].[j] <- b.[i].[j] + max 0 (ans.[k].[2] - abs(i - ans.[k].[1]) - abs(j - ans.[k].[0]))
        sum <- sum - abs(a.[i].[j] - b.[i].[j])
    (sum, b)
  let Diff (a:int[][]) (pb:int[][]) (pq:int[]) (nq:int[]) =
    let mutable sum = 200_000_000
    let b = Array.init pb.Length (fun i -> Array.copy pb.[i])
    for i in 0..b.Length-1 do
      for j in 0..b.[i].Length-1 do
        b.[i].[j] <- b.[i].[j] - max 0 (pq.[2] - abs(i-pq.[1] - abs(j-pq.[0])))
        b.[i].[j] <- b.[i].[j] + max 0 (nq.[2] - abs(i-nq.[1] - abs(j-nq.[0])))
        sum <- sum - abs(a.[i].[j] - b.[i].[j])
    (sum,b)

  let r = System.Random()
  let startDateTime = System.DateTime.Now
  let ans = Init r
  let mutable sc = Calc Aa ans
  let mutable count = 0
  while ((DateTime.Now - startDateTime).TotalSeconds < 5.7) do
    for i in 0..N-1 do
      let pos = r.Next(1000);
      let pq = ans.[pos];
      let nq = Move r Aa (snd sc) pq
      let ns = Diff Aa (snd sc) pq nq
      if fst sc < fst ns then sc <- ns; ans.[pos] <- nq
      count <- count+1
  stdout.WriteLine ans.Length
  ans |> Array.iter (Array.map string >> String.concat " " >> stdout.WriteLine)

let N = 100
let Aa = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int)
solve N Aa
