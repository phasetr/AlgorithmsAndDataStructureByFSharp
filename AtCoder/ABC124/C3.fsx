@"https://atcoder.jp/contests/abc124/submissions/17010939"
#r "nuget: FsUnit"
open FsUnit

let solve S =
    let blackOrWhite (b, w, i) c =
        if i % 2 = c then (b + 1, w, i + 1) else (b, w + 1, i + 1)
    S
    |> Array.ofSeq
    |> Array.map (string >> int)
    |> Array.fold blackOrWhite (0, 0, 0)
    |> fun (b, w, _) -> min b w

let S = stdin.ReadLine()
solve S |> stdout.WriteLine

solve "000" |> should equal 1
solve "10010010" |> should equal 3
solve "0" |> should equal 0
