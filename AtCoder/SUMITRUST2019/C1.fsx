@"https://atcoder.jp/contests/sumitrust2019/tasks/sumitb2019_c
問題文
AtCoder 商店では、以下の 6 種類の品物が 1000000 個ずつ売られています。

1 個 100 円のおにぎり
1 個 101 円のサンドイッチ
1 個 102 円のクッキー
1 個 103 円のケーキ
1 個 104 円の飴
1 個 105 円のパソコン
高橋君は、合計価格がちょうど X 円となるような買い物をしたいです。
そのような買い方が存在するか判定してください。
ただし、消費税は考えないものとします。

制約
1≤X≤100000
X は整数"
#r "nuget: FsUnit"
open FsUnit

@"解説から.
「dp[i] = i円の買い物ができるか」とする.
dp[i-100],dp[i-101],dp[i-102],dp[i-103],dp[i-104],dp[i-105]のどれかがYesならdp[i]はYes."
let memorec f =
    let memo = System.Collections.Generic.Dictionary<_,_>()
    let rec frec j =
        match memo.TryGetValue j with
        | exist, value when exist -> value
        | _ ->
            let value = f frec j
            memo.Add(j, value)
            value
    frec
let solve N =
    let f frec n =
        if n < 100 then 0
        elif n=100 || n=101 || n=102 || n=103 || n=104 || n=105 then 1
        else
            if frec(n-100)=1 || frec(n-101)=1 || frec(n-102)=1 || frec(n-103)=1 || frec(n-104)=1 || frec(n-105)=1 then 1
            else 0
    (memorec f) N

let N = stdin.ReadLine() |> int
solve N |> stdout.WriteLine

solve 615 |> should equal 1
solve 217 |> should equal 0
