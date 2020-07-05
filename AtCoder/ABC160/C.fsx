// https://atcoder.jp/contests/abc160/tasks/abc160_c
let judge k (a: int []) =
    let slice s e a = Array.sub a s (e - s + 1)

    Array.append a [| k + a.[0] |]
    |> Array.pairwise // 小区間の端点のペアを作る
    |> Array.map (fun (s, e) -> e - s |> abs) // 各区間の長さを取る
    |> Array.sort // ソートして最長区間を最後に回す
    |> slice 0 (a.Length - 2) // 最長区間を除く
    |> Array.sum // 全区間の和を取る

//let input = [| 20, 3, [| 5; 10; 15 |]; 20, 3, [| 0; 5; 15 |] |]
//let k, _, a = input.[1]
//for (k, _, a) in input do judge k a |> printfn "%d"
// expected 10; 10

[<EntryPoint>]
let main argv =
    let k =
        stdin.ReadLine().Split() |> fun x -> x.[0] |> int

    let a =
        stdin.ReadLine().Split() |> Array.map int

    judge k a |> printfn "%d"
    0
