#r "nuget: FsUnit"
open FsUnit

(*
let N = 10L
let N = 30L
let N = 100000000000L
*)
let solve N = N/3L + N/5L - N/15L

let N = stdin.ReadLine() |> int64
solve N |> stdout.WriteLine

solve 10L |> should equal 5L
solve 30L |> should equal 14L
solve 100000000000L |> should equal 46666666667L
