// https://atcoder.jp/contests/abc121/tasks/abc121_b
[<EntryPoint>]
let main argv =
    let input = stdin.ReadLine().Split(' ') |> Array.map int
    let n = input.[0]
    let c = input.[2]
    let arrB = stdin.ReadLine().Split(' ') |> Array.map int

    let mutable count = 0
    for i in [0..n-1] do
        let tmpCount =
            stdin.ReadLine().Split(' ') |> Array.map int
            |> Array.map2 (*) arrB
            |> fun a -> if (Array.sum a) + c > 0 then 1 else 0
        count <- count + tmpCount
    count |> printfn "%d"
    0
