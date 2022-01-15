@"問題文
高橋君は早押しクイズの大会を開くことにしました。
スコアボードの作成を任されたキザハシ君は、
次のルールを持つラウンドのポイントを管理するプログラムを書くのに苦戦しています。

このラウンドの参加者は N 人であり、
1 から N までの番号がついています。
ラウンド開始時点では全員が K ポイントを持っています。

誰かが問題に正解すると、その人以外の N−1 人のポイントが 1 減ります。
これ以外によるポイントの変動はありません。

ラウンド終了時にポイントが 0 以下の参加者は敗退し、
残りの参加者が勝ち抜けます。

このラウンドでは Q 回の正解が出て、
i 番目に正解したのは参加者 Ai でした。
キザハシ君の代わりに、
N 人の参加者のそれぞれが勝ち抜けたか敗退したかを求めるプログラムを作成してください。

制約
入力はすべて整数
2≤N≤10^5
1≤K≤10^9
1≤Q≤10^5
1≤Ai≤N (1≤i≤Q)"
#r "nuget: FsUnit"
open FsUnit

// 初期値Kから減算するのではなくAsに現れた回数だけ加算する
let solve N K Q As =
    // 1..Nの分だけ回数を浮かせている
    let yesno (_, xs: array<int>) = if xs.Length > Q-K+1 then "Yes" else "No"
    Array.append As [|1..N|] // 1..Nを必ず一回は出現させる
    |> Array.sort       // groupByでまとめるための処理
    |> Array.groupBy id // 出現回数をまとめる
    |> Array.map yesno

let N, K, Q = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1], x.[2])
let As = [| for i in 1..Q do (stdin.ReadLine() |> int) |]
solve N K Q As |> String.concat " " |> printfn "%s"

solve 6 3 4 [|3; 1; 3; 2|] |> should equal [|"No"; "No"; "Yes"; "No"; "No"; "No"|]
solve 6 5 4 [|3; 1; 3; 2|] |> should equal [|"Yes"; "Yes"; "Yes"; "Yes"; "Yes"; "Yes"|]
solve 10 13 15 [|3;1;4;5;9;2;6;5;3;5;8;9;7;9|] |> should equal [|"No";"No";"No";"No";"Yes";"No";"No";"No";"Yes";"No"|]
