// https://atcoder.jp/contests/panasonic2020/tasks/panasonic2020_b
// 1x1 からはじめて 1 行・1 列ずつ増やしていくと盤面の半分を移動できることが分かる。
// ただし 1xY の形の盤面では初めの位置から動けない。
// 実際に動ける盤面数は積が奇数か偶数かで変わる：具体的に確認すればわかるので、それを反映した実装にする。

[<EntryPoint>]
let main argv =
    let input = stdin.ReadLine().Split(' ') |> Array.map int64
    let h = input.[0]
    let w = input.[1]
    let count =
        if  h = 1L || w = 1L then 1L
        else (h * w + 1L) / 2L
    count |> printfn "%d"
    0
