@"https://atcoder.jp/contests/dp/tasks/dp_s
1 以上 K 以下の整数のうち、
十進表記における各桁の数字の総和が
D の倍数であるようなものは何個でしょうか？
10^9 + 7 で割った余りを求めてください。

制約

* 入力はすべて整数である。
* 1 \leq K < 10^{10000}
* 1 \leq D \leq 100"
"""解説: 桁DPね。
桁DPっていうのは本質的に1種類しかなくて、基本的にこの方針で実装することになるわ。
dp[i][f][∗]=(上からi桁目まで決めて、Kより小さいことが確定して(f?いて:いなくて)、条件*を満たすようなもの)
場合によっては下の桁から決めることもあるけど、まあ似たようなものね。
今回は桁和がDの倍数であるものの個数を調べたいから、
「既に決まっている部分の桁和のmodD」という状態を追加で持てばいいわよ。

桁DPについてはこのサイトの説明がわかりやすいと思うわ。
桁DP入門 - ペケンペイのブログ
https://web.archive.org/web/20170508234139/https://pekempey.hatenablog.com/entry/2015/12/09/000603
桁DPはもらうDPよりも配るDPの方が圧倒的に書きやすいのよね。
実はいままでA問題からR問題までは全部もらうDPで説明してたんだけど、気付いてたかしら？

//K[i]でKの先頭からi文字目の数が得られるとする
dp[0][0][0]=1;
rep(i,0,N)rep(j,0,D){
    rep(dig,0,10)dp[i+1][1][(j+dig)%D]=(dp[i+1][1][(j+dig)%D]+dp[i][1][j])%MOD;
    rep(dig,0,K[i+1])dp[i+1][1][(j+dig)%D]=(dp[i+1][1][(j+dig)%D]+dp[i][0][j])%MOD;
    dp[i+1][0][(j+K[i+1])%D]=(dp[i+1][0][(j+K[i+1])%D]+dp[i][0][j])%MOD;
}
ans=(dp[n][0][0]+dp[n][1][0]-1+MOD)%MOD;//答えに0が含まれるのでそれを除くために-1

計算量は、基数をBとしてO(DBlogBK)よ。"""
#r "nuget: FsUnit"
open FsUnit

let K,D = "30",4
let K,D = "1000000009",1
let solve K D =
    let MOD = 1_000_000_007
    let N = String.length K
    let (.+) x y = (x+y)%MOD
    let inline charToInt c = int c - int '0'

    ((0, Array2D.zeroCreate (N+1) D), [|0..(N-1)|])
    ||> Array.fold (fun (digitSum,dp) i ->
        (dp,[|0..(D-1)|])
        ||> Array.fold (fun dp j ->
            (dp,[|0..9|])
            ||> Array.fold (fun dp l ->
                let j0 = ((j-l)%D + D)%D
                Array2D.set dp (i+1) j (dp.[i+1,j] .+ dp.[i,j0]); dp))
        |> fun dp ->
            let ki = charToInt K.[i]
            (dp, [|0..(ki-1)|])
            ||> Array.fold (fun dp j ->
                let d0 = (digitSum+j)%D
                Array2D.set dp (i+1) d0 (dp.[i+1,d0]+1); dp)
            |> fun dp -> ((digitSum + ki)%D,dp))
    |> fun (digitSum,dp) ->
        Array2D.set dp N 0 (dp.[N,0]-1)
        Array2D.set dp N digitSum (dp.[N,digitSum]+1)
        dp.[N,0]%MOD
let K = stdin.ReadLine()
let D = stdin.ReadLine() |> int
solve K D |> stdout.WriteLine

solve "30" 4 |> should equal 6
solve "1000000009" 1 |> should equal 2
solve "98765432109876543210" 58 |> should equal 635270834
solve "2000000014" 2 |> should equal 1000000006
