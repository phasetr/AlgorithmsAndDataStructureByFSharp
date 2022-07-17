#r "nuget: FsUnit"
open FsUnit

let solve aa = Array.rev aa

let n = stdin.ReadLine() |> int
let aa = stdin.ReadLine().Split() |> Array.map int
solve aa |> Array.map string |> String.concat " " |> stdout.WriteLine

solve [|1;2;3;4;5|] |> should equal [|5;4;3;2;1|]
solve [|3;3;4;4;5;8;7;9|] |> should equal [|9;7;8;5;4;4;3;3|]
