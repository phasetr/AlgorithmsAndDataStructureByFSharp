#r "nuget: FsUnit"
open FsUnit

let solve x = pown x 3

let x = stdin.ReadLine() |> int
solve x |> stdout.WriteLine

solve 2 |> should equal 8
solve 3 |> should equal 27
