@"https://atcoder.jp/contests/dp/tasks/dp_u
N 羽のうさぎたちがいます。
うさぎたちには 1, 2, \ldots, N と番号が振られています。

各 i, j (1 \leq i, j \leq N) について、
うさぎ i と j の相性が整数 a_{i, j} によって与えられます。
ただし、各 i (1 \leq i \leq N) について a_{i, i} = 0 であり、
各 i, j (1 \leq i, j \leq N) について a_{i, j} = a_{j, i} です。

太郎君は、N 羽のうさぎたちをいくつかのグループへ分けようとしています。
このとき、各うさぎはちょうど1 つのグループに属さなければなりません。
グループ分けの結果、各 i, j (1 \leq i < j \leq N) について、
うさぎ i と j が同じグループに属するならば、太郎君は a_{i, j} 点を得ます。

太郎君の総得点の最大値を求めてください。

制約

* 入力はすべて整数である。
* 1 \leq N \leq 16
* |a_{i, j}| \leq 10^9
* a_{i, i} = 0
* a_{i, j} = a_{j, i}"
"""解説: https://kyopro-friends.hatenablog.com/entry/2019/01/12/230754
bitDPっぽいねー。
dp[S]=(集合Sに属するウサギのグループ分けの最高得点)
としてみようか。あとはN問題とほぼ同じで、「どこで切るか」を考えると良さそうだね。
dp[S]=max(dp[T]+dp[S∖T])


ただし、N問題と違って「切らない」っていう選択肢もありだから注意が必要だよ。
実装はメモ化再帰の方が簡単かなあ。
bitDPは0-indexedの方が都合がいいから、入力は0-indexedで与えられているものとするねー。

#define bit(n,k) ((n>>k)&1) /*nのk bit目*/
long long f(int S){
    if(flag[S])return dp[S];
    flag[S]=1;
    //「切らない」場合を計算
    temp=0;
    rep(i,0,N)rep(j,i+1,N)if(bit(S,i)&&bit(S,j))temp+=a[i][j];
    fans=temp;
    //「どこで切るか」を考える
    for(Sの空でない真部分集合Tについて){
        fans=max(fans,f(T)+f(S^T));
    }
    return dp[S]=fans;
}
//ans=dp[(1<<N)-1];

for文で「部分集合T」を動くところが問題なんだけど、すぐに思いつく方法としてはこういうのがあるね。

rep(T,0,S)if((T|S)==S){/* */}

でもこれは状態数O(2^N)、遷移O(2^N)だから全体でO(4^N)になってTLEなんだよねー。
実は「Sの部分集合T」だけをちょうどループ出来るようなこういうテクニックが存在するよ。

for(int T=S;T>=0;T--){
    T&=S;
    /* */
}

この演算は「-1」という操作を「1であるような一番下のbitを0に変えて、
それより下のbitを全て1にする」という意味だと思うと納得できるんじゃないかな？
今回は、空集合とS自身を除くからこうだね。

for(int T=S;T>=0;T--){
    T&=S;
    if(T==S || T==0)continue;
    /* */
}

さて、計算量はどうなるかな？
このループは2^|S|回されるから、
全てのSについて和を考えると
∑S2|S|=∑Ni=0∑|S|=i2|S|=∑Ni=02i∗#{S | |S|=i}=∑Ni=02i∗NCi=∑Ni=02i∗1N−i∗NCi=(2+1)N=3N
となって、つまり全体でO(3^N)だね。これなら間に合うよ。
今回みたいにbitDPとかで役に立つbit演算のテクニックはこの記事が詳しいねー。
ビット列による部分集合表現 【ビット演算テクニック Advent Calendar 2016 1日目】 - prime's diary
https://primenumber.hatenadiary.jp/entry/2016/12/01/000000
"""
#r "nuget: FsUnit"
open FsUnit

