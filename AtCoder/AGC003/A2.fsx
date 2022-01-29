@"https://atcoder.jp/contests/agc003/submissions/18226727"
#r "nuget: FsUnit"
open FsUnit

let solve S =
    let n = S |> Seq.filter (fun c -> c = 'N') |> Seq.length
    let w = S |> Seq.filter (fun c -> c = 'W') |> Seq.length
    let s = S |> Seq.filter (fun c -> c = 'S') |> Seq.length
    let e = S |> Seq.filter (fun c -> c = 'E') |> Seq.length
    let p1 = (n > 0 && s > 0) || (n = 0 && s = 0)
    let p2 = (w > 0 && e > 0) || (w = 0 && e = 0)
    if p1 && p2 then "Yes" else "No"
let S = stdin.ReadLine()
solve S |> stdout.WriteLine

solve "SENW" |> should equal "Yes"
solve "NSNNSNSN" |> should equal "Yes"
solve "NNEW" |> should equal "No"
solve "W" |> should equal "No"
