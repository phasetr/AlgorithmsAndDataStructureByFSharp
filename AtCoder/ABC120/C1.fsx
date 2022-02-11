@"https://atcoder.jp/contests/abc120/tasks/abc120_c"
#r "nuget: FsUnit"
open FsUnit

@"0と1がそれぞれ1つ以上あれば必ずどこかで取り除ける.
逆に取り除けなくなるのは0か1しかないとき.
結果としては0と1の個数をカウントしてその小さい方の個数の2倍が求める数"
let solve S =
    S |> Seq.groupBy id
    |> Seq.map (fun (_,ss) -> Seq.length ss)
    |> fun xs ->
        if Seq.length xs = 1 then 0
        else (Seq.min xs) * 2

let S = stdin.ReadLine()
solve S |> stdout.WriteLine

solve "0011" |> should equal 4
solve "11011010001011" |> should equal 12
solve "0" |> should equal 0
