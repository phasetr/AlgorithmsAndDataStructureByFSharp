module ABC169 =
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

module FsSnip =
    // http://www.fssnip.net/3X
    let isPrime n =
        let sqrt' = (float >> sqrt >> int) n // square root of integer
        [| 2 .. sqrt' |] // all numbers from 2 to sqrt'
        |> Array.forall (fun x -> n % x <> 0) // no divisors

    let allPrimes =
        let rec allPrimes' n =
            seq { // sequences are lazy, so we can make them infinite
                if isPrime n then
                    yield n
                yield! allPrimes' (n+1) // recursing
            }
        allPrimes' 2 // starting from 2

    allPrimes
    |> Seq.take 20 // only 20
    |> Array.ofSeq // forces evaluation of first 20 items

module StackOverflowSieve =
    // https://stackoverflow.com/questions/1097411/learning-f-printing-prime-numbers#answer-1097596
    let rec sieve = function
        | (p::xs) -> p :: sieve [ for x in xs do if x % p > 0 then yield x ]
        | []      -> []
    let primes = sieve [2..50]
    printfn "%A" primes  // [2; 3; 5; 7; 11; 13; 17; 19; 23; 29; 31; 37; 41; 43; 47]

module StackOverflowPrime1 =
    let twoAndOdds n =
        Array.unfold (fun x -> if x > n then None else if x = 2 then Some(x, x + 1) else Some(x, x + 2)) 2
    // twoAndOdds 15 |> printfn "%A" //  [|2; 3; 5; 7; 9; 11; 13; 15|]

    // https://stackoverflow.com/questions/1097411/learning-f-printing-prime-numbers#answer-35966305
    let infSeq (limit: int64) =
        seq {
            yield 2L
            let mutable i = 3L
            let mutable l = 3L
            while l < limit do // この制約を入れないと f i がオーバーフローしてひどいことになったことがある。
                let a = i
                yield a
                i <- i + 2L
                l <- i
        }

    let isprime x =
        infSeq x
        |> Seq.takeWhile (fun i -> i * i <= x)
        |> Seq.forall (fun i -> x % i <> 0L)