let N,Aa = 3,[|[|0L;10L;20L|];[|10L;0L;-100L|];[|20L;-100L;0L|]|]
let solve N (Aa:int64[][]) =
    let m = 1 <<< N
    // let rec calc (dp:int64[]) (cost:int64[]) u s =
    //     if u = 0 then dp
    //     else
    //         Array.set dp s (max dp.[s] (dp.[s-u]+cost.[u]))
    //         calc dp cost ((u-1)&&&s) s

    (Array.zeroCreate m, [|0..(m-1)|])
    ||> Array.fold (fun cost s ->
        (cost, [|0..(N-1)|])
        ||> Array.fold (fun cost i ->
            (cost, [|0..(i-1)|])
            ||> Array.fold (fun cost j ->
                if (s>>>i &&& 1 = 1) && (s>>>j &&& 1 = 1)
                then Array.set cost s (cost.[s]+Aa.[i].[j]); cost
                else cost)))
    |> fun cost ->
        let mutable dp:int64[] = Array.zeroCreate m
        for s in 0..(m-1) do
            let mutable u = s
            while u<>0 do
                dp.[s] <- max dp.[s] (dp.[s-u]+cost.[u])
                u <- (u-1) &&& s
        dp |> Array.last
        // 再帰で書きたいがTLEしている
        // |> fun cost ->
        //     (Array.zeroCreate m, [|0..(m-1)|])
        //     ||> Array.fold (fun dp s -> calc (Array.zeroCreate m) cost s s)
        // |> Array.last
let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..N do (stdin.ReadLine().Split() |> Array.map int64) |]
solve N Aa |> stdout.WriteLine

solve 3 [|[|0L;10L;20L|];[|10L;0L;-100L|];[|20L;-100L;0L|]|] |> should equal 20L
solve 2 [|[|0L;-10L|];[|-10L;0L|]|] |> should equal 0L
solve 4 [|[|0L;1000000000L;1000000000L;1000000000L|];[|1000000000L;0L;1000000000L;1000000000L|];[|1000000000L;1000000000L;0L;-1L|];[|1000000000L;1000000000L;-1L;0L|]|] |> should equal 4999999999L
solve 16 [|[|0L;5L;-4L;-5L;-8L;-4L;7L;2L;-4L;0L;7L;0L;2L;-3L;7L;7L|];[|5L;0L;8L;-9L;3L;5L;2L;-7L;2L;-7L;0L;-1L;-4L;1L;-1L;9L|];[|-4L;8L;0L;-9L;8L;9L;3L;1L;4L;9L;6L;6L;-6L;1L;8L;9L|];[|-5L;-9L;-9L;0L;-7L;6L;4L;-1L;9L;-3L;-5L;0L;1L;2L;-4L;1L|];[|-8L;3L;8L;-7L;0L;-5L;-9L;9L;1L;-9L;-6L;-3L;-8L;3L;4L;3L|];[|-4L;5L;9L;6L;-5L;0L;-6L;1L;-2L;2L;0L;-5L;-2L;3L;1L;2L|];[|7L;2L;3L;4L;-9L;-6L;0L;-2L;-2L;-9L;-3L;9L;-2L;9L;2L;-5L|];[|2L;-7L;1L;-1L;9L;1L;-2L;0L;-6L;0L;-6L;6L;4L;-1L;-7L;8L|];[|-4L;2L;4L;9L;1L;-2L;-2L;-6L;0L;8L;-6L;-2L;-4L;8L;7L;7L|];[|0L;-7L;9L;-3L;-9L;2L;-9L;0L;8L;0L;0L;1L;-3L;3L;-6L;-6L|];[|7L;0L;6L;-5L;-6L;0L;-3L;-6L;-6L;0L;0L;5L;7L;-1L;-5L;3L|];[|0L;-1L;6L;0L;-3L;-5L;9L;6L;-2L;1L;5L;0L;-2L;7L;-8L;0L|];[|2L;-4L;-6L;1L;-8L;-2L;-2L;4L;-4L;-3L;7L;-2L;0L;-9L;7L;1L|];[|-3L;1L;1L;2L;3L;3L;9L;-1L;8L;3L;-1L;7L;-9L;0L;-6L;-8L|];[|7L;-1L;8L;-4L;4L;1L;2L;-7L;7L;-6L;-5L;-8L;7L;-6L;0L;-9L|];[|7L;9L;9L;1L;3L;2L;-5L;8L;7L;-6L;3L;0L;1L;-8L;-9L;0L|]|] |> should equal 132L
