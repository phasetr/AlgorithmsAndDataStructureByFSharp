#r "nuget: FsUnit"
open FsUnit

let solve a b c = if a < b && b < c then "Yes" else "No"

let a,b,c = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1],x.[2])
solve a b c |> stdout.WriteLine

solve 1 3 8 |> should equal "Yes"
solve 3 8 1 |> should equal "No"
