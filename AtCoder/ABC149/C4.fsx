// https://atcoder.jp/contests/abc149/submissions/17136669
let X = stdin.ReadLine() |> int

let isPrime x =
    let rec inner x i =
        if i * i >= x then true
        elif x % i = 0 then false
        else inner x (i + 1)

    if x <= 1 then false else inner x 2

let rec getPrime i =
    if isPrime i then
        i
    else
        getPrime (i + 1)

X |> getPrime |> stdout.WriteLine
