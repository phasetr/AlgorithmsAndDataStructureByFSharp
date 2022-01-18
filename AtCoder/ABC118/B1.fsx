@"https://atcoder.jp/contests/abc118/tasks/abc118_b
問題文
カツサンドくんはオムライスが好きです。

他にも明太子や寿司、
クリームブリュレやテンダーロインステーキなどが好きで、
これらの食べ物は全て、誰もが好きだと信じています。

その仮説を証明するために、
N 人の人に M 種類の食べ物について好きか嫌いかの調査を行いました。

調査の結果、i 番目の人は A_{i1}番目, A_{i2}番目, ..., A_{iK_i}番目の食べ物だけ好きだと答えました。
N 人全ての人が好きだと答えた食べ物の種類数を求めてください。

制約
入力は全て整数である。
1≤N,M≤30
1≤K_i≤M
1≤A_{ij}≤M
各 i (1≤i≤N) について A_{i1},A_{i2},...,A_{iK_i}は全て異なる。"
#r "nuget: FsUnit"
open FsUnit

let solve N M ass =
    ass
    |> Array.reduce Set.intersect
    |> Set.count
let N, M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Ass = [| for i in 1..N do (stdin.ReadLine().Split() |> Array.map int |> (fun x -> set x.[1..])) |]
solve N M Ass |> printfn "%d"

solve 3 4 [|set [1; 3]; set [1; 2; 3]; set[3; 2]|] |> should equal 1
solve 5 5 [|set [2; 3; 4; 5]; set [1; 3; 4; 5]; set [1; 2; 4; 5]; set [1; 2; 3; 5]; set [1; 2; 3; 4]|] |> should equal 0
solve 1 30 [|set [5;10;30]|] |> should equal 3
