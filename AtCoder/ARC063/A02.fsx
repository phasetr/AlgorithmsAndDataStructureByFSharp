@"https://atcoder.jp/contests/abc047/submissions/28257282"
#r "nuget: FsUnit"
open FsUnit

let solve = Seq.pairwise >> Seq.filter (<>) >> Seq.length
let S = stdin.ReadLine()
solve S |> stdout.WriteLine

solve "BBBWW" |> should equal 1
solve "WWWWWW" |> should equal 0
solve "WBWBWBWBWB" |> should equal 9
