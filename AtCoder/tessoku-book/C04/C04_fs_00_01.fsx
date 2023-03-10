#r "nuget: FsUnit"
open FsUnit

(*
let N = 12L
let N = 827847039317L
*)
let solve N =
  let sqrtN = N+1L |> float |> sqrt |> int64
  [|1L..sqrtN|] |> Array.filter (fun x -> N%x=0L)
  |> Array.collect (fun x -> [|x;N/x|]) |> Array.distinct |> Array.sort

let N = stdin.ReadLine() |> int64
solve N |> Array.iter stdout.WriteLine

solve 12L |> should equal [|1L;2L;3L;4L;6L;12L|]
solve 827847039317L |> should equal [|1L;909859L;909863L;827847039317L|]
