#r "nuget: FsUnit"
open FsUnit

let solve N = N*N
let N = stdin.ReadLine() |> int
solve N |> stdout.WriteLine

solve 2 |> should equal 4
solve 8 |> should equal 64
solve 100 |> should equal 10000
