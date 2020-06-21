// https://atcoder.jp/contests/abc068/submissions/12248999
// 解説通りの解答：最終的に N より小さい中で最大の 2^m の形の数が出てくるから、それを取ればいい
[<EntryPoint>]
let main _ =
    let n = stdin.ReadLine() |> int

    let ans =
        match n with
        | m when m >= 64 -> 64
        | m when m >= 32 -> 32
        | m when m >= 16 -> 16
        | m when m >= 8 -> 8
        | m when m >= 4 -> 4
        | m when m >= 2 -> 2
        | m when m >= 1 -> 1
        | _ -> 0

    stdout.WriteLine ans
    0
