@"https://atcoder.jp/contests/dp/tasks/dp_f
文字列 s および t が与えられます。
s の部分列かつ t の部分列であるような文字列のうち、
最長のものをひとつ求めてください。

* s および t は英小文字からなる文字列である。
* 1 \leq |s|, |t| \leq 3000"
#r "nuget: FsUnit"
open FsUnit

"""解説
https://kyopro-friends.hatenablog.com/entry/2019/01/12/231000
「求める文字列の長さ」だけを先に求めておいて、
実際の文字列はそれを手がかりに構成していくよ。
dp[i][j]=(sをi文字目、tをj文字目までみた時の最長共通部分列の長さ)
とすると、
s[i]==t[j]のときこの文字は使ったほうがいいからdp[i−1][j−1]+1、
そうじゃないときは、
どっちかの最後の1文字は使わないからmax(dp[i−1][j],dp[i][j−1])になるね。
dp[slen][tlen]が求める長さ
具体的に文字列を作るのはDP配列を逆にたどればできるよ。
もしs[i]==t[j]なら、
求める最長共通部分列の最後の文字はs[i]で、
それより前の部分はdp[i−1][j−1]の結果からわかって、
そうじゃないならどっちかの最後の文字は使わないから、
dpの値が減らない方に移動すればいいね。"""
let sOrig,tOrig = "axyb","abyxb"
let sOrig,tOrig = "aa","xayaz"
let solve (sOrig:string) (tOrig:string) =
    let (s,t) = (seq sOrig, seq tOrig)
    let f xs si =
        let g (n,l) ((x0,l0),(x1,l1),tj) =
            if si=tj then (x0+1, Seq.append (seq [si]) l0)
            elif n>x1 then (n,l)
            else (x1,l1)
        Seq.zip3 (Seq.append (seq [(0,seq [])]) xs) xs t
        |> Seq.scan g (0,seq []) //|> Seq.tail
    Seq.fold f (Seq.replicate (Seq.length s + 1) (0,[])) s
//    |> Seq.toArray |> printfn "%A"
    |> Seq.last |> snd |> Seq.rev |> System.String.Concat
let S = stdin.ReadLine()
let T = stdin.ReadLine()
solve Xa |> stdout.WriteLine

solve "axyb" "abyxb" |> should equal "axb"
solve "aa" "xayaz" |> should equal "aa"
solve "a" "z" |> should equal ""
solve "abracadabra" "avadakedavra" |> should equal "aaadara"
