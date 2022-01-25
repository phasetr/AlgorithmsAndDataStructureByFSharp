@"https://atcoder.jp/contests/abc158/tasks/abc158_c
問題文
消費税率が 8%のとき A 円、
10％のとき B 円の消費税が課されるような商品の税抜き価格を求めてください。

ただし、税抜き価格は正の整数でなければならないものとし、
消費税の計算において小数点以下は切り捨てて計算するものとします。

条件を満たす税抜き価格が複数存在する場合は最も小さい金額を出力してください。
また、条件を満たす税抜き価格が存在しない場合は -1 と出力してください。

制約
1≤A≤B≤100
A,B は整数である"
#r "nuget: FsUnit"
open FsUnit

let solve A B =
    let takeoutTax x = (double x) * 0.08 |> floor |> int
    let defaultTax x = (double x) * 0.1 |> floor |> int
    let chk x = (takeoutTax x) = A && (defaultTax x) = B
    [0..10000]
    |> List.choose (fun x -> if chk x then Some x else None)
    |> fun x -> if List.isEmpty x then -1 else List.min x

let A, B = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
solve A B |> stdout.WriteLine

solve 2 2 |> should equal 25
solve 8 10 |> should equal 100
solve 19 99 |> should equal -1
