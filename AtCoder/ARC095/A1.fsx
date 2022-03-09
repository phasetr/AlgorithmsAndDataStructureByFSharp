@"https://atcoder.jp/contests/abc094/tasks/arc095_a
2 \leq N \leq 200000
N は偶数
1 \leq X_i \leq 10^9
入力はすべて整数"
#r "nuget: FsUnit"
open FsUnit

@"素直に全探索したら時間切れ.
最初に入力をソートしておいて中央値の候補c1=a.[N/2], c2=a.[N/2 + 1]を取る.
配列の各要素ごとにc1より小さければc2を,
c1より大きければc1を取る."
let solve N Xa =
    let (c1,c2) =
        Array.sort Xa
        |> fun xa -> xa.[(N-1)/2], xa.[(N-1)/2 + 1]
    Xa |> Array.map (fun x -> if x<=c1 then c2 else c1)

let N = stdin.ReadLine() |> int
let Xa = stdin.ReadLine().Split() |> Array.map int
solve N Xa |> Array.map string |> String.concat "\n" |> stdout.WriteLine

solve 4 [|2;4;4;3|] |> should equal [|4;3;3;4|]
solve 2 [|1;2|] |> should equal [|2;1|]
solve 6 [|5;5;4;4;3;3|] |> should equal [|4;4;4;4;4;4|]
