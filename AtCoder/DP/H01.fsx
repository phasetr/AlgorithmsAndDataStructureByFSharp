@"https://atcoder.jp/contests/dp/tasks/dp_h
縦 H 行、横 W 列のグリッドがあります。
上から i 行目、左から j 列目のマスを (i, j) で表します。

各 i, j (1 \leq i \leq H, 1 \leq j \leq W) について、
マス (i, j) の情報が文字 a_{i, j} によって与えられます。
a_{i, j} が . ならばマス (i, j) は空マスであり、
a_{i, j} が # ならばマス (i, j) は壁のマスです。
マス (1, 1) および (H, W) は空マスであることが保証されています。

太郎君は、マス (1, 1) から出発し、
右または下に隣り合う空マスへの移動を繰り返すことで、
マス (H, W) まで辿り着こうとしています。

マス (1, 1) から (H, W) までの太郎君の経路は何通りでしょうか？
答えは非常に大きくなりうるので、10^9 + 7 で割った余りを求めてください。

制約

* H および W は整数である。
* 2 \leq H, W \leq 1000
* a_{i, j} は . または # である。
* マス (1, 1) および (H, W) は空マスである。"
#r "nuget: FsUnit"
open FsUnit

"""解説から: https://kyopro-friends.hatenablog.com/entry/2019/01/12/231000
(H,W)へ行く場合の数は、(H−1,W),(H,W−1)へ行く場合の数の和だね。だから
dp[i][j]=((1,1)から(i,j)へ移動する場合の数のmod10^9+7)
とすれば解けそうだよ。

dp[1][1]=1;
rep(i,1,H+1)rep(j,1,W+1)if(!(i==1&&j==1)){
    if(a[i][j]=='#')dp[i][j]=0;
    else dp[i][j]=(dp[i-1][j]+dp[i][j-1])%MOD;
}
ans=dp[H][W];

計算量はO(HW)だよ。
"""
let H,W,Aa = 3,4,[|[|'.';'.';'.';'#'|];[|'.';'#';'.';'.'|];[|'.';'.';'.';'.'|]|]
let solve H W (Aa:char[][]) =
    let (+%) n m = (n+m) % ((pown 10 9) + 7)
    (Array2D.zeroCreate H W, [|0..H-1|])
    ||> Array.fold (fun (dp:int[,]) i ->
        (dp,[|0..W-1|]) ||> Array.fold (fun dp j ->
            if (i,j)=(0,0) then Array2D.set dp i j 1; dp
            elif Aa.[i].[j]='#' then dp
            elif i=0 then Array2D.set dp i j dp.[i,j-1]; dp
            elif j=0 then Array2D.set dp i j dp.[i-1,j]; dp
            else Array2D.set dp i j (dp.[i-1,j] +% dp.[i,j-1]); dp))
    |> fun dp -> dp.[H-1,W-1]
let H,W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Aa = [| for i in 1..H do (stdin.ReadLine() |> Seq.toArray) |]
solve H W Aa |> stdout.WriteLine

solve 3 4 [|[|'.';'.';'.';'#'|];[|'.';'#';'.';'.'|];[|'.';'.';'.';'.'|]|] |> should equal 3
solve 5 2 [|[|'.'; '.'|]; [|'#'; '.'|]; [|'.'; '.'|]; [|'.'; '#'|]; [|'.'; '.'|]|] |> should equal 0
solve 5 5 [|[|'.'; '.'; '#'; '.'; '.'|]; [|'.'; '.'; '.'; '.'; '.'|];[|'#'; '.'; '.'; '.'; '#'|]; [|'.'; '.'; '.'; '.'; '.'|];[|'.'; '.'; '#'; '.'; '.'|]|] |> should equal 24
solve 20 20 [|[|'.'; '.'; '.'; '.'; '.'; '.'; '.'; '.'; '.'; '.'; '.'; '.'; '.'; '.';'.'; '.'; '.'; '.'; '.'; '.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|]|] |> should equal 345263555
