@"https://atcoder.jp/contests/agc022/tasks/agc022_a
* 1 \leq |S| \leq 26
* S は多彩な単語である。"
#r "nuget: FsUnit"
open FsUnit

@"入力例4でわかるように,
単純に最後に文字をつけ加えればいいわけではない.
最大26文字の制限もある.
ただし25文字までなら単純に文字の追加でよい.

解説から:
S = p1p2p3...p26 として,
文字が降順に並んだ最長のSの接尾辞をpipi+1...p26とする.
i=1 のときSは辞書順で最も大きい多彩な単語だから答えは −1.
2<=iのときpi, pi+1, ..., p26 のうち pi−1 より大きい文字の中で最も小さい文字を q として,
辞書順で次の多彩な文字列は p1p2...pi−2qである."
let S = "atcoder"
let S = "abcdefghijklmnopqrstuvwzyx"
let solve (S:string) =
    let rec frec xs = function
        | [] -> []
        | c::cs ->
            let f = xs |> List.filter ((<) c) |> List.sort
            if List.isEmpty f then frec (c::xs) cs
            else (List.head f :: cs) |> List.rev
    if Seq.length S <= 25 then
        let c = Set.difference (set ['a'..'z']) (set S) |> Seq.head
        S + (string c)
    elif S = "zyxwvutsrqponmlkjihgfedcba" then "-1"
    else
        frec [] (S |> Seq.rev |> Seq.toList)
        |> fun s -> if List.isEmpty s then "-1" else (Syss |> List.map string |> String.concat "")
let S = stdin.ReadLine()
solve S |> stdout.WriteLine

solve "atcoder" |> should equal "atcoderb"
solve "abc" |> should equal "abcd"
solve "zyxwvutsrqponmlkjihgfedcba" |> should equal "-1"
solve "abcdefghijklmnopqrstuvwzyx" |> should equal "abcdefghijklmnopqrstuvx"
