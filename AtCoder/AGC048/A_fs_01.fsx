// https://atcoder.jp/contests/agc038/submissions/36149175
let [| h; w; a; b |] = stdin.ReadLine().Split() |> Array.map int

{ 0 .. h - 1 }
|> Seq.map (fun i ->
    { 0 .. w - 1 }
    |> Seq.map (fun j ->
        match i < b, j < a with
        | true, true
        | false, false -> '1'
        | _ -> '0')
    |> System.String.Concat)
|> Seq.iter stdout.WriteLine
