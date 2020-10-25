// # 10001st prime
// - [URL](https://projecteuler.net/problem=7)
// ## Problem 7
// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
// What is the 10 001st prime number?
//
// はじめの 6 個の素数をリストすると 6 番目の素数が 13 であることがわかる。
// 10001 番の素数は何か？

// このコードは正しくない
// このまま進めていてもあまりよろしくない雰囲気なので新しいアルゴリズムを考える

let isprime x =
    let infSeq =
        seq {
            yield 2L
            let mutable i = 3L
            while true do // この制約を入れないと f i がオーバーフローしてひどいことになったことがある。
                yield i
                i <- i + 2L
        }
    infSeq
    |> Seq.takeWhile (fun i -> i * i <= x)
    |> Seq.forall (fun i -> x % i <> 0L)

let infSeq =
    seq {
        let mutable num = 2L
        let mutable order = 1
        yield (num, order)
        while true do
            num <- num + 1L
            if isprime num then
                order <- order + 1
                yield (num, order)
    }

let n = 10001
infSeq |> Seq.filter (fun x -> snd x |> fun x -> x = n)
infSeq |> Seq.map (printfn "%A")
