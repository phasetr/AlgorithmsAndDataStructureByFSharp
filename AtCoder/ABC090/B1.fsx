@"https://atcoder.jp/contests/abc090/tasks/abc090_b
問題文
A 以上 B 以下の整数のうち、回文数となるものの個数を求めてください。
ただし、回文数とは、先頭に 0 をつけない 10 進表記を文字列として見たとき、
前から読んでも後ろから読んでも同じ文字列となるような正の整数のことを指します。

制約
10000≤A≤B≤99999
入力はすべて整数である"
#r "nuget: FsUnit"
open FsUnit

let above2 x = x/1000
let below2Rev x = (x % 10) * 10 + (x % 100) / 10
let ispal x = above2 x = below2Rev x
let solve A B = [|A..B|] |> Array.filter ispal |> Array.length

let A, B = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
solve A B |> printfn "%d"

above2 11011 |> should equal 11
above2 12011 |> should equal 12
below2Rev 11011 |> should equal 11
below2Rev 11012 |> should equal 21
solve 11009 11332 |> should equal 4
solve 31415 92653 |> should equal 612
