@"https://atcoder.jp/contests/agc037/submissions/17236741"
#r "nuget: FsUnit"
open FsUnit

@"TLE
let rec solve (S: string) beforeStr nowIdx acc =
    if S = "" || S = beforeStr then acc
    elif nowIdx = 100 then -1
    else
        if beforeStr = S.[..nowIdx] then solve S beforeStr (nowIdx+1) acc
        else solve S.[(nowIdx+1)..] S.[..nowIdx] 0 (acc+1)"
@"解説から: 分割数が最大になる分割は部分文字列の長さが全て2か1で,
これをうまいこと選ぶ."

let s = "ABC"
s.Length

@"解説2から:
与えられた文字列 S = s_1s_2...s_Nに対して求める解をf(S)とし,
g(i) = f(s_1s_2...s_i)とすると,
漸化式
g(i) = g(i-3) + 2 (s_1 = s_{i-1})
g(i) = g(i-1) + 1 (s_1 \neq s_{i-1})
が示せる."
let solve (S: string) =
    let rec f i g =
        if i >= S.Length then g+1+S.Length-i
        elif S.[i] = S.[i-1] then f (i+3) (g+2)
        else f (i+1) (g+1)
    f 1 0

let S = stdin.ReadLine()
solve S |> stdout.WriteLine

solve "aabbaa" |> should equal 4
solve "aaaccacabaababc" |> should equal 12
