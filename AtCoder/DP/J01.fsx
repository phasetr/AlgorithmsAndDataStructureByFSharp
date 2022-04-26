@"https://atcoder.jp/contests/dp/tasks/dp_j
N 枚の皿があります。
皿には 1, 2, \ldots, N と番号が振られています。
最初、各 i (1 \leq i \leq N) について、
皿 i にはa_i (1 \leq a_i \leq 3) 個の寿司が置かれています。

すべての寿司が無くなるまで、太郎君は次の操作を繰り返し行います。

* 1, 2, \ldots, N の目が等確率で出るサイコロを振り、
  出目を i とする。
  皿 i に寿司がある場合、皿 i の寿司を 1 個食べる。
  皿 i に寿司が無い場合、何も行わない。

すべての寿司が無くなるまでの操作回数の期待値を求めてください。

制約

* 入力はすべて整数である。
* 1 \leq N \leq 300
* 1 \leq a_i \leq 3"
#r "nuget: FsUnit"
open FsUnit

"""解説から: https://kyopro-friends.hatenablog.com/entry/2019/01/12/231000
まずは状態をどうやって持つか考えよう。
普通にやるとdp[a0][a1][a2][a3]…みたいに添字がN個欲しくなっちゃう。
でも例えば「皿1に寿司が2個、皿2に寿司が1個」という状態と
「皿1に寿司が1個、皿2に寿司が2個」という状態だと、
操作回数の期待値は同じになるよね。
よく考えると、「どの皿に何個あるか」っていうところまでわかる必要はなくて、
「1個の皿がいくつ、2個の皿がいくつ、3個の皿がいくつ」だけで期待値は決まることがわかるよ。
そこで
dp[c1][c2][c3]=(1個の皿がc1枚、2個の皿がc2枚、3個の皿がc3枚あるとき、全て食べるまでの操作回数の期待値)
というのを考えるよ。
えーっと、これはループで書くのが難しいからメモ化再帰で書く方がいいね。

dp[c1][c2][c3]=1+dp[c1−1][c2][c3]∗(1個の皿が選ばれる確率)+dp[c1+1][c2−1][c3]∗(2個の皿が選ばれる確率)+dp[c1][c2+1][c3−1]∗(3個の皿が選ばれる確率)+dp[c1][c2][c3]∗(0個の皿が選ばれる確率)
再帰なのに同じ状態に戻ってきちゃう！
けど、これはdp[c1][c2][c3]の項を移項すれば解消できるね。

dp[c1][c2][c3]=1/(1−(0個の皿が選ばれる確率))+dp[c1−1][c2][c3]∗(1個の皿が選ばれる確率)/(1−(0個の皿が選ばれる確率))+dp[c1+1][c2−1][c3]∗(2個の皿が選ばれる確率)/(1−(0個の皿が選ばれる確率))+dp[c1][c2+1][c3−1]∗(3個の皿が選ばれる確率)/(1−(0個の皿が選ばれる確率))
double f(int c1,int c2,int c3){
    if(flag[c1][c2][c3])return dp[c1][c2][c3];
    flag[c1][c2][c3]=1;
    fans=1/(1-(double)(N-c1-c2-c3)/N);//doubleにキャストしないと整数除算になっちゃう
    if(c1>0)fans+=f(c1-1,c2,c3)*c1/N/(1-(double)(N-c1-c2-c3)/N);
    if(c2>0)fans+=f(c1+1,c2-1,c3)*c2/N/(1-(double)(N-c1-c2-c3)/N);
    if(c3>0)fans+=f(c1,c2+1,c3-1)*c3/N/(1-(double)(N-c1-c2-c3)/N);
    return dp[c1][c2][c3]=fans;
}
//rep(i,1,N+1)c[a[i]]++;
//ans=f(c[1],c[2],c[3]);
計算量はO(N^3)だよ。
"""
let N,Aa = 3;[|1;1;1|]
"TODO"
let solve N Aa = 1

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> stdout.WriteLine

let near0 x y = (abs (x-y)) < 0.000_000_01

near0 (solve 3 [|1;1;1|]) 5.5 |> should be True
near0 (solve 1 [|3|]) 3 |> should be True
near0 (solve 2 [|1;2|]) 4.5 |> should be True
near0 (solve 10 [|1;3;2;3;3;2;3;2;1;3|]) 54.48064457488221 |> should be True
