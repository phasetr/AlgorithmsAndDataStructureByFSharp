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
#r "nuget: FsUnit, 4.1.0"
open NUnit.Framework
open FsUnit

// http://www.fssnip.net/3X
let isPrime n =
  let intSqrt = (float >> sqrt >> int) n // square root of integer
  [| 2 .. intSqrt |] // all numbers from 2 to intSqrt
  |> Array.forall (fun x -> n % x <> 0) // no divisors

let allPrimes =
  let rec recAllPrimes n =
    seq { // sequences are lazy, so we can make them infinite
          if isPrime n then yield n
          yield! recAllPrimes (n+1) // recursing
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

[<EntryPoint>]
let main argv =
  let n = stdin.ReadLine() |> int
  solve n |> printfn "%d"
  0

solve 20 |> should equal 23
solve 2 |> should equal 2
solve 99992 |> should equal 100003

module Solution1 =
  // https://atcoder.jp/contests/abc149/submissions/18539714
  module PrimeNumbers =
    // isPrime - O(N)
    let isPrime num =
        let rec isPrimeR x i =
            match i, x % i with
            | i, _ when i >= x -> true
            | _, 0 -> false
            | i, _ -> isPrimeR x (i + 1)

        isPrimeR num 2

  let x = stdin.ReadLine() |> int
  Seq.initInfinite (fun i -> x + i)
  |> Seq.find PrimeNumbers.isPrime
  |> stdout.WriteLine

module Solution2 =
  // https://atcoder.jp/contests/abc149/submissions/17136669
  let X = stdin.ReadLine() |> int

  let isPrime x =
    let rec inner x i =
      if i*i>=x then true
      elif x%i=0 then false
      else inner x (i+1)
    if x<=1 then false
    else inner x 2

  let rec getPrime i =
    if isPrime i then i else getPrime (i+1)

  X |> getPrime |> stdout.WriteLine

module Solution3 =
  // https://atcoder.jp/contests/abc149/submissions/17004970
  let readInt _ = stdin.ReadLine() |> int

  let isPrime n =
    if n = 1L then
      true
    else
      seq { 2L .. n }
      |> Seq.filter (fun a -> a * a <= n)
      |> Seq.exists (fun x -> n % x = 0L)
      |> not

  ()
  |> readInt
  |> fun x ->
      Seq.initInfinite int64
      |> Seq.skip x
      |> Seq.filter isPrime
      |> Seq.head
      |> printfn "%d"

module Solution4 =
  // https://atcoder.jp/contests/abc149/submissions/12184048
  let X = stdin.ReadLine() |> int

  let inline sqrtInt n =
    n
    |> float
    |> sqrt
    |> int

  let isPrime x =
    let rec loop n =
      if n <= 1 then true
      elif x % n = 0 then false
      else loop (n - 1)
    loop (sqrtInt x)

  let rec resolver x =
    if isPrime x then x
    else resolver (x + 1)

  resolver X |> stdout.WriteLine

module Solution5 =
  // https://atcoder.jp/contests/abc149/submissions/9244890
  let isPrime n =
    if n < 2 then false
    elif n = 2 then true
    else
      let r = n |> float |> sqrt |> ceil |> int
      [for i in 2..r -> n % i = 0] |> List.contains true |> not

  let rec loop n = if isPrime n then n else loop (n + 1)
  stdin.ReadLine() |> int |> loop |> printfn "%d"

module Solution6 =
  // https://atcoder.jp/contests/abc149/submissions/9213961
  open System
  let x = stdin.ReadLine() |> int

  let isPrime n =
    match n with
      | _ when n > 3 && (n % 2 = 0 || n % 3 = 0) -> false
      | _ ->
        let maxDiv = int(System.Math.Sqrt(float n)) + 1
        let rec f d i =
          if d > maxDiv then true
          else
            if n % d = 0 then false
            else f (d + i) (6 - i)
        f 5 2

  let rec p n =
   match n with
   | s when isPrime s -> s
   | t -> p (t + 1)
  p x |>stdout.WriteLine
