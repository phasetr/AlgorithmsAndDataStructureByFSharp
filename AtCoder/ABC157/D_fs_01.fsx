// https://atcoder.jp/contests/abc157/submissions/11163231
open System
open System.Collections.Generic

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

type Graph = ResizeArray<int> array

let main () =
  let (N, M, K) = readInts () |> triple

  let friends =
    let g = Array.init N (fun _ -> ResizeArray<int>())
    for _ in 1..M do
      let (A, B) = readInts() |> Array.map dec |> pair
      g.[A].Add B
      g.[B].Add A
    g

  let blocks =
    [ for _ in 1..K -> readInts() |> Array.map dec |> pair ]

  let (group, groupCount) =
    let seen = Array.create N false
    let group = Array.zeroCreate N

    let rec dfs root node =
      if seen.[node] then 0
      else
        seen.[node] <- true
        group.[node] <- root
        1 + (friends.[node].ToArray() |> Array.sumBy (fun c -> dfs root c))

    let result = Array.init N (fun n -> dfs n n)
    let groupCount = Array.init N (fun i -> result.[group.[i]])
    (group, groupCount)

  let result =
    let r =
      groupCount
      |> Array.mapi (fun i c -> c - 1 - friends.[i].Count)
    blocks
    |> List.iter (fun (c, d) ->
      if group.[c] = group.[d] then do
        Array.modify r c dec
        Array.modify r d dec
    )
    r

  result
  |> Array.iter (printf "%d ")

main()
