@"https://atcoder.jp/contests/dp/tasks/dp_l
太郎君と次郎君が次のゲームで勝負します。

最初に、数列 a = (a_1, a_2, \ldots, a_N) が与えられます。
a が空になるまで、二人は次の操作を交互に行います。
先手は太郎君です。

* a の先頭要素または末尾要素を取り除く。
  取り除いた要素を x とすると、操作を行った人は x 点を得る。

ゲーム終了時の太郎君の総得点を X、次郎君の総得点を Y とします。
太郎君は X - Y を最大化しようとし、
次郎君は X - Y を最小化しようとします。

二人が最適に行動すると仮定したとき、X - Y を求めてください。

制約

* 入力はすべて整数である。
* 1 \leq N \leq 3000
* 1 \leq a_i \leq 10^9"
"""解説から: https://kyopro-friends.hatenablog.com/entry/2019/01/12/231000
太字で書いてあるところは要するに「(自分の点数)－(相手の点数)を最大化しようとする」だね！
前から取ったほうがいいか後ろから取ったほうがいいかは、
残った数を使ってのゲームの結果が分かれば判断できるから、
dp[i][j]=(区間[i,j]が残ってるときの「次の手番の人の得点－そうじゃない方の人の得点」)
とすればよさそうだね。実装はメモ化再帰が簡単かな。

int f(int l,int r){
    if(flag[l][r])return dp[l][r];
    flag[l][r]=1;
    if(l==r)return dp[l][r]=a[l];
    return dp[l][r]=max(a[l]-f(l+1,r),a[r]-f(l,r-1));
}
//ans=f(1,N);
計算量はO(N^2)だね。
"""
#r "nuget: FsUnit"
open FsUnit
let N,Aa = 4,[|10L;80L;90L;30L|]
let N,Aa = 1,[|10L|]
let solve N (Aa:int64[]) =
    (Array2D.zeroCreate (N+1) (N+1), [|1..N|])
    ||> Array.fold (fun dp w ->
        (dp, [|0..N-w|]) ||> Array.fold (fun dp i -> Array2D.set dp i (i+w) (max (Aa.[i]-dp.[i+1,i+w]) (Aa.[i+w-1]-dp.[i,i+w-1])); dp))
    |> fun dp -> dp.[0,N]
let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int64
solve N Aa |> stdout.WriteLine

solve 4 [|10L;80L;90L;30L|] |> should equal 10L
solve 3 [|10L;100L;10L|] |> should equal -80L
solve 1 [|10L|] |> should equal 10L
solve 10 [|1000000000L;1L;1000000000L;1L;1000000000L;1L;1000000000L;1L;1000000000L;1L|] |> should equal 4999999995L
solve 6 [|4L;2L;9L;7L;1L;5L|] |> should equal 2L
