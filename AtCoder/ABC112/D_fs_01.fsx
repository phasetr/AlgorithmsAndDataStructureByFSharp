// https://atcoder.jp/contests/abc112/submissions/9943263
let nm = stdin.ReadLine().Split() |> Array.map int
let (n, m) = (nm.[0], nm.[1])
let n,m = 3,14
let possibleMax = m / n;
[|1..(m |> double |> sqrt |> ceil |> int)|]
|> Array.collect (
    fun x ->
        if m % x = 0 then
            [|x; m / x|]
        else
            [||]
)
|> Array.filter (fun x -> x <= possibleMax)
|> Array.max
|> stdout.WriteLine
