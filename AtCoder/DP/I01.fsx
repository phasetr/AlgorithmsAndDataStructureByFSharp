@"https://atcoder.jp/contests/dp/tasks/dp_i
N を正の奇数とします。

N 枚のコインがあります。
コインには 1, 2, \ldots, N と番号が振られています。
各 i (1 \leq i \leq N)について、
コイン i を投げると、確率 p_i で表が出て、確率 1 - p_i で裏が出ます。

太郎君は N 枚のコインをすべて投げました。
このとき、表の個数が裏の個数を上回る確率を求めてください。

制約

* N は奇数である。
* 1 \leq N \leq 2999
* p_i は実数であり、小数第 2 位まで与えられる。
* 0 < p_i < 1"
#r "nuget: FsUnit"
open FsUnit

"""解説から
dp[i]=(i枚目のコインまで投げたとき、表が出たコインの数の方が多い確率)
だと、次に裏が出たときでもまだ表のほうが多いかどうかがわからないからうまくいかないね。
表が出た枚数がわかってれば大丈夫そうだから
dp[i][j]=(i枚目のコインまで投げたとき、表がj枚でる確率)
で出来そうだよ。
dp[i][j]=(i−1枚目のコインまで投げたとき、表がj枚でる確率)×(i枚目のコインが裏である確率)+(i−1枚目のコインまで投げたとき、表がj−1枚でる確率)×(i枚目のコインが表である確率)
でちゃんと計算できるね。
答えは∑Nj=(N+1)/2dp[N][j]だよ。

dp[0][0]=1;
rep(i,1,N+1)rep(j,0,i+1){
    if(j>0)dp[i][j]=dp[i-1][j]*(1-p[i])+dp[i-1][j-1]*p[i];
    else dp[i][j]=dp[i-1][j]*(1-p[i]);
}
ans=0;
rep(j,N/2+1,N+1)ans+=dp[N][j];

計算量はO(N2)だね。"""

@"TODO"
let N,Pa = 3,[|0.30;0.60;0.80|]
let solve N Pa =
    (Array2D.zeroCreate (N+1) (N+1), [|1..N|])
    ||> Array.fold (fun dp i ->
        (dp, [|0..i|]) ||> Array.fold (fun dp j ->
            printfn "%A" (i,j)
            if (i,j)=(0,0) then Array2D.set dp 0 0 1.0; dp
            elif j=0 then Array2D.set dp i j (dp.[i-1,j] * (1.0-Pa.[i-1])); dp
            else Array2D.set dp i j (dp.[i-1,j]*(1.0-Pa.[i-1])); dp))
    |> fun dp -> (0.0,[|(N/2)..N|]) ||> Array.fold (fun s i -> s+dp.[N,i])

let N = stdin.ReadLine() |> int
let Pa = stdin.ReadLine().Split() |> Array.map float
solve N Pa |> stdout.WriteLine

let near0 x y = (abs (x-y)) < 0.000_000_000_1

near0 (solve 3 [|0.30;0.60;0.80|]) 0.612 |> should be True
near0 (solve 1 [|0.50|]) 0.5 |> should be True
near0 (solve 5 [|0.42;0.01;0.42;0.99;0.42|]) 0.382_181_587_2 |> should be True
