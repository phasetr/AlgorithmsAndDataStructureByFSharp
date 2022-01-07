// https://atcoder.jp/contests/abc149/submissions/9213961
open System
let x = stdin.ReadLine() |> int

let isPrime n =
    match n with
    | _ when n > 3 && (n % 2 = 0 || n % 3 = 0) -> false
    | _ ->
        let maxDiv = int (System.Math.Sqrt(float n)) + 1

        let rec f d i =
            if d > maxDiv then true
            else if n % d = 0 then false
            else f (d + i) (6 - i)

        f 5 2

let rec p n =
    match n with
    | s when isPrime s -> s
    | t -> p (t + 1)

p x |> stdout.WriteLine
