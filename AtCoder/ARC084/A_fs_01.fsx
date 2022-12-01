// https://atcoder.jp/contests/abc077/submissions/24588722
let N = stdin.ReadLine() |> int
let A = stdin.ReadLine().Split() |> Array.map int |> Array.sort |> Array.rev
let B = stdin.ReadLine().Split() |> Array.map int |> Array.sort |> Array.rev
let C = stdin.ReadLine().Split() |> Array.map int |> Array.sort |> Array.rev

let mutable bcount = [|for _ in 1..N -> 0L|]
let mutable acount = [|for _ in 1..N -> 0L|]
let mutable aindex = [|for _ in 1..N -> 0|]

for i in 0..N-1 do
    let b = B.[i]
    let rec calc index =
        if index = N then (N |> int64)
        elif b >= C.[index] then (index |> int64)
        else calc (index + 1)
    bcount.[i] <- calc (if i = 0 then 0 else (bcount.[i-1] |> int))

for i in 0..N-1 do
    let rec calc index (v:int64) =
        if index = N then (N,v)
        elif A.[i] >= B.[index] then (index,v)
        else calc (index + 1) (v + bcount.[index])
    let t = calc (if i = 0 then 0 else aindex.[i-1]) (if i = 0 then 0L else acount.[i-1])
    aindex.[i] <- fst t
    acount.[i] <- snd t

acount
|> Array.sum
|> printfn "%d"
