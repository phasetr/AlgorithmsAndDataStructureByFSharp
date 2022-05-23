#r "nuget: FsUnit"
open FsUnit

let N,M,Aa = 3,100,[|(1,2);(2,3)|]
"TODO cf. V04.py, P01.fsx"
let solve N,M,Aa = 1

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Aa = [| for i in 1..(N-1) do (stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1]) |]
solve N M Aa |> Array.map stdout.WriteLine

solve 3 100 [|(1,2);(2,3)|] |> should equal [|3;4;3|]
solve 4 100 [|(1,2);(1,3);(1,4)|] |> should equal [|8;5;5;5|]
solve 1 100 [||] |> should equal [|1|]
solve 10 2 [||] [|(8,5);(10,8);(6,5);(1,5);(4,8);(2,10);(3,6);(9,2);(1,7)|] |> should equal [|0;0;1;1;1;0;1;0;1;1|]
