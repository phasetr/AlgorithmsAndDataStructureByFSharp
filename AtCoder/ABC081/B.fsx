(*
https://atcoder.jp/contests/abc081/tasks/abc081_b
https://qiita.com/kuuso1/items/606b75c172cafa1d07f6 から
*)
let rec divNumBy2 n x: int =
    if x % 2 = 0 then divNumBy2 (n + 1) (x / 2) else n
let fb = Array.map (divNumBy2 0) >> Array.min

//let input = [| [| 8; 12; 40|]; [| 5; 6; 8; 10|]; [| 382253568; 723152896; 37802240; 379425024; 404894720; 471526144 |] |]
//for i in input do fb i |> printfn "%d"
// expected: 2; 0; 8

[<EntryPoint>]
let main argv =
    stdin.ReadLine() |> ignore
    stdin.ReadLine().Split(' ') |> Array.map int |> fb |> printfn "%A"
    0
