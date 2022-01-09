@"https://atcoder.jp/contests/abc150/submissions/17187517"
let N = stdin.ReadLine() |> int
let P = stdin.ReadLine().Split() |> Array.map int |> Array.toList
let Q = stdin.ReadLine().Split() |> Array.map int |> Array.toList

let rec dist element = function
  | []    -> [[element]]
  | head::tail ->
    //printfn "ele=%A h=%A t=%A" element head tail
    let l = [for ys in dist element tail -> head::ys]
    (element::head::tail)::l

let rec permute = function
  | []    -> [[]]
  | head::tail ->
    List.collect (dist head) (permute tail)

let list = [1..N] |> permute |> List.sort
let pNum = (list |> List.findIndex(fun x -> x = P))
let qNum = (list |> List.findIndex(fun x -> x = Q))
abs(pNum - qNum) |> printfn "%d"
