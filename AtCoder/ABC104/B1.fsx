@"https://atcoder.jp/contests/abc104/tasks/abc104_b
問題文
文字列 S が与えられます。
S のそれぞれの文字は英大文字または英小文字です。
S が次の条件すべてを満たすか判定してください。

S の先頭の文字は大文字の A である。
S の先頭から 3 文字目と末尾から 2 文字目の間（両端含む）に大文字の C がちょうど 1 個含まれる。
以上の A, C を除く S のすべての文字は小文字である。

制約
4≤∣S∣≤10 （∣S∣ は文字列 S の長さ）
S のそれぞれの文字は英大文字または英小文字である。"
#r "nuget: FsUnit"
open FsUnit

let solve (S: string) =
    if Seq.head S = 'A' then
        let S2 =
            S.[2..(S.Length-2)]
            |> Seq.choose (fun c -> if c = 'C' then Some c else None)
        if Seq.length S2 = 1 then
            S
            |> Seq.tail
            |> Seq.filter (fun c -> c <> 'C')
            |> Seq.fold (fun acc x -> if acc && System.Char.IsLower x then true else false) true
            |> fun b -> if b then "AC" else "WA"
        else "WA"
    else "WA"
let S = stdin.ReadLine()
solve S |> stdout.WriteLine

solve "AtCoder" |> should equal "AC"
solve "ACoder" |> should equal "WA"
solve "AcycliC" |> should equal "WA"
solve "AtCoCo" |> should equal "WA"
solve "Atcoder" |> should equal "WA"
