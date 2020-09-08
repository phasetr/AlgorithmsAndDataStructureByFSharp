// https://atcoder.jp/contests/aising2020/tasks/aising2020_c
// TLE
let solve n =
    let num = (n |> double |> sqrt) |> ceil |> int
    [| for x in 1 .. num do
        for y in 1 .. num do
            for z in 1 .. num do
                x * x + y * y + z * z + x * y + y * z + z * x = n |]
    |> Array.filter id
    |> Array.length

//[| 1 .. 20 |]
//|> Array.map solve
//|> Array.iter (printfn "%d")

[<EntryPoint>]
let main argv =
    stdin.ReadLine()
    |> int
    |> fun x -> [| 1 .. x |]
    |> Array.map solve
    |> Array.iter (printfn "%d")
    0
