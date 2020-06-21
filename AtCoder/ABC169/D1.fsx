// https://atcoder.jp/contests/ABC169/submissions/14034100 を完全にそのまま
open System

let n = int64 (stdin.ReadLine())
let sq = int64 (Math.Sqrt(double (n)))

let mutable x = n
let mutable cnt = 0

for i in 2L .. sq do
    let mutable k = i
    while x % k = 0L do
        x <- x / k
        cnt <- cnt + 1
        k <- k * i

    // 確認：この処理は何か？ i 自身が素数だった時の処理のようだが
    while x % i = 0L do
        x <- x / i

// 確認：この処理は何か？
if x > 1L then cnt <- cnt + 1

printfn "%i" cnt
