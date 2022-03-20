@"https://atcoder.jp/contests/panasonic2020/tasks/panasonic2020_c
- 1 \leq a, b, c \leq 10^9
- 入力は全て整数である。"
#r "nuget: FsUnit"
open FsUnit

@"ルートの精度の問題があるので二乗して整数でチェックする."
let solve a b c =
    let d = c-a-b
    if 0L<d && 4L*a*b < pown d 2 then "Yes" else "No"
let a,b,c = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1], x.[2])
solve a b c  |> stdout.WriteLine

solve 2L 3L 9L |> should equal "No"
solve 2L 3L 10L |> should equal "Yes"
