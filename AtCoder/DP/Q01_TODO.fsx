#r "nuget: FsUnit"
open FsUnit

"TODO"
let N,Ha,Aa = 4,[|3;1;4;2|],[|10L;20L;30L;40L|]
let solve N Ha Aa = 1

let N = stdin.ReadLine() |> int
let Ha = stdin.ReadLine().Split() |> Array.map int
let Aa = stdin.ReadLine().Split() |> Array.map int64
solve N Ha Aa |> stdout.WriteLine

solve 4 [|3;1;4;2|] [|10L;20L;30L;40L|] |> should equal 60
solve 1 [|1|] [|10L|] |> should equal 10
solve 5 [|1;2;3;4;5|] [|1000000000L;1000000000L;1000000000L;1000000000L;1000000000L|] |> should equal 5000000000L
solve 9 [|4;2;5;8;3;6;1;7;9|] [|6L;8L;8L;4L;6L;3L;5L;7L;5|] |> should equal 31
