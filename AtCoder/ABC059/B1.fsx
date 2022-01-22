@"https://atcoder.jp/contests/abc059/tasks/abc059_b
問題文
2 つの正整数 A,B が与えられるので、その大小を比較してください。

制約
1≦A,B≦10^{100}

入力の A,B の先頭は0でない。"
#r "nuget: FsUnit"
open FsUnit

let rec solve (A: string) (B: string) =
    let aLength = String.length A
    let bLength = String.length B
    if aLength < bLength then "LESS"
    elif bLength < aLength then "GREATER"
    else
        if aLength = 0 then "EQUAL"
        elif A.[0] < B.[0] then "LESS"
        elif B.[0] < A.[0] then "GREATER"
        else solve A.[1..] B.[1..]

let A = stdin.ReadLine()
let B = stdin.ReadLine()
solve A B |> printfn "%s"

solve "36" "24" |> should equal "GREATER"
solve "850" "3777" |> should equal "LESS"
solve "9720246" "22516266" |> should equal "LESS"
solve "123456789012345678901234567890" "234567890123456789012345678901" |> should equal "LESS"
