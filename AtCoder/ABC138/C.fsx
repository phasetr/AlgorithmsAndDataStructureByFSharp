// https://atcoder.jp/contests/abc138/tasks/abc138_c
//let input = [| [| 3; 4 |]; [| 500; 300; 200 |]; [| 138; 138; 138; 138; 138 |] |]
//for i in input do (i |> Array.map double |> Array.sort |> Array.reduce (fun x y -> (x + y) / (2.0 |> double)))
//input.[1]
//|> Array.map double
//|> Array.sort
//|> Array.reduce (fun x y -> (x + y) / (2.0 |> double))

[<EntryPoint>]
let main argv =
    stdin.ReadLine() |> ignore
    stdin.ReadLine().Split()
    |> Array.map double
    |> Array.sort
    |> Array.reduce (fun x y -> (x + y) / 2.0)
    |> printfn "%A"
    0
