@"数字 1, 2, ..., 9 からなる文字列 S があります。
ダックスフンドのルンルンは、
S から連続する 3 個の数字を取り出し、
1 つの整数 X としてご主人様の元に持っていきます。
（数字の順番を変えることはできません。）

ご主人様が大好きな数は 753 で、これに近い数ほど好きです。
X と 753 の差（の絶対値）は最小でいくつになるでしょうか？

制約
S は長さ 4 以上 10 以下の文字列である。
S の各文字は 1, 2, ..., 9 のいずれかである。"
#r "nuget: FsUnit"
open System
open System.IO
open FsUnit

let solve S =
    let diff753 x = abs (x - 753)
    [0..(String.length S - 1)]
    |> Seq.map (fun i -> Seq.truncate 3 S.[i..])
    |> Seq.filter (fun xs -> Seq.length xs = 3)
    |> Seq.map (fun xs -> xs |> Array.ofSeq |> System.String.Concat |> int |> diff753)
    |> Seq.min

let S = stdin.ReadLine()
solve S |> printfn "%d"

solve "1234567876" |> should equal 34
solve "35753" |> should equal 0
solve "1111111111" |> should equal 642
