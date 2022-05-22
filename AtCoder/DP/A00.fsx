#r "nuget: FsUnit"
open FsUnit

let N,Ha = 4,[|10;30;40;20|]
let solve N (Ha:int[]) = 1
let N = stdin.ReadLine() |> int
let Ha = stdin.ReadLine().Split() |> Array.map int
solve N Ha |> stdout.WriteLine

solve 4 [|10;30;40;20|] |> should equal 30
solve 2 [|10;10|] |> should equal 0
solve 6 [|30;10;60;10;60;50|] |> should equal 40
