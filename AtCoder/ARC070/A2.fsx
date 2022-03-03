@"https://atcoder.jp/contests/abc056/submissions/9675107"
#r "nuget: FsUnit"
open FsUnit

let solve X =
    let rec f x i s =
        if i+s>=x then i else f x (i+1L) (i+s)
    f X 1L 0L
let X = stdin.ReadLine() |> int64
solve X |> stdout.WriteLine

solve 6L  |> should equal 3L
solve 2L  |> should equal 2L
solve 11L |> should equal 5L
