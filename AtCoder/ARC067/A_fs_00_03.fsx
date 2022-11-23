#r "nuget: FsUnit"
open FsUnit

let N = 6L
let solve N =
  let MOD = 1_000_000_007L
  let rec g (i:int64) (k:int64) =
    let (q,r) = System.Math.DivRem(k,i)
    if k=1L then []
    else if r=0L then i::g i q
    else if i*i>k then [k]
    else g (i+1L) k
  let insertWith f k v m = Map.tryFind k m |> function | Some(v0) -> Map.add k (f v0 v) m | None -> Map.add k v m
  let f k m = List.foldBack (fun i -> insertWith (+) i 1L) (g 2L k) m
  (1L, List.foldBack f [2L..N] Map.empty)
  ||> Map.fold (fun acc _ v -> acc * (v+1L) % MOD)

let N = stdin.ReadLine() |> int64
solve N |> stdout.WriteLine

solve 3L |> should equal 4L
solve 6L |> should equal 30L
solve 1000L |> should equal 972926972L
