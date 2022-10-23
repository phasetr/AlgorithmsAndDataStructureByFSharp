// https://atcoder.jp/contests/abc130/submissions/24818243
let [|n;K|] = stdin.ReadLine().Split() |> Array.map int64
let N = n |> int
let A = stdin.ReadLine().Split() |> Array.map int64

let SumArray =
    [|
        let mutable s = 0L
        for i in A ->
            s <- s + i
            s
    |]

let mutable headIndex = 0
let mutable ans = 0L
let rec calc tailIndex =
    if tailIndex = headIndex then ()
    else
        if SumArray.[tailIndex] - SumArray.[headIndex] >= K
        then
            headIndex <- headIndex + 1
            calc tailIndex
        else ()


for tailIndex in 0..N-1 do
    if SumArray.[tailIndex] >= K
    then
        calc tailIndex
        ans <- ans + (headIndex |> int64) + 1L

printfn "%d" ans
