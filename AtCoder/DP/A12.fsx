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

let solve N (Ha:int[]) =
    let f (c2,c1,h2,h1) h =
        let c = min (c2 + abs (h-h2)) (c1 + abs(h-h1))
        (c1,c,h1,h)
    ((0,abs (Ha.[0]-Ha.[1]),Ha.[0],Ha.[1]), Ha.[2..])
    ||> Array.scan f
    |> Array.last |> fun (_,c,_,_) -> c
let N = stdin.ReadLine() |> int
let Ha = stdin.ReadLine().Split() |> Array.map int
solve N Ha |> stdout.WriteLine

solve 4 [|10;30;40;20|] |> should equal 30
solve 2 [|10;10|] |> should equal 0
solve 6 [|30;10;60;10;60;50|] |> should equal 40
