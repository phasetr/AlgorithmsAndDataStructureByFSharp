// https://atcoder.jp/contests/agc023/submissions/28265564
let _ = stdin.ReadLine()

let a =
    stdin.ReadLine().Split() |> Array.map int64

let ans =
    a
    |> Array.scan (fun acc x -> acc + x) 0L
    |> Array.countBy id
    |> Array.map (fun (_, x) -> int64 x)
    |> Array.map (fun x -> x * (x - 1L) / 2L)
    |> Array.sum

printfn "%i" ans
