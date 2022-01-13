@"問題文
Atcoder国では、郵便番号は A+B+1 文字からなり、
A+1 文字目はハイフン -、
それ以外の全ての文字は 0 以上 9 以下の数字です。

文字列 S が与えられるので、
Atcoder国の郵便番号の形式を満たすかどうか判定してください。

制約
1≦A,B≦5
∣S∣=A+B+1
S は 0 以上 9 以下の数字、およびハイフン - からなる"
#r "nuget: FsUnit"
open System
open System.IO
open FsUnit

let solve A B (S: string) =
    if S.[A] <> '-' || (Seq.contains '-' S.[0..(A-1)]) || (Seq.contains '-' S.[(A+1)..])
    then "No" else "Yes"

let A, B = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let S = stdin.ReadLine()
solve A B S |> printfn "%s"

solve 3 4 "269-6650" |> should equal "Yes"
solve 1 1 "---" |> should equal "No"
solve 1 2 "7444" |> should equal "No"
