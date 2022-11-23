// https://atcoder.jp/contests/diverta2019-2/submissions/11731293m
open System

// prelude
let readStr () = stdin.ReadLine()

let readInt () = stdin.ReadLine() |> int
let readInts () = stdin.ReadLine().Split() |> Array.map int
let readInt64s () = stdin.ReadLine().Split() |> Array.map int64

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
let N=readInt()
let xy=[|for _ in 1..N -> readInt64s() |> pair|]

let r =
  seq {
    for i in 0..(N-1) do
      for j in 0..(N-1) do
        let (x1,y1)=xy.[i]
        let (x2,y2)=xy.[j]
        let (a,b)=(x1-x2,y1-y2)
        if a<>0L||b<>0L then
          yield (a,b)
  }
  |> Seq.fold (fun map x ->
    let v=
      map
      |> Map.tryFind x
      |> Option.getOr 0
    map
    |> Map.add x (v+1)
  ) Map.empty
  |> Map.fold (fun st _ x -> max st x) 0

printfn "%d" (N-r)
