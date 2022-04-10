@"https://atcoder.jp/contests/dp/tasks/dp_b
問題文
N 個の足場があります。
足場には 1,2,…,N と番号が振られています。
各 i (1≤i≤N) について、足場 i の高さは hi です。
最初、足場 1 にカエルがいます。
カエルは次の行動を何回か繰り返し、足場 N まで辿り着こうとしています。

足場 i にいるとき、足場 i+1,i+2,…,i+K のどれかへジャンプする。
このとき、ジャンプ先の足場を j とすると、コスト |hi − hj| を支払う。
カエルが足場 N に辿り着くまでに支払うコストの総和の最小値を求めてください。

制約
入力はすべて整数である。
2≤N≤10^5
1≤K≤100
1≤hi≤10^4"
#r "nuget: FsUnit"
open FsUnit

let solve N K (Ha:int[]) = 1
let N,K = stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0], x.[1]
let Ha = stdin.ReadLine().Split() |> Array.map int
solve N K Ha |> stdout.WriteLine

solve 5 3 [|10;30;40;50;20|] |> should equal 30
solve 3 1 [|10;20;10|] |> should equal 20
solve 2 100 [|10;10|] |> should equal 0
solve 10 4 [|40;10;20;70;80;10;20;70;80;60|] |> should equal 40
