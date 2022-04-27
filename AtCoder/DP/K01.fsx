@"https://atcoder.jp/contests/dp/tasks/dp_k
N 個の正整数からなる集合 A = \{ a_1, a_2, \ldots, a_N \} があります。
太郎君と次郎君が次のゲームで勝負します。
最初に、K 個の石からなる山を用意します。
二人は次の操作を交互に行います。
先手は太郎君です。

* A の元 x をひとつ選び、山からちょうど x 個の石を取り去る。

先に操作を行えなくなった人が負けです。
二人が最適に行動すると仮定したとき、どちらが勝つかを判定してください。

制約

* 入力はすべて整数である。
* 1 \leq N \leq 100
* 1 \leq K \leq 10^5
* 1 \leq a_1 < a_2 < \cdots < a_N \leq K"
#r "nuget: FsUnit"
open FsUnit

"""解説から: https://kyopro-friends.hatenablog.com/entry/2019/01/12/231000
ゲームの基本的な問題だよ！
石の個数によって勝敗が決まるから、
dp[i]=(石の個数がi個のとき直後の手番の人が勝てるか？)
を考えるよ。これがYesになる状態を「勝ち状態」、Noになる状態を「負け状態」と呼ぶことにするね。
自分の手番の後で残る石の個数としてありえるものについて考えて、
どれか1つでも「負け状態」になるなら、それを相手に渡せば良くて、
全部「勝ち状態」ならどうやっても相手に「勝ち状態」を渡すことになるから自分は負けだよ。

rep(i,1,K+1){
    rep(j,1,N+1)if(i-a[j]>=0&&dp[i-a[j]]==0)dp[i]=1;
}
//ans=dp[K];

計算量はO(NK)だね。"""
let N,K,Aa = 2,4,[|2;3|]
let solve N K Aa =
    (Array.zeroCreate (K+1), [|1..K|])
    ||> Array.fold (fun dp i -> Array.set dp i (1 - (Array.fold (fun s w -> if w<=i then min s dp.[i-w] else s) 1 Aa)); dp)
    |> fun dp -> if dp.[K]=1 then "First" else "Second"
let N,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N K Aa |> stdout.WriteLine

solve 2 4 [|2;3|] |> should equal "First"
solve 2 5 [|2;3|] |> should equal "Second"
solve 2 7 [|2;3|] |> should equal "First"
solve 3 20 [|1..3|] |> should equal  "Second"
solve 3 21 [|1..3|] |> should equal "First"
solve 1 100000 [|1|] |> should equal "Second"
