// https://atcoder.jp/contests/abc068/submissions/12293996

let rec f =
    function
    | 1 -> 1
    | x -> 2 * f (x / 2)

// 63 / 2 // 31
// 31 / 2 // 15
// 15 / 2 // 7
// 7 / 2 // 3
// 3 / 2 // 1

[<EntryPoint>]
let main argv =
    let n = stdin.ReadLine() |> int
    f n |> printfn "%d"
    0
