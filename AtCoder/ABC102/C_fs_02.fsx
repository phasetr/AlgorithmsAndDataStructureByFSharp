// https://atcoder.jp/contests/abc102/submissions/2783376
let n = int (stdin.ReadLine())
let a = stdin.ReadLine().Split() |> Array.mapi (fun i x -> int64 x - int64 i - 1L) |> Array.sort
let b = if n % 2 = 0 then (a.[n / 2] + a.[n / 2 - 1]) / 2L else a.[n / 2]
printfn "%d" (Array.sumBy (fun x -> abs (x - b)) a)
