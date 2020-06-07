(*
https://atcoder.jp/contests/abc081/tasks/abc081_b
https://qiita.com/kuuso1/items/606b75c172cafa1d07f6 から
*)
let bTest = "3 4 4".Split(' ')

let rec divNumBy2 n x: int =
    if x % 2 = 0 then divNumBy2 (n + 1) (x / 2) else n

let fb =
    Array.map (int >> divNumBy2 0) >> Array.min

bTest |> fb |> printfn "%A"

let main =
    stdin.ReadLine() |> ignore
    stdin.ReadLine().Split(' ') |> fb |> printfn "%A"
