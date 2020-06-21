// https://atcoder.jp/contests/abc170/tasks/abc170_b
let s = [| 1; 0; 3; 4; 5 |]
s |> Array.findIndex (fun x -> x = 0)

[<EntryPoint>]
let main argv =
    let s = stdin.ReadLine().Split(' ') |> Array.map int
    let num = s |> Array.findIndex (fun x -> x = 0)
    printfn "%d" (num + 1)
    0
