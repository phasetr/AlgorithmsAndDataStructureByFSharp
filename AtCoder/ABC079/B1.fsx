@"https://atcoder.jp/contests/abc079/tasks/abc079_b
今、日本は 11 月 18 日ですが、11 と 18 は隣り合うリュカ数です。
整数 N が与えられるので、N 番目のリュカ数を求めてください。

ただし、リュカ数は i 番目のリュカ数を Li とすると、

L_0=2
L_1=1
L_i = L_{i−1}+L_{i−2} (i≧2)

と定義される数とします。

制約
1≦N≦86
答えは10^18より小さいことが保証される
入力は整数からなる"
#r "nuget: FsUnit"
open FsUnit

// 前提: aとbは更新する値で, 初期値はL_0, L_1を仮定する
let rec solve origN a b decN =
    if origN = 0L then 2L
    elif origN = 1L then 1L
    elif decN = 2L then a+b
    else solve origN b (a+b) (decN-1L)
let N = stdin.ReadLine() |> int64
solve N 2L 1L N |> printfn "%d"

solve 5L 2L 1L 5L |> should equal 11L
solve 86L 2L 1L 86L |> should equal 939587134549734843L
