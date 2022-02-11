@"https://atcoder.jp/contests/ddcc2020-qual/tasks/ddcc2020_qual_b"
#r "nuget: FsUnit"
open FsUnit

let solve N As =
    let s = Array.sum As
    ((0L, s),As) ||> Array.scan (fun (accl, accr) a -> (accl+a, accr-a))
    |> Array.fold (fun acc (l,r) -> min acc (abs (l-r))) s

let N = stdin.ReadLine() |> int
let As = stdin.ReadLine().Split() |> Array.map int64
solve N As |> stdout.WriteLine

solve 3 [|2L;4L;3L|] |> should equal 3L
solve 12 [|100L;104L;102L;105L;103L;103L;101L;105L;104L;102L;104L;101L|] |> should equal 0L
