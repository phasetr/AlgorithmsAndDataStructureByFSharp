// # Multiples of 3 and 5
// ## Problem 1
// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
// Find the sum of all the multiples of 3 or 5 below 1000.
//
// 1000 未満の 3 と 5 の倍数のすべての和を計算せよ。

[| 3 .. 999 |]
|> Array.filter (fun x -> x % 3 = 0 || x % 5 = 0)
|> Array.sum
