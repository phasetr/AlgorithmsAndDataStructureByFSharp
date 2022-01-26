@"https://atcoder.jp/contests/abc104/submissions/18844232"
#r "nuget: FsUnit"
open FsUnit

let isLower c = (c >= 'a') && (c <='z')

let solve S =
    let N = Array.length S
    let check1 =
        S.[0] = 'A'
    let check2 =
        S.[2..(N - 2)]
        |> Array.filter ((=) 'C')
        |> Array.length
        |> (=) 1
    let check3 =
        S
        |> Array.filter isLower
        |> Array.length
        |> (=) (N - 2)
    if (check1 && check2 && check3) then "AC" else "WA"

stdin.ReadLine().ToCharArray() |> solve |> stdout.WriteLine
