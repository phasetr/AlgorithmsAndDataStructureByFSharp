@"https://atcoder.jp/contests/dp/tasks/dp_m
N 人の子供たちがいます。
子供たちには 1, 2, \ldots, N と番号が振られています。

子供たちは K 個の飴を分け合うことにしました。
このとき、各 i (1 \leq i \leq N) について、
子供 i が受け取る飴の個数は 0 以上 a_i 以下でなければなりません。
また、飴が余ってはいけません。

子供たちが飴を分け合う方法は何通りでしょうか？
10^9 + 7 で割った余りを求めてください。
ただし、2 通りの方法が異なるとは、
ある子供が存在し、その子供が受け取る飴の個数が異なることを言います。

制約

* 入力はすべて整数である。
* 1 \leq N \leq 100
* 0 \leq K \leq 10^5
* 0 \leq a_i \leq K"
"""解説から https://kyopro-friends.hatenablog.com/entry/2019/01/12/231035
dp[i][j]=(i番目までの子供たちにj個の飴を配る場合の数)
ってDPをやるだけだと計算量が O(NK^2) で大きくなり過ぎる.

状態遷移のところをよくみてみるわ。数式で書くと、これってこういうことよね。
dp[i][j]=∑k=max(0,j−a[i])jdp[i−1][k]
これはdp[i−1][∗]の区間の和だから、累積和を使えば高速化することができるわね。

dp[0][0]=1;
rep(i,1,N+1){
    cum[0]=0;
    rep(j,1,K+1+1)cum[j]=(cum[j-1]+dp[i-1][j-1])%MOD;
    //cum[j]=dp[i-1][0]+...+dp[i-1][j-1]
    rep(j,0,K+1)dp[i][j]=(cum[j+1]-cum[max(0,j-a[i])]+MOD)%MOD;
}
ans=dp[N][K];

計算量はO(NK)よ。"""
#r "nuget: FsUnit"
open FsUnit

let N,K,Aa = 3,4,[|1;2;3|]
let solve N K (Aa:int[]) =
    let num = 1_000_000_007
    let (+@) a b = (a+b) % num
    let (-@) a b = (a-b+num) % num
    (Array2D.zeroCreate (N+1) (K+1), [|0..K|])
    ||> Array.fold (fun dp i -> Array2D.set dp 0 i 1; dp)
    |> (fun dp ->
        (dp, [|1..N|])
        ||> Array.fold (fun dp i ->
            Array2D.set dp i 0 1
            (dp, [|1..K|])
            ||> Array.fold (fun dp j ->
                Array2D.set dp i j (dp.[i,j-1] +@ if 0<j-Aa.[i-1] then dp.[i-1,j] -@ dp.[i-1,j-Aa.[i-1]-1] else dp.[i-1,j])
                dp)))
    |> fun dp -> if K=0 then dp.[N,0] else dp.[N,K] -@ dp.[N,K-1]
let N,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N K Aa |> stdout.WriteLine

solve 3 4 [|1;2;3|] |> should equal 5
solve 1 10 [|9|] |> should equal 0
solve 2 0 [|0;0|] |> should equal 1
solve 4 100000 [|100000;100000;100000;100000|] |> should equal 665683269
