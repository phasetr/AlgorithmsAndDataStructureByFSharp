// https://atcoder.jp/contests/abc141/submissions/12858786
let [| N; M |] = stdin.ReadLine().Split() |> Array.map int
let A = stdin.ReadLine().Split() |> Array.map int64
let mutable As = Set.ofArray (Array.zip A [| 1..N |])

for _ in [ 1..M ] do
    let (v, i) as a = Set.maxElement As
    As <- As |> Set.remove a
    As <- As |> Set.add (v / 2L, i)

As
|> Set.fold (fun sum (v, i) -> sum + v) 0L
|> stdout.WriteLine
