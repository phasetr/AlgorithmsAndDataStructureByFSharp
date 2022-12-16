// https://atcoder.jp/contests/abc080/submissions/24579550
let N = stdin.ReadLine() |> int
let shop = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int)
let P = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int64)

let mutable ans = -1000000000L
let pat = (1 <<< 11) - 1

for i in 0..pat do
    let mutable c = 0
    let mutable time = Array.init N (fun _ -> 0)
    for j in 0..9 do
        let bit = i >>> j &&& 1
        c <- c + bit
        if bit = 1
        then
            for k in 0..N-1 do
                time.[k] <- time.[k] + shop.[k].[j]
    if c <> 0 then
        let mutable kari = 0L
        for j in 0..N-1 do
            kari <- kari + P.[j].[time.[j]]
        ans <- max ans kari

printfn "%d" ans
