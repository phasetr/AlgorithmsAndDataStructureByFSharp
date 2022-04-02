@"https://atcoder.jp/contests/abc144/tasks/abc144_d
* 入力は全て整数
* 1 ≤ a \leq 100
* 1 ≤ b \leq 100
* 1 ≤ x ≤ a^2b"
#r "nuget: FsUnit"
open FsUnit

@"
  [a,b,x] <- map read . words <$> getLine
  let r2d x = x * 180 / pi
  print $ if x <= a^2*b / 2
          then r2d $ atan (a * b^2 / 2 / x)
          else r2d $ atan $ 2 * (a^2 * b - x) / (a^3)
"
let a,b,x = 2,2,4
let solve a b x =
    let vol x = x * 180.0 / System.Math.PI
    if x <= a*a*b/2.0 then atan (a*b*b/2.0/x) |> vol
    else atan (2.0*(a*a*b - x)/(a*a*a)) |> vol
let a,b,x = stdin.ReadLine().Split() |> Array.map float |> (fun x -> x.[0], x.[1], x.[2])
solve a b x |> stdout.WriteLine

let near0 x y = (abs (x-y)) < 0.0000001
near0 (solve 2.0 2.0 4.0) 45.0000000000 |> should equal true
near0 (solve 12.0 21.0 10.0) 89.7834636934 |> should equal true
near0 (solve 3.0 1.0 8.0) 4.2363947991 |> should equal true
