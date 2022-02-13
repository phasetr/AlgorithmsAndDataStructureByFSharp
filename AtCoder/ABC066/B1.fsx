@"https://atcoder.jp/contests/abc066/tasks/abc066_b
2 \leq |S| \leq 200
S は小文字のアルファベットのみからなる偶文字列である。
S に対して、条件を満たす 1 文字以上の文字列が存在する。"
#r "nuget: FsUnit"
open FsUnit

@"長い方から考えるために作る添字の配列を工夫する.
奇数番目は調べる必要がないためはじめから飛ばす."
let solve S =
    [|((String.length S)-2)..(-2)..1|]
    |> Array.find (fun i -> S.[0..(i/2-1)] = S.[(i/2)..(i-1)])
let S = stdin.ReadLine()
solve S |> stdout.WriteLine

solve "abaababaab" |> should equal 6
solve "xxxx" |> should equal 2
solve "abcabcabcabc" |> should equal 6
solve "akasakaakasakasakaakas" |> should equal 14
