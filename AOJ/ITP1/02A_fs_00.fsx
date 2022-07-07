#r "nuget: FsUnit"
open FsUnit

let solve a b = if a<b then "a < b" else if a>b then "a > b" else "a == b"
let a,b = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
solve a b |> stdout.WriteLine

solve 1 2 |> should equal "a < b"
solve 4 3 |> should equal "a > b"
solve 5 5 |> should equal "a == b"
