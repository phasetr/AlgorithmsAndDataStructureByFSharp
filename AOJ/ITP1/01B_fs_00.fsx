#r "nuget: FsUnit"
open FsUnit

let solve n = pown n 3

let n = stdin.ReadLine() |> int
solve n |> stdout.WriteLine

solve 2 |> should equal 8
solve 3 |> should equal 27
