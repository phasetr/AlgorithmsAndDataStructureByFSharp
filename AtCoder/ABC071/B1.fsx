@"問題文
英小文字からなる文字列 S が与えられます．
S に現れない英小文字であって，
最も辞書順（アルファベット順）で小さいものを求めてください．
ただし，S にすべての英小文字が現れる場合は，
代わりに None を出力してください．

制約
1≤∣S∣≤10^5 (∣S∣ は文字列 S の長さ)
S は英小文字のみからなる．"
#r "nuget: FsUnit"
open System
open System.IO
open FsUnit

let solve S =
    let origs = set S
    let chk = set "abcdefghijklmnopqrstuvwxyz"
    let diff = Set.difference chk origs
    if Set.isEmpty diff then "None"
    else (Seq.reduce min diff |> string)

let S = stdin.ReadLine()
solve S |> printfn "%s"

solve "atcoderregularcontest" |> should equal "b"
solve "abcdefghijklmnopqrstuvwxyz" |> should equal "None"
solve "fajsonlslfepbjtsaayxbymeskptcumtwrmkkinjxnnucagfrg" |> should equal"d"
