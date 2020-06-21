// https://atcoder.jp/contests/abc088/tasks/abc088_b
// sol2 https://qiita.com/kuuso1/items/606b75c172cafa1d07f6
let input = [| 2; 7; 4 |]

let rec takeForAlice xs =
    match xs with
    | [] -> 0
    | [ x ] -> x
    | _ -> xs.[0] + takeForAlice xs.[2..]

let totalSum = input |> Array.sum

let aliceSum =
    input
    |> Array.sortBy (~-)
    |> Array.toList
    |> takeForAlice

let bobSum = totalSum - aliceSum
printfn "%d" (aliceSum - bobSum)
