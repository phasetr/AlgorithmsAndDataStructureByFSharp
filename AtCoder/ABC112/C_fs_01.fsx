// https://atcoder.jp/contests/abc112/submissions/9943734
let n = stdin.ReadLine() |> int
let points =
    [|1..n|] |> Array.map (
        fun _ ->
            let xyh = stdin.ReadLine().Split() |> Array.map int
            let (x, y, h) = (xyh.[0], xyh.[1], xyh.[2])
            (x, y, h)
    )

for i in [|0..100|] do
    for j in [|0..100|] do
        let ch = points |> Array.map (fun (x, y, h) -> h + (i - x |> abs) + (j - y |> abs)) |> Array.min
        if points |> Array.forall (fun (x, y, h) -> (ch - (i - x |> abs) - (j - y |> abs) |> max 0) = h) then
            printf "%d %d %d" i j ch
