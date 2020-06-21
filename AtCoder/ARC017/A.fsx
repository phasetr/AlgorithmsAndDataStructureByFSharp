// cf. Library/Primes.fsx
// https://atcoder.jp/contests/arc017/tasks/arc017_1
// https://qiita.com/drken/items/a14e9af0ca2d857dad23#問題-1-素数判定
let rec primes origN m a =
    if origN < a * a then
        if m = 1L then [] else [ origN ]
    elif m % a <> 0L then
        let aPlus = if a = 2L then 3L else a + 2L
        primes origN m aPlus
    else
        let rec inner n acc =
            if n % a <> 0L then (n, acc) else inner (n / a) (acc + 1L)

        let aPlus = if a = 2L then 3L else a + 2L
        let (m1, c) = inner m 0L
        c :: primes origN m1 aPlus

let primeFactors n = primes n n 2L

let isPrime n = primeFactors n = [ n ]

let n = stdin.ReadLine() |> int64

(if isPrime n then "YES" else "NO")
|> printfn "%s"
