(*
素因数分解
https://atcoder.jp/contests/ABC169/tasks/abc169_d
https://atcoder.jp/contests/ABC169/submissions/13872716
*)
type Factor = { Number: int64; Count: int }

/// origN: 入力値
/// m: origN を割っていった値でどんどん小さくなる
/// a: 2L からインクリメントしていく値
let rec primes origN m a =
    // sqrt N 以下の値だけ調べればいい部分を表現
    if origN < a * a then
        if m = 1L then [] else [ { Number = origN; Count = 1 } ] // 最終的に素数と分かったとき
    elif m % a <> 0L then
        let aPlus = if a = 2L then 3L else a + 2L
        primes origN m aPlus
    else
        /// n: primes オリジナルの引数 m を a でどんどん割っていく
        /// acc: 割り切った回数のカウンター
        let rec inner n acc =
            if n % a <> 0L then (n, acc) else inner (n / a) (acc + 1)

        let (m1, c) = inner m 0
        // 1 番最初に 2L で呼んでいるため a >= 3 以上では
        // m がすでに因数として 2 はもっていない。
        // 2 より大きい偶数を考えても仕方ないので奇数だけ考える
        let aPlus = if a = 2L then 3L else a + 2L
        { Number = a; Count = c }
        :: (primes origN m1 aPlus)

(*
primeFactors 24L
primeFactors 1L
primeFactors 64L
primeFactors 1000000007L
primeFactors 997764507000L
*)
let primeFactors n = primes n n 2L

(*
素数判定
https://atcoder.jp/contests/arc017/tasks/arc017_1
https://qiita.com/drken/items/a14e9af0ca2d857dad23#問題-1-素数判定
*)

let isPrime n =
    primeFactors n = [ { Number = n; Count = 1 } ]
