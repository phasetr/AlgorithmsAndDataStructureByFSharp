@"https://atcoder.jp/contests/dp/tasks/dp_r
N 頂点の単純有向グラフ G があります。
頂点には 1, 2, \ldots, N と番号が振られています。

各 i, j (1 \leq i, j \leq N) について、
頂点 i から j への有向辺の有無が整数 a_{i, j} によって与えられます。
a_{i, j} = 1 ならば頂点 i から j への有向辺が存在し、a_{i, j} = 0 ならば存在しません。

G の長さ K の有向パスは何通りでしょうか？
10^9 + 7 で割った余りを求めてください。
ただし、同じ辺を複数回通るような有向パスも数えるものとします。

制約

* 入力はすべて整数である。
* 1 \leq N \leq 50
* 1 \leq K \leq 10^{18}
* a_{i, j} は 0 または 1 である。
* a_{i, i} = 0"
"""解説: https://kyopro-friends.hatenablog.com/entry/2019/01/12/231035
長さKのパスを考えるのだから、とりあえず始点と終点を状態として
dp[n][i][j]=(頂点iから頂点jへ行く長さnのパスの個数)
というのを考えてみるわ。状態遷移は
dp[n][i][j]=∑kdp[n−1][i][k]∗a[k][j]
となるわね。ところで、この積の形、よくみると行列の積と同じね！
dp[n][i][j]を(i,j)成分とする行列をDPnと書くことにすると、
さっきの漸化式は
DP_n=DP_{n−1}A
になるわ。
DP_0は明らかに単位行列だから、DP_n=A^nね。
求める答えは∑i,jdp[K][i][j]だから、
A^Kを計算すれば求められるわよ。

matrixpow(A,K,MOD);//Aをmod MODでK乗する
rep(i,1,N+1)rep(j,1,N+1)ans=(ans+A[i][j])%MOD;

行列の積は1回あたりO(N^3)、
繰り返し二乗法を使えば積を計算する回数はO(logK)だから、
O(N^3 log K)で求められるわね。

「行列の積と同じ式になってると気づくのは無理じゃない？」
そうね、こればっかりは知ってるかどうかになりそうね。
行列累乗で解く問題は、次の２つのポイントを抑えておくといいわ。
どっちも決め手になるほどじゃないけど……

・ポイント１：制約をみる
N≤50くらい、Kは109とか1018とかの大きな値、
みたいな制約の問題は、サイズN×Nの行列をK乗するかも。
・ポイント２：繰り返し
今回の状態遷移の式を見ると、回数nが遷移に影響しないわね。
こういうふうに同じ状態遷移を何度も繰り返すものは、行列累乗かも。
"""
#r "nuget: FsUnit"
open FsUnit

let N,K,Aa = 4,2L,(array2D [|[|0L;1L;0L;0L|];[|0L;0L;1L;1L|];[|0L;0L;0L;1L|];[|1L;0L;0L;0L|]|])
let N,K,Aa = 10,1000000000000000000L,(array2D [|[|0;0;1;1;0;0;0;1;1;0|];[|0;0;0;0;0;1;1;1;0;0|];[|0;1;0;0;0;1;0;1;0;1|];[|1;1;1;0;1;1;0;1;1;0|];[|0;1;1;1;0;1;0;1;1;1|];[|0;0;0;1;0;0;1;0;1;0|];[|0;0;0;1;1;0;0;1;0;1|];[|1;0;0;0;1;0;1;0;0;0|];[|0;0;0;0;0;1;0;0;0;0|];[|1;0;1;1;1;0;1;1;1;0|]|])
let solve N K Aa =
    let m = 1_000_000_007L
    let times (A:int64[,]) (B:int64[,]) =
        (Array2D.zeroCreate N N, [|0..N-1|])
        ||> Array.fold (fun ca i ->
            (ca,[|0..N-1|])
            ||> Array.fold (fun ca j ->
                (ca,[|0..N-1|])
                ||> Array.fold (fun ca k -> Array2D.set ca i j ((ca.[i,j]+A.[i,k]*B.[k,j])%m); ca)))
    let rec exponen A k =
        if k=0L then [|0..N-1|] |> Array.map (fun i -> [|0..N-1|] |> Array.map (fun j -> if i=j then 1L else 0L)) |> array2D
        elif k%2L=0L then exponen (times A A) (k/2L)
        else times A (exponen A (k-1L))
    let X = exponen Aa K
    (0L,Array.allPairs [|0..N-1|] [|0..N-1|])
    ||> Array.fold (fun acc (i,j) -> (acc + X.[i,j])%m)
let N,K = stdin.ReadLine().Split() |> (fun x -> int x.[0], int64 x.[1])
let Aa = [| for i in 1..N do (stdin.ReadLine().Split() |> Array.map int64) |] |> array2D
solve N K Aa |> stdout.WriteLine

solve 4 2L (array2D [|[|0L;1L;0L;0L|];[|0L;0L;1L;1L|];[|0L;0L;0L;1L|];[|1L;0L;0L;0L|]|]) |> should equal 6
solve 3 3L (array2D [|[|0L;1L;0L|];[|1L;0L;1L|];[|0L;0L;0L|]|]) |> should equal 3
solve 6 2L (array2D [|[|0L;0L;0L;0L;0L;0L|];[|0L;0L;1L;0L;0L;0L|];[|0L;0L;0L;0L;0L;0L|];[|0L;0L;0L;0L;1L;0L|];[|0L;0L;0L;0L;0L;1L|];[|0L;0L;0L;0L;0L;0L|]|]) |> should equal 1
solve 1 1L (array2D [|[|0L|]|]) |> should equal 0
solve 10 1000000000000000000L (array2D [|[|0L;0L;1L;1L;0L;0L;0L;1L;1L;0L|];[|0L;0L;0L;0L;0L;1L;1L;1L;0L;0L|];[|0L;1L;0L;0L;0L;1L;0L;1L;0L;1L|];[|1L;1L;1L;0L;1L;1L;0L;1L;1L;0L|];[|0L;1L;1L;1L;0L;1L;0L;1L;1L;1L|];[|0L;0L;0L;1L;0L;0L;1L;0L;1L;0L|];[|0L;0L;0L;1L;1L;0L;0L;1L;0L;1L|];[|1L;0L;0L;0L;1L;0L;1L;0L;0L;0L|];[|0L;0L;0L;0L;0L;1L;0L;0L;0L;0L|];[|1L;0L;1L;1L;1L;0L;1L;1L;1L;0L|]|]) |> should equal 957538352
