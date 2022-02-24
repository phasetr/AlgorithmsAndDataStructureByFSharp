@"https://atcoder.jp/contests/abc082/tasks/abc082_b
s, t の長さは 1 以上 100 以下である。
s, t は英小文字のみからなる。"
#r "nuget: FsUnit"
open FsUnit

@"厳密な不等号がポイント.
sは最小の構成で, tは最大の構成でソートして比べればいい."
let solve s t =
    let s' = s |> Seq.sort |> Seq.map string |> String.concat ""
    let t' = t |> Seq.sortDescending |> Seq.map string |> String.concat ""
    if s' < t' then "Yes" else "No"

let s = stdin.ReadLine()
let t = stdin.ReadLine()
solve s t |> stdout.WriteLine

solve "yx" "axy" |> should equal "Yes"
solve "ratcode" "atlas" |> should equal "Yes"
solve "cd" "abc" |> should equal "No"
solve "w" "ww" |> should equal "Yes"
solve "zzz" "zzz" |> should equal "No"
