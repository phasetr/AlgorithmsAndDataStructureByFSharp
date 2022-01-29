"https://atcoder.jp/contests/abc053/tasks/abc053_b
すぬけくんは文字列 s の連続した一部分(部分文字列という)を取り出して
先頭が A であり末尾が Z であるような文字列を作ることにしました。
すぬけくんが作ることのできる文字列の最大の長さを求めてください。
なお，s には先頭が A であり末尾が Z であるような部分文字列が必ず存在することが保証されます。

制約
1≦∣s∣≦200,000
s は英大文字のみからなる
s には先頭が A であり末尾が Z であるような部分文字列が必ず存在する"
#r "nuget: FsUnit"
open FsUnit

let rec solve S =
    let a = S |> Seq.findIndex (fun c -> c = 'A')
    let z = S |> Seq.findIndexBack (fun c -> c = 'Z')
    z-a+1
let S = stdin.ReadLine()
solve S |> stdout.WriteLine

solve "QWERTYASDFZXCV" |> should equal 5
solve "ZABCZ" |> should equal 4
solve "HASFJGHOGAKZZFEGA" |> should equal 12
