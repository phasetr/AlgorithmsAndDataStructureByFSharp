@"https://atcoder.jp/contests/dp/tasks/dp_t
N を正整数とします。
長さ N - 1 の文字列 s が与えられます。
s は < と > からなります。

(1, 2, \ldots, N) を並べ替えた順列 (p_1, p_2, \ldots, p_N) であって、
次の条件を満たすものは何通りでしょうか？
10^9 + 7 で割った余りを求めてください。

* 各 i (1 \leq i \leq N - 1) について、
  s の i 文字目が < の場合は p_i < p_{i + 1} であり、
  s の i 文字目が > の場合は p_i > p_{i + 1} である。

制約

* N は整数である。
* 2 \leq N \leq 3000
* s は長さ N - 1 の文字列である。
* s は < と > からなる。"
"""解説: https://kyopro-friends.hatenablog.com/entry/2019/01/12/231035
dp[i][j][S]=(i番目まで決めたとき、最後の数がjで、使用済みの数の集合がSであるような場合の数)
というのはすぐ思いつくけど、N≤3000だからこれは当然無理ね……。
よく考えると、次に決める数は、前に決める数との大小関係さえわかっていればいいから
dp[i][j]=(i番目まで決めたとき、i番目の数より大きいものがj個残っているような場合の数)
というのを考えればうまくいきそうね。

rep(j,0,N)dp[1][j]=1;
rep(i,2,N+1){
    if(s[i-1]=='<'){
        rep(j,0,N-i+1)rep(k,j+1,N-i+2)dp[i][j]=(dp[i][j]+dp[i-1][k])%MOD;
    }else{
        rep(j,0,N-i+1)rep(k,0,j+1)dp[i][j]=(dp[i][j]+dp[i-1][k])%MOD;
    }
}
ans=dp[N][0]

…………と言いたいところだけど、これもまだO(N3)
なのよね。
M問題と同じように最後の部分で累積和を使うとO(N2)

に出来るわ

rep(j,0,N)dp[1][j]=1;
rep(i,2,N+1){
    cum[0]=0;
    rep(j,1,N-i+3)cum[j]=(cum[j-1]+dp[i-1][j])%MOD;
    if(s[i-1]=='<'){
        rep(j,0,N-i+1)dp[i][j]=(cum[N-i+2]-cum[j+1]+MOD)%MOD;
    }else{
        rep(j,0,N-i+1)dp[i][j]=cum[j+1];
    }
}
ans=dp[N][0];
"""
#r "nuget: FsUnit"
open FsUnit

let N,s = 4,"<><"
let solve N (s:string) =
    let MOD = 1_000_000_007
    let (.+.) x y = (x+y)%MOD
    (Array2D.zeroCreate N N, [|0..N-1|])
    ||> Array.fold (fun dp i -> Array2D.set dp 0 i 1; dp)
    |> fun dp ->
        (dp, [|0..N-2|])
        ||> Array.fold (fun dp i ->
            (Array.zeroCreate (N+1-i), [|0..(N-i-1)|])
            ||> Array.fold (fun cum j -> Array.set cum (j+1) (cum.[j] .+. dp.[i,j]); cum)
            |> fun cum ->
                (dp, [|0..(N-i-1)|])
                ||> Array.fold (fun dp j ->
                    if s.[i]='<' then Array2D.set dp (i+1) j cum.[j+1]; dp
                    else Array2D.set dp (i+1) j ((cum.[N-i] - cum.[j+1] + MOD)%MOD); dp))
    |> fun dp -> dp.[N-1,0]
let N = stdin.ReadLine() |> int
let s = stdin.ReadLine()
solve N s |> stdout.WriteLine

solve 4 "<><" |> should equal 5
solve 5 "<<<<" |> should equal 1
solve 20 ">>>><>>><>><>>><<>>" |> should equal 217136290
