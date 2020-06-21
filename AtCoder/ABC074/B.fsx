// https://atcoder.jp/contests/abc074/tasks/abc074_b
let judge k = Array.sumBy (fun x -> 2 * min (abs x) (abs (x-k)))

//let input = [| 1, 10, [| 2 |]; 2, 9, [|3; 6|]; 5, 20, [| 11; 12; 9; 17; 12|] |]
//for (_, k, xs) in input do judge k xs |> printfn "%d"
// expected 4; 12; 74

[<EntryPoint>]
let main argv =
    stdin.ReadLine() |> ignore
    let k = stdin.ReadLine() |> int
    let xs = stdin.ReadLine().Split() |> Array.map int
    judge k xs |> printfn "%d"

    0
