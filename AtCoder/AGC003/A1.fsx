@"https://atcoder.jp/contests/agc003/tasks/agc003_a
問題文
高橋君は無限に広い 2 次元平面上に住んでいて、N 日間の旅行をします。
高橋君の旅程は長さ N の文字列 S であり、はじめは家にいます。
i(1≦i≦N) 日目には、

S の i 文字目が N なら北に
S の i 文字目が W なら西に
S の i 文字目が S なら南に
S の i 文字目が E なら東に
正の距離だけ移動します。

高橋君は、各日の移動距離は決めていません。
各日の移動距離をうまく決めることで、
高橋君が N 日間の旅程をすべて消化したときに家にいるようにできるかどうか判定してください。

制約
1≦∣S∣≦1000
S は文字 N, W, S, E のみからなる。"
#r "nuget: FsUnit"
open FsUnit

let f (n,s,e,w) = function
    | 'S' -> (n,true,e,w)
    | 'N' -> (true,s,e,w)
    | 'E' -> (n,s,true,w)
    | _   -> (n,s,e,true)
let solve S =
    // S,NまたはE,Wが同数出るか, どちらも一度も出ないかを判定
    S |> Seq.fold f (false,false,false,false)
    |> fun (n,s,e,w) -> n=s && e=w
    |> fun b -> if b then "Yes" else "No"
let S = stdin.ReadLine()
solve S |> stdout.WriteLine

solve "SENW" |> should equal "Yes"
solve "NSNNSNSN" |> should equal "Yes"
solve "NNEW" |> should equal "No"
solve "W" |> should equal "No"
