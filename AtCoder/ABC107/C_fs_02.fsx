// https://atcoder.jp/contests/abc107/submissions/6229332
let scan2 f = stdin.ReadLine().Split() |> Array.map f |> (fun a -> (a.[0], a.[1]))
let scanVecH f = stdin.ReadLine().Split() |> Array.map f

let n, k = scan2 int
let data = scanVecH int

let f x1 x2 = abs (x2 - x1) + (min (abs x1) (abs x2))

seq { 0..n-k }
|> Seq.map (fun i -> f data.[i] data.[i+k-1])
|> Seq.min
|> printfn "%d"
