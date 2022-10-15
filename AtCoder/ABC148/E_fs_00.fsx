#r "nuget: FsUnit"
open FsUnit

let N = 12L
let solve N =
  if N%2L=1L then 0L
  else let rec frec acc denom = if N<denom then acc else frec (acc + N/denom) (denom*5L) in frec 0L 10L

let N = stdin.ReadLine() |> int64
solve N |> stdout.WriteLine

solve 12L |> should equal 1L
solve 5L |> should equal 0L
solve 1000000000000000000L |> should equal 124999999999999995L
