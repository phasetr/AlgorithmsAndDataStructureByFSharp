// https://atcoder.jp/contests/abc084/submissions/11894417
open System

// prelude
let readStr () = stdin.ReadLine()

let readInt () = stdin.ReadLine() |> int
let readInts () = stdin.ReadLine().Split() |> Array.map int

let pair = function
| [|a; b|] -> (a, b)
| _ -> failwith "owatta"

let triple = function
| [|a; b; c|] -> (a, b, c)
| _ -> failwith "owatta"

let inc n = n + 1
let dec n = n - 1

let inline flip f a b = f b a
let rec fix f = fun x -> (f (fix f)) x

module Option =
  let getOr defaultValue = function
  | Some x -> x
  | None -> defaultValue

module Array =
  let modify (arr: _ []) i f =
    arr.[i] <- f arr.[i]

module Array2D =
  let modify (arr: _ [,]) i j f =
    arr.[i, j] <- f arr.[i, j]

// start

let N=101010
let isPrime =
  let primes = Array.create N true
  primes.[0] <- false
  primes.[1] <- false
  for p in 0..(N-1) do
    if primes.[p] then do
      let rec go i =
        if i>=N then ()
        else
          primes.[i]<-false
          go (i+p)
      go (2*p)
  Array.get primes

let like2017sum =
  let s=Array.init N (fun n -> if n%2=1 && isPrime n && isPrime ((n+1)/2) then 1 else 0)
  for i in 1..(N-1) do
    Array.modify s i ((+) s.[i-1])
  fun l r -> s.[r]-s.[l-1]

let Q = readInt()
for _ in 1..Q do
  let (l,r) = readInts() |> pair
  like2017sum l r
  |> printfn "%d"
