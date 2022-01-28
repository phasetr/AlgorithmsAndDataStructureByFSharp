@"https://atcoder.jp/contests/abc103/tasks/abc103_b
問題文
英小文字からなる文字列 S, T が与えられます。
S を回転させて T に一致させられるか判定してください。
すなわち、以下の操作を任意の回数繰り返して
S を T に一致させられるか判定してください。

操作: S=S1S2...S∣S∣のとき、
S を S_{|S∣}S_1S2...S_{∣S∣−1} に変更する
ここで、∣X∣ は文字列 X の長さを表します。

制約
2≤∣S∣≤100
∣S∣=∣T∣
S, T は英小文字からなる"
#r "nuget: FsUnit"
open FsUnit

let s = "kyoto" |> Seq.toArray |> Array.map string
let T = "tokyo"
[|0..(Seq.length s - 1)|]
|> Array.map (fun i -> Array.append s.[i..] s.[0..(i-1)] |> String.concat "" |> fun x -> x = T)
|> Array.exists id

let solve S T =
    let s = S |> Seq.toArray |> Array.map string
    // 再帰で逐一確認した方がおそらく少し速い
    [|0..(Seq.length s - 1)|]
    |> Array.map (fun i -> Array.append s.[i..] s.[0..(i-1)] |> String.concat "" |> fun x -> x = T)
    |> Array.exists id
    |> fun x -> if x then "Yes" else "No"

let S = stdin.ReadLine()
let T = stdin.ReadLine()
solve S T |> stdout.WriteLine

solve "kyoto" "tokyo" |> should equal "Yes"
solve "abc" "arc" |> should equal "No"
solve "aaaaaaaaaaaaaaab" "aaaaaaaaaaaaaaab" |> should equal "Yes"
