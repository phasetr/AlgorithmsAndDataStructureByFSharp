// # 10001st prime
// - [URL](https://projecteuler.net/problem=7)
// ## Problem 7
// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
// What is the 10 001st prime number?
//
// はじめの 6 個の素数をリストすると 6 番目の素数が 13 であることがわかる。
// 10001 番の素数は何か？

let isprime x =
    let infSeq =
        seq {
            yield 2L
            let mutable i = 3L
            while i * i <= x do // この制約を入れないと f i がオーバーフローしてひどいことになったことがある。
                yield i
                i <- i + 2L
        }
    infSeq
    |> Seq.forall (fun i -> x % i <> 0L)

// 入力として number = 3L, order = 2L 始まりであることを仮定する.
// つまり偶素数 2 は初めから考えない.
let rec solve number order limit =
    if isprime number then
        if order = limit then number
        else
            // 素数だったら次の素数を取るべく number + 2 して素数の順番 order も 1 つ上げる
            solve (number + 2L) (order + 1L) limit
    else
        // 素数ではないので番号だけ 2 つあげる
        solve (number + 2L) order limit

let n = 10001L
solve 3L 2L n |> printfn "%A"
