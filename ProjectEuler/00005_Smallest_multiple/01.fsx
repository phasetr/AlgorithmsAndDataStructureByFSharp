// # Smallest multiple
// - [URL](https://projecteuler.net/problem=5)
// ## Problem 5
// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
//
// 2520 は 1 から 10 の各数で割り切れる最小の数である。
// 1 から 20 のすべての数で割り切れる最小の正の数は何か？

// 最小公倍数を求めればいい
// 小さい方から 2 数の最小公倍数を求めていってそれを積めば終わる。

let rec gcd a b =
    let (s, l) = if a < b then (a, b) else (b, a)
    let r = l % s
    if r = 0L then s else gcd r s

let lcm a b = a * b / (gcd a b)

[| 1L .. 10L |] |> Array.fold lcm 1L
[| 1L .. 20L |] |> Array.fold lcm 1L
