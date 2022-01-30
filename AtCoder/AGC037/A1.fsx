@"https://atcoder.jp/contests/agc037/tasks/agc037_a
問題文
英小文字からなる文字列 S が与えられます。
以下の条件をみたす最大の正整数 K を求めてください。

S の空でない K 個の文字列への分割 S=S1S2...SKであって
Si \neq S_{i+1} (1≦i≦K−1) を満たすものが存在する。
ただし、S1,S2,...,SKをこの順に連結して得られる文字列のことを
S1S2...SK によって表しています。

制約
1≦∣S∣≦2×10^5
S は英小文字からなる"
#r "nuget: FsUnit"
open FsUnit

let solve (S: string) =
    let rec f = function
        | [] -> 0
        | [x] -> 1
        | [x;y] -> if x = y then 1 else 2
        | x::y::z::ws ->
            if x <> y then f (y::z::ws) + 1
            else (f ws) + 2
    S |> Seq.toList |> f
let S = stdin.ReadLine()
solve S |> stdout.WriteLine

solve "aabbaa" |> should equal 4
solve "aaaccacabaababc" |> should equal 12
