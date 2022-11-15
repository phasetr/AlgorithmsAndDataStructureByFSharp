#r "nuget: FsUnit"
open FsUnit

let S = 3L
let solve (S:int64) =
  let K = 1_000_000_000L
  let x = (K - (S%K))%K
  let y = (S+x)/K
  sprintf "0 0 1000000000 1 %d %d" x y
let S = stdin.ReadLine() |> int64
solve S |> stdout.WriteLine

solve 3L
solve 100L
solve 311114770564041497L
