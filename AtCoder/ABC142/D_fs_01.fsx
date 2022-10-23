// https://atcoder.jp/contests/abc142/submissions/7794564
let rec gcd n m = if m = 0L then n else gcd m (n % m)

let rec factorize (acc : int64 list) (i : int64) (n : int64) =
    if n <= 1L then
        acc
    else if n < (i * i) then
        n :: acc
    else if n % i = 0L then
        factorize (i :: acc) i (n / i)
    else factorize acc (i + 1L) n

let ab = System.Console.ReadLine().Split()
let a = ab.[0] |> int64
let b = ab.[1] |> int64
let g = gcd a b
let ans = factorize [] 2L g |> List.distinct |> List.length |> (+) 1
printfn "%d" ans

