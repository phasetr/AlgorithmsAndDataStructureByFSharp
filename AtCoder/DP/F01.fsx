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

rep(i,1,slen+1)rep(j,1,tlen+1){
    if(s[i]==t[j])dp[i][j]=dp[i-1][j-1]+1;
    else dp[i][j]=max(dp[i-1][j],dp[i][j-1]);
}
dp[slen][tlen]が求める長さ

具体的に文字列を作るのはDP配列を逆にたどればできるよ。
もしs[i]==t[j]なら、
求める最長共通部分列の最後の文字はs[i]で、
それより前の部分はdp[i−1][j−1]の結果からわかって、
そうじゃないならどっちかの最後の文字は使わないから、
dpの値が減らない方に移動すればいいね。

len=dp[slen][tlen];
i=slen;
j=teln;
while(len>0){
    if(s[i]==t[j]){
        ans[len]=s[i];
        i--;
        j--;
        len--;
    }else if(dp[i][j]==dp[i-1][j]){
        i--;
    }else{
        j--;
    }
}
"""
let solve (s:string) (t:string) =
    let rec substr (dp:_[,]) i j =
        if dp.[i,j] = 0 then []
        elif dp.[i,j] = dp.[i-1,j] then substr dp (i-1) j
        elif dp.[i,j] = dp.[i,j-1] then substr dp i (j-1)
        else s.[i-1] :: substr dp (i-1) (j-1)
    (Array2D.zeroCreate (s.Length+1) (t.Length+1), [|1..s.Length|])
    ||> Array.fold (fun dp i ->
        (dp,[|1..t.Length|])
        ||> Array.fold (fun dp j ->
            match i with
            | i when s.[i-1] = t.[j-1] -> Array2D.set dp i j (dp.[i-1,j-1]+1); dp
            | i -> Array2D.set dp i j (max dp.[i-1,j] dp.[i,j-1]); dp))
    |> (fun (dp:int[,]) -> substr dp s.Length t.Length |> (List.rev >> List.toArray >> System.String))
let s = stdin.ReadLine()
let t = stdin.ReadLine()
solve s t |> stdout.WriteLine

solve "axyb" "abyxb" |> should equal "axb"
solve "aa" "xayaz" |> should equal "aa"
solve "a" "z" |> should equal ""
solve "abracadabra" "avadakedavra" |> should equal "aaadara"
