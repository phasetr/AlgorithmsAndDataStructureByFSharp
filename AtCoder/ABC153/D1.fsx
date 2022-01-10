@"https://atcoder.jp/contests/abc153/tasks/abc153_d
カラカルはモンスターと戦っています。
モンスターの体力は H です。
カラカルはモンスターを 1 体選んで攻撃することができます。
モンスターを攻撃したとき、攻撃対象のモンスターの体力に応じて、次のどちらかが起こります。

モンスターの体力が 1 なら、そのモンスターの体力は 0 になる
モンスターの体力が X>1 なら、そのモンスターは消滅し、体力が ⌊X/2⌋ のモンスターが新たに 2 体現れる
（⌊r⌋ は r を超えない最大の整数を表す）

全てのモンスターの体力を 0 以下にすればカラカルの勝ちです。
カラカルがモンスターに勝つまでに行う攻撃の回数の最小値を求めてください。

制約
1≤H≤10^{12}

入力中のすべての値は整数である。"
@"実験
2 - 1 1
4 - 2 2 - 1 1 2 - 1 1 1 1
5 - 2 2 - 1 1 2 - 1 1 1 1
8 - 4 4 - 2 2 4 - 1 1 2 4 - 1 1 1 1 4
13 - 6 6 - 3 3 3 3 - 1 1 1 1 1 1 1 1
"
#r "nuget: FsUnit"
open System
open System.IO
open FsUnit

let rec solve H =
    // 実験するとわかるように 2^n <= H < 2^{n-1} は全て同じ値
    // 1 に分割するまでのプロセス数と 2^n 個の 1 を消す回数を足す
    let n =
        Seq.initInfinite (fun x -> pown 2L (x+1))
        |> Seq.takeWhile (fun x -> x <= H)
        |> Seq.length
    2L * (pown 2L n) - 1L

let H = stdin.ReadLine() |> int64
solve H |> printfn "%d"

solve 2L |> should equal 3L
solve 3L |> should equal 3L
solve 4L |> should equal 7L
solve 1000000000000L |> should equal 1099511627775L
