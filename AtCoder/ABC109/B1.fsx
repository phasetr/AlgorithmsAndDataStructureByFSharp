@"https://atcoder.jp/contests/abc109/tasks/abc109_b
高橋くんは今日も 1 人でしりとりの練習をしています。
しりとりとは以下のルールで遊ばれるゲームです。

はじめ、好きな単語を発言する
以降、次の条件を満たす単語を発言することを繰り返す
その単語はまだ発言していない単語である
その単語の先頭の文字は直前に発言した単語の末尾の文字と一致する
高橋くんは、10 秒間にできるだけ多くの単語を発言する練習をしています。

高橋くんが発言した単語の個数 N と
i 番目に発言した単語 Wi が与えられるので、
どの発言もしりとりのルールを守っていたかを判定してください。

制約
N は 2≤N≤100 を満たす整数である
W_i は英小文字からなる長さ 1 以上 10 以下の文字列である"
#r "nuget: FsUnit"
open FsUnit

let chk: string * bool -> string -> string * bool = fun acc s ->
    if snd acc then (s, Seq.head s = Seq.last (fst acc))
    else (s, false)
let solve N (Ws: array<string>) =
    if Ws.Length <> Set.count (set Ws) then ("false end", false)
    else Array.fold chk (Ws |> Array.head |> Seq.head |> string, true) Ws
    |> (fun (_, b) -> if b then "Yes" else "No")
let N = stdin.ReadLine() |> int
let Ws = [| for i in 1..N do (stdin.ReadLine()) |]
solve N Ws |> printfn "%s"

solve 4 [|"hoge";"english";"hoge";"enigma"|] |> should equal "No"
solve 9 [|"basic";"c";"cpp";"php";"python";"nadesico";"ocaml";"lua";"assembly"|] |> should equal "Yes"
solve 8 [|"a";"aa";"aaa";"aaaa";"aaaaa";"aaaaaa";"aaa";"aaaaaaa";|] |> should equal "No"
solve 3 [|"abc";"arc";"agc"|] |> should equal "No"
