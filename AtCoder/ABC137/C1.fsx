@"https://atcoder.jp/contests/abc137/tasks/abc137_c
- 2 \leq N \leq 10^5
- s_i は長さ 10 の文字列である。
- s_i の各文字は英小文字である。
- s_1, s_2, \ldots, s_N はすべて異なる。"
#r "nuget: FsUnit"
open FsUnit

@"各文字列をソートしてアナグラムを無視する.
あとはcountBy idして和を取る.
ここでカウントの結果がnのとき,
s_i<s_jをみたすペアの数を数えなければいけない点に注意する."
let solve N (Sa: array<string>) =
    let sum n = if n=2L then 1L else n*(n-1L) / 2L
    Sa |> Array.map (fun s -> s |> Seq.sort |> System.String.Concat)
    |> Array.countBy id
    |> Array.sumBy (snd >> int64 >> sum)
let N = stdin.ReadLine() |> int
let Sa = [| for i in 1..N do stdin.ReadLine() |]
solve N Sa |> stdout.WriteLine

solve 3 [|"acornistnt";"peanutbomb";"constraint"|] |> should equal 1
solve 2 [|"oneplustwo";"ninemodsix"|] |> should equal 0
