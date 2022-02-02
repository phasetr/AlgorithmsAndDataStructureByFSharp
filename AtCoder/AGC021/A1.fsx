@"https://atcoder.jp/contests/agc021/tasks/agc021_a"
#r "nuget: FsUnit"
open FsUnit

let N = "100"

let solve (N: string) =
    let order = Seq.length N
    let top = (string N.[0] |> int)
    let tails = 9 * (Seq.length N - 1)
    if Seq.replicate (order - 1) "9" |> String.concat "" = N.[1..]
    then top + tails else top + tails - 1
let N = stdin.ReadLine()
solve N |> stdout.WriteLine

solve "100" |> should equal 18
solve "9995" |> should equal 35
solve "3141592653589793" |> should equal 137
