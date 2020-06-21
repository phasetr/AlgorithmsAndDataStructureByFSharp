// https://atcoder.jp/contests/agc046/tasks/agc046_a
let judge x =
    Seq.initInfinite (fun k -> (k+1, x * (k+1)))
    |> Seq.filter (fun (i, x) -> x % 360 =0)
    |> Seq.head
    |> fun (i, x) -> i

//for i in [| 90; 1; 7 |] do judge i |> printfn "%d"
// expected 4; 360; 360

[<EntryPoint>]
let main argv =
    let x = stdin.ReadLine() |> int
    judge x |> printfn "%d"
    0
