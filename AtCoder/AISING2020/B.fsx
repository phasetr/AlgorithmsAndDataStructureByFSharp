// https://atcoder.jp/contests/aising2020/tasks/aising2020_b
let solve =
    Array.mapi (fun i x -> i % 2 = 0 && x % 2 = 1)
    >> Array.filter id
    >> Array.length

// [|1; 3; 4; 5; 7|] |> solve
// [|13;76;46;15;50; 98; 93; 77; 31; 43; 84; 90; 6; 24; 14|] |> solve

[<EntryPoint>]
let main argv =
    stdin.ReadLine() |> ignore
    stdin.ReadLine().Split()
    |> Array.map int
    |> solve
    |> printfn "%d"
    0
