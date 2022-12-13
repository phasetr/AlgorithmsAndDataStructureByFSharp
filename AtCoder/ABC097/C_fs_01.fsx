// https://atcoder.jp/contests/abc097/submissions/24387927
let s = stdin.ReadLine()
let K = stdin.ReadLine() |> int

let n = s.Length - 1

[|
    for i in 0..n ->
        [|
            for j in i .. (min n (i+K-1)) ->
                s.[i..j]
        |]
|]
|> fun x ->
    [|
        for i in x do
            for j in i ->
                j
    |]
|> Array.countBy id
|> Array.map (fun (x,_) -> x)
|> Array.sort
|> fun x -> x.[K-1]
|> printfn "%s"
