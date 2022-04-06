// https://atcoder.jp/contests/cf16-final/submissions/19179748
#r "nuget: FsUnit"
open FsUnit

let solve N =
    let rec frec i sum =
        let newSum = sum + i
        if newSum >= N then (i, newSum - N)
        else frec (i + 1) newSum
    frec 1 0
    |> function
        | (i,0) -> [1..i]
        | (i,diff) -> List.filter (fun x -> x<>diff) [1..i]
let N = stdin.ReadLine() |> int64
solve N |> List.map stdout.WriteLine

solve 4 |> should equal [1;3]
solve 7 |> should equal [1;2;4]
solve 1 |> should equal [1]
solve 9997155 |> List.max |> should equal 4471
