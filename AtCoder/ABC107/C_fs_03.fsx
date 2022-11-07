// https://atcoder.jp/contests/abc107/submissions/36153664
let [| n; k |] = stdin.ReadLine().Split() |> Array.map int
let x = stdin.ReadLine().Split() |> Array.map int

{ 0 .. n - k }
|> Seq.map (fun i ->
    if x.[i + k - 1] <= 0 then
        -x.[i]
    elif 0 <= x.[i] then
        x.[i + k - 1]
    else
        (min -x.[i] x.[i + k - 1]) * 2
        + (max -x.[i] x.[i + k - 1]))
|> Seq.min
|> stdout.WriteLine
