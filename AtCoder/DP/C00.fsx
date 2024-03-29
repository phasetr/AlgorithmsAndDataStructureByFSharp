#r "nuget: FsUnit"
open FsUnit

let N,Ha = 3,[|[|10;40;70|];[|20;50;80|];[|30;60;90|]|]
let solve N Ha = 1
let N = stdin.ReadLine() |> int
let Ha = [| for i in 1..N do (stdin.ReadLine().Split() |> Array.map int) |]
solve N Ha |> stdout.WriteLine

solve 3 [|[|10;40;70|];[|20;50;80|];[|30;60;90|]|] |> should equal 210
solve 1 [|[|100;10;1|]|] |> should equal 100
solve 7 [|[|6;7;8|];[|8;8;3|];[|2;5;2|];[|7;8;6|];[|4;6;8|];[|2;3;4|];[|7;5;1|]|] |> should equal 46
