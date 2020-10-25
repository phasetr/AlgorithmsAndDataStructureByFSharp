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

// 01.fsx の回文判定がださすぎるので書き換え

// 回文判定関数
let rev =
    Seq.toArray >> Array.rev >> System.String

// 二重ループで出てくる i, j の積を取り、回文数ならその値を返し、それ以外は 0 を返す
let local i j =
    let num = i * j
    let numStr = num |> string
    if numStr = (rev numStr) then num else 0

// 本体関数 solve 中の fold で使う関数。
// 計算した量 loc とある i の時点で最大だった値を比較して大きい方を返す。
let takeNewMax loc tmpMax = if loc < tmpMax then tmpMax else loc

// i を食わせて j in [|i..999|] のループを回すメインの再帰関数。
let rec solve i max =
    let newMax =
        Array.fold (fun x j -> takeNewMax (local i j) x) max [| i .. 999 |]

    if i < 999 then solve (i + 1) newMax else newMax

solve 100 0 |> printfn "%A"
