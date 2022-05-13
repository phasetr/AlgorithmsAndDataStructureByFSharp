@"https://atcoder.jp/contests/dp/tasks/dp_q
N 本の花が横一列に並んでいます。
各 i (1 \leq i \leq N) について、左から i 番目の花の高さは h_i で、美しさは a_i です。
ただし、h_1, h_2, \ldots, h_N はすべて相異なります。

太郎君は何本かの花を抜き去ることで、次の条件が成り立つようにしようとしています。

* 残りの花を左から順に見ると、高さが単調増加になっている。

残りの花の美しさの総和の最大値を求めてください。

制約

* 入力はすべて整数である。
* 1 \leq N \leq 2 × 10^5
* 1 \leq h_i \leq N
* h_1, h_2, \ldots, h_N はすべて相異なる。
* 1 \leq a_i \leq 10^9"
"""解説 https://kyopro-friends.hatenablog.com/entry/2019/01/12/231035
i番目までの選び方を決めた時、次の決め方に影響するのは最後に選んだ花だけだから
dp[i][j]=(i番目まで使って最後の高さがjであるようなものの美しさの最大値)
というのを考えるのが自然よね。
dp[i][j]=
 max{dp[i−1][k]|0≤k<j}+a[i] (h[i]==jのとき)
 dp[i−1][j]                 (それ以外)
1回あたり更新するのは1箇所だから、iを状態にもつ必要はなくて、配列を使い回すことができるわ。
あとは、区間maxが高速に計算できればいいから、セグメント木を使えばできるわね。
セグメント木の説明は省略するけど、区間に対する操作が高速にできるようなデータ構造のことよ。

rep(i,1,N+1){
    temp=getmax(0,h[i]);//dp[0],...,dp[h[i]-1]のmax
    setvalue(h[i],temp+a[i]);//dp[h[i]]をtemp+a[i]にする
}
ans=getmax(0,N+1);

セグメント木は区間maxの計算と値の変更をどちらもO(logN)でできるから、
計算量はO(NlogN)になるわね。

もしこの問題で全てのa[i]が1なら、
これは最長増加部分列と全く同じ問題ね。
つまり最長増加部分列問題もこの解き方で解けるわ。"""
#r "nuget: FsUnit"
open FsUnit

"TODO"
let N,Ha,Aa = 4,[|3;1;4;2|],[|10L;20L;30L;40L|]
let solve N Ha Aa = 1

let N = stdin.ReadLine() |> int
let Ha = stdin.ReadLine().Split() |> Array.map int
let Aa = stdin.ReadLine().Split() |> Array.map int64
solve N Ha Aa |> stdout.WriteLine

solve 4 [|3;1;4;2|] [|10L;20L;30L;40L|] |> should equal 60
solve 1 [|1|] [|10L|] |> should equal 10
solve 5 [|1;2;3;4;5|] [|1000000000L;1000000000L;1000000000L;1000000000L;1000000000L|] |> should equal 5000000000L
solve 9 [|4;2;5;8;3;6;1;7;9|] [|6L;8L;8L;4L;6L;3L;5L;7L;5|] |> should equal 31
