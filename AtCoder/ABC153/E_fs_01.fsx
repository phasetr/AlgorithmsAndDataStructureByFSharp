// https://atcoder.jp/contests/abc153/submissions/11237244
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

let inline memo size f =
  let dp = Array.create size None
  let rec g x =
    match dp.[x] with
    | None ->
      let v = f g x
      dp.[x] <- Some v
      v
    | Some v -> v
  g

// start
let (H, N) = readInts() |> pair
let AB =
  let ab = Array.zeroCreate N
  for i in 0..(N-1) do
    ab.[i] <- readInts() |> pair
  ab

let cost = memo 10009 <| fun cost h ->
  AB |> Array.fold (fun prev (a, b) -> min prev (b + if h<=a then 0 else cost (h-a))) 100000000

cost H |> printfn "%d"
