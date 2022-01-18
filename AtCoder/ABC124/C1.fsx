@"
問題文
左右一列に N 枚のタイルが並んでおり、
各タイルの初めの色は長さ N の文字列 S で表されます。
左から i 番目のタイルは、S の i 番目の文字が 0 のとき黒色で、
1 のとき白色で塗られています。

あなたは、いくつかのタイルを黒色または白色に塗り替えることで、
どの隣り合う 2 枚のタイルも異なる色で塗られているようにしたいです。

最小で何枚のタイルを塗り替えることで条件を満たすようにできるでしょうか。

制約
1≤∣S∣≤10^5
S_i は 0 または 1 である。
入力
入力は以下の形式で標準入力から与えられる。
S
出力
条件を満たすために塗り替えるタイルの枚数の最小値を出力せよ。"
#r "nuget: FsUnit"
open FsUnit

let flip c = if c = '0' then '1' else '0'
let rec right n h acc =
    if n = 0 then
        if acc = [] then [h] else (List.rev acc)
    else right (n-1) (flip h) (h::acc)
// 正しい形は「白黒白...」または「黒白黒...」の二通りしかなく,
// これとどれだけずれているかをカウントする
let solve S =
    let n = Seq.length S
    let h = Seq.head S
    let r = right n h []
    (0, S, r) |||> Seq.fold2 (fun acc a b ->
        match (a,b) with
        | '0', '0' | '1', '1' -> acc
        | _ -> acc + 1)
let S = stdin.ReadLine()
solve S |> printfn "%d"

right 3 '0' [] |> should equal ['0';'1';'0']
right 8 '1' [] |> should equal ['1';'0';'1';'0';'1';'0';'1';'0']
right 0 '0' [] |> should equal ['0']
solve "000" |> should equal 1
solve "10010010" |> should equal 3
solve "0" |> should equal 0
