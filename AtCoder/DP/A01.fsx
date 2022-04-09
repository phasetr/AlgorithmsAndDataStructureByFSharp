@"https://atcoder.jp/contests/dp/tasks/dp_a
問題文
N 個の足場があります。
足場には 1,2,…,N と番号が振られています。
各 i (1≤i≤N) について、足場 i の高さは hi です。

最初、足場 1 にカエルがいます。
カエルは次の行動を何回か繰り返し、足場 N まで辿り着こうとしています。

足場 i にいるとき、足場 i+1 または i+2 へジャンプする。
このとき、ジャンプ先の足場を j とすると、コスト ∣h_i−h_j∣ を支払う。

カエルが足場 N に辿り着くまでに支払うコストの総和の最小値を求めてください。

制約
入力はすべて整数である。
2≤N≤10^5
1≤hi≤10^4"
#r "nuget: FsUnit"
open FsUnit

@"https://atcoder.jp/contests/dp/submissions/26333135
[i-2]のコスト
[i-1]のコスト
h[i-2]
h[i-1]
(h[i]:...)"
let solve N hs =
    let rec loop c2 c1 h2 h1 = function
    | [] -> c1
    | h::tail ->
        let c = min (c2 + abs(h2-h)) (c1 + abs(h1-h))
        loop c1 c h1 h tail
    let h2::h1::h3s = Array.toList hs
    loop 0 (abs (h2-h1)) h2 h1 h3s

let N = stdin.ReadLine() |> int
let hs = stdin.ReadLine().Split() |> Array.map int
solve N hs |> stdout.WriteLine

solve 4 [|10;30;40;20|] |> should equal 30
solve 2 [|10;10|] |> should equal 0
solve 6 [|30;10;60;10;60;50|] |> should equal 40
