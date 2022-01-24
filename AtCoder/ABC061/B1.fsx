@"https://atcoder.jp/contests/abc061/tasks/abc061_b
問題文
N 個の都市があり、M 本の道路があります。
i(1≦i≦M) 番目の道路は、都市 ai と 都市 bi
(1≦ai,bi≦N) を双方向に結んでいます。
同じ 2 つの都市を結ぶ道路は、1 本とは限りません。
各都市から他の都市に向けて、何本の道路が伸びているか求めてください。

制約
2≦N,M≦50
1≦ai,bi≦N
ai/=bi
入力は全て整数である。"
#r "nuget: FsUnit"
open FsUnit

let count acc (a,b) =
    acc
    |> Array.mapi (fun i x -> if i=a-1 || i=b-1 then x+1 else x)
let solve N M inputs =
    inputs |> Array.fold count (Array.create N 0)
let N, M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let inputs = [| for i in 1..M do (stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0], x.[1]) |]
solve N M inputs
|> Array.map string
|> String.concat "\n"
|> printfn "%s"

solve 4 3 [|(1,2); (2,3); (1,4)|] |> should equal [|2;2;1;1|]
solve 2 5 [|(1,2); (2,1); (1,2); (2,1); (1,2)|] |> should equal [|5;5|]
solve 8 8 [|(1,2); (3,4); (1,5); (2,8); (3,7); (5,2); (4,1); (6,8)|] |> should equal [|3;3;2;2;2;1;1;2|]
