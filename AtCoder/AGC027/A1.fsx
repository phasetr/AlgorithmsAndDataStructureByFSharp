(*
   https://atcoder.jp/contests/agc027/tasks/agc027_a
   問題文
   N 人の子供がいます。
   子供たちには 1,2,...,N と番号が振られています。
   すぬけ君は、x 個のお菓子を子供たちに配ることにしました。
   このとき、すぬけ君は x 個のお菓子をすべて配り切らなければなりません。 なお、お菓子を貰わない子供がいても構いません。

   各 i (1≤i≤N) について、
   子供 i はちょうどai個のお菓子を貰うと喜びます。
   すぬけ君は、お菓子を配る方法を工夫し、
   喜ぶ子供の人数を最大化しようとしています。
   喜ぶ子供の人数の最大値を求めてください。

   制約
   入力はすべて整数である。
   2≤N≤100
   1≤x≤10^9
   1≤ai≤10^9

   入力
   入力は以下の形式で標準入力から与えられる。
   N x
   a1 a2 ... aN

   出力
   喜ぶ子供の人数の最大値を出力せよ。
   *)
#r "nuget: FsUnit"
open FsUnit

let rec solve n (x: int64) (xs: int64 array) =
    // xsは昇順でソートされているとする: 入力部分に注意
    // 総和でチェックする.
    // より多くの子供に渡すため大きい要素から削る.
    //printfn "%A %A %A" n x xs
    if n = 0 then
        if x = xs.[0] then 1
        else 0
    else
        let a = xs.[..(n - 1)]
        let sum = Array.sum a
        if x = sum then
            n // 総和ちょうどならその値を返す
        elif sum < x then
            // 総和が小さいので全員に渡せるが, 余るので誰かに押しつける
            if n = Array.length xs then
                n - 1 // フル配列で和が小さいので誰かに押し付ける
            else
                n // 既にsumの計算人数が減っているので、和の対象から外れた人に押し付ければよい
        else
            solve (n - 1) x xs // 人数を削って返す

let N, x = stdin.ReadLine().Split() |> fun y -> (int y.[0], int64 y.[1])
let xs = stdin.ReadLine().Split() |> Array.map int64
solve N x (Array.sort xs) |> printfn "%A"

solve 3 70L (Array.sort [| 20L; 30L; 10L |])
|> should equal 2

solve 3 10L (Array.sort [| 20L; 30L; 10L |])
|> should equal 1

solve 4 1111L (Array.sort [| 1L; 10L; 100L; 1000L |])
|> should equal 4

solve 2 10L (Array.sort [| 20L; 20L |])
|> should equal 0
