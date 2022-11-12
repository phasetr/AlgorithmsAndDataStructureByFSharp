// https://atcoder.jp/contests/abc133/submissions/24818447
let N = stdin.ReadLine() |> int
let A = stdin.ReadLine().Split() |> Array.map int64
let Sum = Array.sum A
let ans = Array.init N (fun _ -> 0L)
let mutable A0 = 0L
for i in 1..2..N-1 do A0 <- A0 + A.[i]

ans.[0] <- Sum - (A0) * 2L
for i in 1..N-1 do ans.[i] <- 2L * A.[i-1] - ans.[i-1]

for i in 0..N-2 do printf "%d " ans.[i]
printfn "%d" ans.[N-1]
