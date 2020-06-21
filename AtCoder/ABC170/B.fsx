// https://atcoder.jp/contests/abc170/tasks/abc170_b
let fb (input: int []) =
    let x = input.[0]
    let y = input.[1]
    [| for i in [ 0 .. x ] do
        yield 2 * i + 4 * (x - i) |]
    |> Array.filter (fun a -> a = y)
    |> Array.length
    |> fun x -> if x > 0 then "Yes" else "No"

//for i in [| [| 3; 8 |]; [| 2; 100 |]; [| 1; 2 |] |] do fd i |> printfn "%s"

[<EntryPoint>]
let main argv =
    let input = stdin.ReadLine().Split(' ') |> Array.map int
    fb input |> printfn "%s"
    0
