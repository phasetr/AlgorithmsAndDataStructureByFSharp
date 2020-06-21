// オリジナル https://atcoder.jp/contests/ABC169/submissions/13872716
// 自分にとってわかるようにコメントを加えつつ微修正
open System

/// origN: 入力値
/// m: origN を割っていった値でどんどん小さくなる
/// a: 2L からインクリメントしていく値
let rec primes origN m a =
    if origN < a * a then
        if m = 1L then [] else [ 1 ] // 最終的に素数と分かったとき
    elif m % a <> 0L then
        primes origN m (a + 1L)
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
        c :: (primes origN m1 aPlus)

/// 問題指定のアルゴリズム A で割った回数を計算する
/// e: p^e の e
/// c: アルゴリズム A の枠組みで割った回数
/// もともと p^{e} だったとして再帰が進むと素べきが p^{e-c} になる
let rec cnt e c =
    if e >= c then 1 + (cnt (e - c) (c + 1)) else 0

let fd n =
    primes n n 2L
    |> List.fold (fun st x -> st + (cnt x 1)) 0
    |> printfn "%d"

let isDev = false

if isDev then
    fd 24L
    fd 1L
    fd 64L
    fd 1000000007L
    fd 997764507000L
else
    let n = stdin.ReadLine() |> int64
    fd n
