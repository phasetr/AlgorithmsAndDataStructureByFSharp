@"https://atcoder.jp/contests/dp/tasks/dp_n
N 匹のスライムが横一列に並んでいます。
最初、左から i 番目のスライムの大きさは a_i です。

太郎君は、すべてのスライムを合体させて 1 匹のスライムにしようとしています。
スライムが 1 匹になるまで、太郎君は次の操作を繰り返し行います。

* 左右に隣り合う 2 匹のスライムを選び、それらを合体させて新しい 1 匹のスライムにする。
  合体前の 2 匹のスライムの大きさを x および y とすると、合体後のスライムの大きさは x + y となる。
  このとき、太郎君は x + y のコストを支払う。
  なお、合体の前後でスライムたちの位置関係は変わらない。

太郎君が支払うコストの総和の最小値を求めてください。

制約

* 入力はすべて整数である。
* 2 \leq N \leq 400
* 1 \leq a_i \leq 10^9"
"""この問題は逆から考えると簡単ね。つまり問題全体をこう読み替えるわけ。
「1匹のスライムがいる。大きさは∑a[i]である。
「スライムを2匹に分解する」という操作を繰り返して、
大きさが端から順にa[i]であるようなN匹のスライムを作ることを考える。
分解には分解前のスライムの大きさと等しいコストがかかる。
最小コストを求めよ。」
切るべき箇所は、最終的なスライムの切れ目にあたるN−1箇所のどれかね。
どれが最小になるか分かればいいから
dp[l][r]=(区間[l,r]に相当するスライムが1匹にまとまっているとき、
          それを分解するために必要な最小コスト)
が分かればいいわね。実装はメモ化再帰が簡単だと思うわ。

int f(int l,int r){
    if(flag[l][r])return dp[l][r];
    flag[l][r]=1;
    if(l==r)return 0;
    //どこで切るか全通り試す
    fans=INF;
    rep(m,l,r)fans=min(fans,f(l,m)+f(m+1,r));
    return dp[l][r]=fans+(a[l]～a[r]の和);//予め累積和を計算しておく
}
//ans=f(1,N);

状態数がO(N^2)、遷移がO(N)だから計算量はO(N^3)ね。"""
#r "/home/phasetr/.dotnet/sdk/6.0.100/ref/netstandard.dll"
#r "/usr/local/share/dotnet/x64/sdk/6.0.201/ref/netstandard.dll"
#r "nuget: FsUnit"
open FsUnit

let N,Aa = 4,[|10L;20L;30L;40L|]
let solve N (Aa:int64[]) =
    let acc = (Array.zeroCreate (N+1), [|0..(N-1)|]) ||> Array.fold (fun acc i -> Array.set acc (i+1) (Aa.[i] + acc.[i]); acc)
    (Array2D.zeroCreate N N, [|1..N-1|])
    ||> Array.fold (fun dp w ->
        (dp, [|0..(N-w-1)|])
        ||> Array.fold (fun dp l ->
            let v = Array.init w (fun i -> dp.[l,l+i]+dp.[l+i+1,l+w]) |> Array.fold min System.Int64.MaxValue
            Array2D.set dp l (l+w) (acc.[l+w+1] - acc.[l] + v); dp))
    |> fun dp -> dp.[0,N-1]
let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int64
solve N Aa |> stdout.WriteLine

solve 4 [|10L;20L;30L;40L|] |> should equal 190L
solve 5 [|10L;10L;10L;10L;10L|] |> should equal 120L
solve 3 [|1000000000L;1000000000L;1000000000L|] |> should equal 5000000000L
solve 6 [|7L;6L;8L;6L;1L;1L|] |> should equal 68L
