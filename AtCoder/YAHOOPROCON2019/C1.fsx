@"https://atcoder.jp/contests/yahoo-procon2019-qual/tasks/yahoo_procon2019_qual_c
1 \leq K,A,B \leq 10^9
K,A,B は整数である

持っているビスケットを叩き、1 枚増やす
ビスケット A 枚を 1 円に交換する
1 円をビスケット B 枚に交換する"
#r "nuget: FsUnit"
open FsUnit

@"円からの変換効率と回数の兼ね合いを見る.
A<Bならできる限りビスケットに交換した方がよさそうだが,
2回使ってAがBに変わる点にも注意する.
特に1<(B-A)/2Lでなければ円に交換する意味がない.
そもそもAに到達しなければ変換できない点にも注意する."
let solve K A B =
    if B-A <= 2L then K+1L // B=1Lを含む
    else
        let d = (K-(A-1L))/2L
        let m = (K-(A-1L))%2L
        (B-A)*d + m + A
let K,A,B = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1], x.[2])
solve K A B |> stdout.WriteLine

solve 4L 2L 6L |> should equal 7L
solve 7L 3L 4L |> should equal 8L
solve 314159265L 35897932L 384626433L |> should equal 48518828981938099L
