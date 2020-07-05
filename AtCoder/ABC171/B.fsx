//https://atcoder.jp/contests/abc171/tasks/abc171_b
let judge k ps =
    ps
    |> Array.sort
    |> fun x -> x.[..k - 1] |> Array.sum
//let input = [| 5, 3, [| 50; 100; 80; 120; 80|]; 1, 1, [|1000|] |]
//for (_,k,ps) in input do (judge k ps |> printfn "%d")
// expected 210; 1000
[<EntryPoint>]
let main argv =
    let _, k =
        stdin.ReadLine().Split()
        |> fun x -> x.[0], int x.[1]

    let ps =
        stdin.ReadLine().Split() |> Array.map int

    judge k ps |> printfn "%d"
    0
