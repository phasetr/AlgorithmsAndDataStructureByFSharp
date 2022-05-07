@"https://atcoder.jp/contests/dp/tasks/dp_p
N 頂点の木があります。
頂点には 1, 2, \ldots, N と番号が振られています。
各 i (1 \leq i \leq N - 1) について、
i 番目の辺は頂点 x_i と y_i を結んでいます。

太郎君は、各頂点を白または黒で塗ることにしました。
ただし、隣り合う頂点どうしをともに黒で塗ってはいけません。

頂点の色の組合せは何通りでしょうか？
10^9 + 7 で割った余りを求めてください。

制約

* 入力はすべて整数である。
* 1 \leq N \leq 10^5
* 1 \leq x_i, y_i \leq N
* 与えられるグラフは木である。"

"""解説: https://kyopro-friends.hatenablog.com/entry/2019/01/12/231035
木DPというやつね。
部分木に関する情報を集めて元の木に関する問題に答えるようなDPよ。
まず適当な頂点を1つ選んで根とするわ。
各頂点は子が何色かによって塗れる色が決まるから、
各部分木について、根が黒/白の塗り方の数がわかればいいわね。
dp[i][j]=(頂点iを(j?黒く:白く)塗ったとき、
          iを親とする部分木の塗り方の場合の数)
とすると、
dp[i][0]=∏_{jはiの子}(dp[j][0]+dp[j][1])
dp[i][1]=∏_{jはiの子}dp[j][0]
となるわ。
実装は根からたどれるメモ化再帰が簡単じゃないかしら。

void f(int i){
    if(flag[i])return;
    flag[i]=1;
    dp[i][0]=1;
    dp[i][1]=1;
    for(iの子jについて){
        f(j);
        dp[i][0]=dp[i][0]*(dp[j][0]+dp[j][1])%MOD;
        dp[i][1]=dp[i][1]*dp[j][0];
    }
}
//頂点1を根とすると
//f(1);
//ans=(dp[1][0]+dp[1][1])%MOD;
計算量はO(N)ね。"""
#r "nuget: FsUnit"
open FsUnit

"TODO"
let N,Aa = 3,[|(1,2);(2,3)|]
let solve N Aa =
    let m = 1_000_000_007
    let (.+) x y = (x+y)%m
    let (.*) x y = (x*y)%m

    let memoize3 dimx dimy f =
        let memo = Array2D.create dimx dimy None
        let rec g n m o =
            match memo.[n,m] with
                | Some x -> x
                | None ->
                    let result = f g n m o
                    Array2D.set memo n m (Some result)
                    result
        g

    let g =
        (Array.create N [], Aa)
        ||> Array.fold (fun g (x,y) ->
            Array.set g (x-1) ((y-1)::g.[x-1])
            Array.set g (y-1) ((x-1)::g.[y-1])
            g)
    let f_norec f v v_color parent =
        g.[v]
        |> List.choose (fun nv ->
            if nv=parent then None
            else
                match v_color with
                    | 0 -> Some (f nv 0 v .+ f nv 1 v)
                    | _ -> Some (f nv 0 v))
        |> List.fold (.*) 1
    let f = memoize3 N 2 f_norec
    f 0 0 0 + f 0 1 0
let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..N-1 do (stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1]) |]
solve N Aa |> stdout.WriteLine

solve 3 [|(1,2);(2,3)|] |> should equal 5
solve 4 [|(1,2);(1,3);(1,4)|] |> should equal 9
solve 1 [||] |> should equal 2
solve 10 [|(8,5);(10,8);(6,5);(1,5);(4,8);(2,10);(3,6);(9,2);(1,7)|] |> should equal 157
