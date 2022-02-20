@"https://atcoder.jp/contests/keyence2019/tasks/keyence2019_b
S の長さは 7 以上 100 以下
S は英小文字のみから成る"
#r "nuget: FsUnit"
open FsUnit

@"文字列は短いから全チェックできる.
keyenceは7文字だから7文字だけ残して真ん中をくり抜く."
let solve (S: string) =
    let len = String.length S
    [S.[0..6]]
    @ ([1..6] |> List.map (fun i -> S.[0..i] + S.[(len-(6-i))..]))
    @ [S.[(len-7)..(len-1)]]
    |> List.fold (fun acc s -> acc || s="keyence") false
    |> fun s -> if s then "YES" else "NO"

let S = stdin.ReadLine()
solve S |> stdout.WriteLine

solve "keyofscience" |> should equal "YES"
solve "mpyszsbznf" |> should equal "NO"
solve "ashlfyha" |> should equal "NO"
solve "keyence" |> should equal "YES"
