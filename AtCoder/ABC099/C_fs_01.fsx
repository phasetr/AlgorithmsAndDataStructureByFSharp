// https://atcoder.jp/contests/abc099/submissions/24213416
let mutable N = stdin.ReadLine() |> int

let mutable ans = N
for i in 0..N do
    let mutable c = 0
    let mutable v = i
    while v > 0 do
        c <- c + v % 6
        v <- v / 6
    v <- N - i
    while v > 0 do
        c <- c + v % 9
        v <- v / 9
    if ans > c then
        ans <- c

ans
|> printfn "%d"
