@"https://atcoder.jp/contests/abc140/tasks/abc140_c
問題文
長さ N の値の分からない整数列 A があります。
長さ N−1 の整数列 B が与えられます。
このとき、
B_i≥max(A_i,A_{i+1})
が成立することが分かっています。
A の要素の総和として考えられる値の最大値を求めてください。

制約
入力は全て整数
2≤N≤100
0≤B_i≤10^5"
#r "nuget: FsUnit"
open FsUnit

let solve N Bs =
    Bs
    |> Array.fold (fun (x, acc) y -> (y, acc + (min x y))) (Bs.[0], 0)
    |> fun (a,b) -> a + b
let N = stdin.ReadLine() |> int
let Bs = stdin.ReadLine().Split() |> Array.map int
solve N Bs |> stdout.WriteLine

solve 3 [|2;5|] |> should equal 9
solve 2 [|3|] |> should equal 6
solve 6 [|0;153;10;10;23|] |> should equal 53
