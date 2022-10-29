// https://atcoder.jp/contests/abc160/submissions/24749268
let [|N;X;Y|] = stdin.ReadLine().Split() |> Array.map int
let mutable Dist = [|for i in 1..N-1 -> 0|]
for i in 1..N-1 do
    for j in i+1 .. N do
        let ixjy = abs (i - X) + abs (j - Y) + 1
        let iyjx = abs (i - Y) + abs (j - X) + 1
        min ixjy iyjx
        |> min (j - i)
        |> fun x -> Dist.[x-1] <- Dist.[x-1] + 1

Dist
|> Array.map (printfn "%d")

