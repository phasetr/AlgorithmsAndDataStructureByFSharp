#r "nuget: FsUnit"
open FsUnit

let solve a b c = [|a..b|] |> Array.filter (fun x -> 80 % x = 0) |> Array.length

let a,b,c = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1],x.[2])
solve a b c |> stdout.WriteLine

solve 5 14 80 |> should equal 3
