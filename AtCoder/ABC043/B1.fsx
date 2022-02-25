@"https://atcoder.jp/contests/abc043/tasks/abc043_b
1 ≦ |s| ≦ 10 (|s| は s の長さを表す)
s は文字 0, 1, B のみからなる。
正解は空文字列ではない。"
#r "nuget: FsUnit"
open FsUnit

let solve s =
    ([], s) ||> Seq.fold (fun acc c ->
        if c='B' then
            if List.isEmpty acc then [] else List.tail acc
        else c::acc)
    |> Seq.rev |> Seq.map string |> String.concat ""

let s = stdin.ReadLine()
solve s |> stdout.WriteLine

solve "01B0" |> should equal "00"
solve "0BB1" |> should equal "1"
