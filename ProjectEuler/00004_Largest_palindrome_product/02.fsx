// # Largest palindrome product
// - [URL](https://projecteuler.net/problem=4)
// ## Problem 4
// A palindromic number reads the same both ways.
// The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
// Find the largest palindrome made from the product of two 3-digit numbers.
//
// 回文数は 2 通りの同じ読み方を持つ。
// 2 桁の数の積からなる最大の回文数は 9009 = 91 x 99 である。
// 3 桁の数の積からなる最大の回文数を求めよ。

// 3 桁の数の積からなるリスト (Sequence) を作る、よろしくない解法

// String の反転
let reverse (s: string) =
    s |> Seq.toArray |> Array.rev |> System.String

// 回文チェック
let palindrome n = let s = string n in s = reverse s

let solve =
    seq {
        for i = 100 to 999 do
            for j = 100 to 999 do
                let p = i * j
                if palindrome p then yield p
    }
    |> Seq.max
    |> printfn "%d"

solve
