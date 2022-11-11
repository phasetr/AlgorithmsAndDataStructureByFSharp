#r "nuget: FsUnit"
open FsUnit
open System.Collections.Generic

let N = 6L
open System.Collections.Generic
let solve N =
  let MOD = 1_000_000_007L
  let rec g (i:int64) (k:int64) =
    let (q,r) = System.Math.DivRem(k,i)
    if k=1L then []
    else if r=0L then i::g i q
    else if i*i>k then [k]
    else g (i+1L) k
  let insertWith f k v (d:Dictionary<int64,int64>) =
    d.TryGetValue(k) |> function | true,n -> d.[k] <- f d.[k] v; d | false,_ -> d.Add(k, v); d
  let f k m = List.foldBack (fun i -> insertWith (+) i 1L) (g 2L k) m
  (1L, List.foldBack f [2L..N] (Dictionary<int64,int64>()))
  ||> Seq.fold (fun acc (kv:KeyValuePair<int64,int64>) -> acc * (kv.Value+1L) % MOD)

let N = stdin.ReadLine() |> int64
solve N |> stdout.WriteLine

solve 3L |> should equal 4L
solve 6L |> should equal 30L
solve 1000L |> should equal 972926972L
