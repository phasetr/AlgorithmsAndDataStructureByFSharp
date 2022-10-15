// https://atcoder.jp/contests/abc148/submissions/9088260
let n = stdin.ReadLine() |> int64

let rec pre x = (if x < 1L then 1L else 5L * pre (x - 1L))
let p x = 2L * (pre x)

let ans = [for i in 1L..25L -> (n / (p i))] |>List.sum

if (n % 2L) = 0L then ans else 0L
|>stdout.WriteLine
