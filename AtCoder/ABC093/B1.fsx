@"https://atcoder.jp/contests/abc093/tasks/abc093_b
問題文
以下を満たす整数をすべて昇順に出力してください。

A 以上 B 以下の整数の中で、
小さい方から K 番目以内であるか、
大きい方から K 番目以内である

制約
1≤A≤B≤10^{9}
1≤K≤100
入力はすべて整数である"
#r "nuget: FsUnit"
open FsUnit

let solve A B K =
    if B-A <= K then [|A..B|]
    else
        Array.append [|A..(A+K-1)|] [|(B-K+1)..B|]
        |> Array.distinct
//        [A..(A+K-1)] @ [(B-K+1)..B]
//        |> Set.ofList |> Set.toArray |> Array.sort

let A,B,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1], x.[2])
solve A B K
|> Array.map string
|> String.concat "\n" |> stdout.WriteLine

solve 3 8 2 |> should equal [|3;4;7;8|]
solve 4 8 3 |> should equal [|4;5;6;7;8|]
solve 2 9 100 |> should equal [|2..9|]
