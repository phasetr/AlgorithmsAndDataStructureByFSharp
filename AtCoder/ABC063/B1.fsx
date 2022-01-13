@"https://atcoder.jp/contests/abc063/tasks/abc063_b
問題文
英小文字からなる文字列 S が与えられます。
S に含まれる文字がすべて異なるか判定してください。

制約
2≤∣S∣≤26, ここで ∣S∣ は S の長さを表す。
S は英小文字のみからなる。"
#r "nuget: FsUnit"
open System
open System.IO
open FsUnit

let solve S =
    let s = Set.ofSeq S
    if Set.count s = String.length S then "yes"
    else "no"

stdin.ReadLine()
|> solve |> printfn "%s"

solve "uncopyrightable" |> should equal "yes"
solve "different" |> should equal "no"
solve "no" |> should equal "yes"
