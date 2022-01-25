@"https://atcoder.jp/contests/abc113/tasks/abc113_b
問題文
ある国で、宮殿を作ることになりました。
この国では、標高が x メートルの地点での平均気温は T−x×0.006 度です。
宮殿を建設する地点の候補は N 個あり、
地点 i の標高は Hi メートルです。

joisinoお姫様は、
これらの中から平均気温が
A 度に最も近い地点を選んで宮殿を建設するようにあなたに命じました。

宮殿を建設すべき地点の番号を出力してください。
ただし、解は一意に定まることが保証されます。

制約
1≤N≤1000
0≤T≤50
−60≤A≤T
0≤H_i≤10^5
入力は全て整数
解は一意に定まる"
#r "nuget: FsUnit"
open FsUnit

let solve N T A Hs =
    let temperature T H = T - H * 0.006
    Hs
    |> Array.mapi (fun i H -> (i, abs <| A - (temperature T H)))
    |> Array.minBy (fun (i, t) -> t)
    |> (fun x -> (fst x) + 1)

let N = stdin.ReadLine() |> int
let T, A = stdin.ReadLine().Split() |> Array.map float |> (fun x -> x.[0], x.[1])
let Hs = stdin.ReadLine().Split() |> Array.map float
solve N T A Hs |> stdout.WriteLine

solve 2 12 5 [|1000;2000|] |> should equal 1
solve 3 21 -11 [|81234;94124;52141|] |> should equal 3
