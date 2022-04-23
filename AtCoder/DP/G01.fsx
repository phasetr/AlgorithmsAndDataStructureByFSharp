@"https://atcoder.jp/contests/dp/tasks/dp_g
N 頂点 M 辺の有向グラフ G があります。
頂点には 1, 2, \ldots, N と番号が振られています。
各 i (1 \leq i \leq M) について、
i 番目の有向辺は頂点 x_i から y_i へ張られています。
G は有向閉路を含みません。

G の有向パスのうち、最長のものの長さを求めてください。
ただし、有向パスの長さとは、有向パスに含まれる辺の本数のことです。

制約

* 入力はすべて整数である。
* 2 \leq N \leq 10^5
* 1 \leq M \leq 10^5
* 1 \leq x_i, y_i \leq N
* ペア (x_i, y_i) はすべて相異なる。
* G は有向閉路を含まない。"
#r "nuget: FsUnit"
open FsUnit

"""解説から
https://kyopro-friends.hatenablog.com/entry/2019/01/12/231000

これをもらうDP/配るDPで書くのはちょっと難しいね。
トポロジカルソートっていうのが必要になるのかな？
こういうときはメモ化再帰で書くといいよ！
f(x)=(xを始点とする最長経路)とすると

f(x)=
0 (xが葉のとき)
max{f(y)+1|xからyへの辺があるようなy} (そうでないとき)

として再帰で計算できるよ。答えはmax{f(x)}だね。
再帰の深さがO(N)くらいになるけど、
スタックオーバーフローはしないみたい。

int f(int x){
    if(flag[x])return dp[x];
    flag[x]=1;
    fans=0;
    for(xからyへの辺があるようなy){
        fans=max(fans,f(y)+1);
    }
    return dp[x]=fans;
}
//ans=0;
//rep(i,1,N+1)ans=max(ans,f(i));

計算量はO(N+M)だよ。
"""
@"https://atcoder.jp/contests/dp/submissions/3944462"
let N,M,Aa = 4,5,[|(1,2);(1,3);(3,2);(2,4);(3,4)|]
let solve N M Aa =
    // Haskell accumArray
    let targets s0 = ([], [ for (s,t) in Aa do if s-1=s0 then yield t-1 ]) ||> List.fold (fun x y -> y::x) |> Array.ofList
    let g = [|0..N-1|] |> Array.map (fun s0 -> targets s0)

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Aa = [| for i in 1..M do (stdin.ReadLine().Split |> Array.map int |> fun x -> x.[0],x.[1]) |]
solve N M Aa |> stdout.WriteLine

solve 4 5 [|(1,2);(1,3);(3,2);(2,4);(3,4)|] |> should equal 3
solve 6 3 [|(2,3);(4,5);(5,6)|] |> should equal 2
solve 5 8 [|(5,3);(2,3);(2,4);(5,2);(5,1);(1,4);(4,3);(1,3)|] |> should equal 3
