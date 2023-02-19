#r "nuget: FsUnit"
open FsUnit

(*
let N = 10L
let N = 210L
let N = 100000000000L
*)
let solve N = N/3L+N/5L+N/7L-N/15L-N/21L-N/35L+N/105L
let N = stdin.ReadLine() |> int64
solve N |> stdout.WriteLine

solve 10L |> should equal 6L
solve 210L |> should equal 114L
solve 100000000000L |> should equal 54285714286L
