// https://atcoder.jp/contests/abc160/submissions/12850484
let [| N; X; Y |] = stdin.ReadLine().Split() |> Array.map int

let result = Array.zeroCreate<int> N

let rec solver i j =
    if i = N then ()
    elif j = N + 1 then solver (i + 1) (i + 2)
    else
        let d1 = j - i
        let d2 = abs (X - i) + abs (Y - j) + 1
        let d = min d1 d2
        result.[d] <- result.[d] + 1
        solver i (j + 1)

solver 1 2

for i in [ 1..N - 1 ] do
    result.[i] |> stdout.WriteLine
