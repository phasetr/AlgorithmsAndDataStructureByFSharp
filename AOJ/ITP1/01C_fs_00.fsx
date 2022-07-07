#r "nuget: FsUnit"
open FsUnit

let solve a b = [|a*b; 2*(a+b)|]
let a,b = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
solve a b |> Array.map stdin |> String.concat " " |> stdout.WriteLine

solve 3 5 |> should equal [|15;16|]
