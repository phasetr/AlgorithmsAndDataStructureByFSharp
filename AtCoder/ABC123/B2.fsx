@"https://atcoder.jp/contests/abc123/submissions/20135376"
#r "nuget: FsUnit"
open FsUnit

let oneceil i = ((i+9) / 10) * 10
let firstDigit i = (10 - i%10) % 10
let solve A B C D E =
    let xs = [|A;B;C;D;E|]
    Array.sum (Array.map oneceil xs) - Array.max (Array.map firstDigit xs)

let A = stdin.ReadLine() |> int
let B = stdin.ReadLine() |> int
let C = stdin.ReadLine() |> int
let D = stdin.ReadLine() |> int
let E = stdin.ReadLine() |> int
solve A B C D E |> printfn "%d"

solve 29 20 7 35 120 |> should equal 215
solve 101 86 119 108 57 |> should equal 481
solve 123 123 123 123 123 |> should equal 643
