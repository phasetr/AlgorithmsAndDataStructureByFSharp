#r "nuget: FsUnit"
open FsUnit

let solve Aa ba = Aa |> Array.map (fun aa -> Array.map2 (*) aa ba |> Array.sum)

let N = stdin.ReadLine() |> int
let M = stdin.ReadLine() |> int
let Aa = [| for i in 1..N do (stdin.ReadLine().Split() |> Array.map int) |]
let ba = [| for i in 1..m do (stdin.ReadLine() |> int) |]
solve Aa ba |> Array.iter stdout.WriteLine

solve [|[|1;2;0;1|];[|0;3;0;1|];[|4;1;1;0|]|] [|1;2;3;0|] |> should equal [|5;6;9|]
