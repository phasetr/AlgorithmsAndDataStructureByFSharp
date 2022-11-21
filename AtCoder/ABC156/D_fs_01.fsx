// https://atcoder.jp/contests/abc156/submissions/11167232
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
let M = 1000000007L

let rec pow n m =
  ((if (m&&&1L)=1L then n%M else 1L) * (if m=0L then 1L else (pow ((n*n)%M) (m>>>1))%M))%M

let rec permutation n r = if r=0L then 1L else (n*(permutation (n-1L) (r-1L))%M)%M

let inv a = pow a (M-2L)
let combination n r = ((permutation n r)*(inv (permutation r r)))%M

let (n, a, b) = readStr().Split() |> Array.map int64 |> triple
let r = (pow 2L n)-1L-(combination n a)-(combination n b)

printfn "%d" ((r+2L*M)%M)
