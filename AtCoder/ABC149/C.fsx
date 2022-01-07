(*
   https://atcoder.jp/contests/abc149/tasks/abc149_c
   問題文
   X 以上の素数のうち、最小のものを求めよ。

   注記
   素数とは、2 以上の整数であって、1 と自分自身を除くどの正の整数でも割り切れないようなもののことです。

   例えば、2,3,5 は素数ですが、4,6 は素数ではありません。

   制約
   2≤X≤10
   5

   入力はすべて整数
   入力
   入力は以下の形式で標準入力から与えられる。

   X
   出力
   X 以上の素数のうち、最小のものを出力せよ。
   *)
#r "nuget: FsUnit"
open FsUnit

// http://www.fssnip.net/3X
let isPrime n =
    let intSqrt = (float >> sqrt >> int) n // square root of integer

    [| 2 .. intSqrt |] // all numbers from 2 to intSqrt
    |> Array.forall (fun x -> n % x <> 0) // no divisors

let allPrimes =
    let rec recAllPrimes n =
        seq {
            if isPrime n then yield n
            yield! recAllPrimes (n + 1) // recursing
        }

    recAllPrimes 2 // starting from 2

let solve n =
    let order =
        allPrimes
        |> Seq.takeWhile (fun x -> x < n)
        |> Seq.length

    allPrimes
    |> Seq.take (order + 1)
    |> Array.ofSeq
    |> Array.last

stdin.ReadLine() |> int |> solve |> printfn "%d"

solve 20 |> should equal 23
solve 2 |> should equal 2
solve 99992 |> should equal 100003
