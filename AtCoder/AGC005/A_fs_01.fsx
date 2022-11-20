// https://atcoder.jp/contests/agc005/submissions/36529108
let x = stdin.ReadLine()

x
|> Seq.fold
    (fun (s, len) ->
        function
        | 'S' -> (s + 1, len)
        | 'T' when s > 0 -> (s - 1, len - 2)
        | _ -> (s, len))
    (0, x.Length)
|> snd
|> stdout.WriteLine
