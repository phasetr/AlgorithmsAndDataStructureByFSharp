@"https://atcoder.jp/contests/abc059/submissions/17365259"
#r "nuget: FsUnit"
open FsUnit

let solve A B =
    ((bigint.Parse A) - (bigint.Parse B)).Sign
    |> function
        | 1 -> "GREATER"
        | -1 -> "LESS"
        | _ -> "EQUAL"

let A = stdin.ReadLine()
let B = stdin.ReadLine()
solve A B |> printfn "%s"

solve "36" "24" |> should equal "GREATER"
solve "850" "3777" |> should equal "LESS"
solve "9720246" "22516266" |> should equal "LESS"
solve "123456789012345678901234567890" "234567890123456789012345678901" |> should equal "LESS"

