#r "nuget: FsUnit"
open FsUnit

let solve x = [|x/(60*60);(x % (60*60))/60; x % 60|]

let S = stdin.ReadLine() |> int
solve S |> String.concat ":" |> stdout.WriteLine

solve 46979 |> should equal [|13;2;59|]
solve 46979 |> Array.map string |> String.concat ":" |> should equal "13:2:59"
