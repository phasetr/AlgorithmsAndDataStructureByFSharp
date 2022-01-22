@"https://atcoder.jp/contests/abc139/tasks/abc139_c
左右一列に N 個のマスが並んでいます。

左から i 番目のマスの高さは Hi です。
あなたは好きなマスに降り立ち、
右隣のマスの高さが今居るマスの高さ以下である限り右隣のマスへ移動し続けます。
最大で何回移動できるでしょうか。

制約
入力は全て整数である。
1≤N≤10^5
1≤Hi≤10^9"
#r "nuget: FsUnit"
open FsUnit

let f (x, tmp, acc) y =
    if x >= y then (y, tmp+1L, max (tmp+1L) acc)
    else (y, 0L, max tmp acc)
let solve N Hs =
    Hs
    |> Array.fold f (0L,0L,0L)
    |> fun (_,_,m) -> m

let N = stdin.ReadLine() |> int
let Hs = stdin.ReadLine().Split() |> Array.map int64
solve N Hs |> printfn "%d"

solve 5 [|10L;4L;8L;7L;3L|] |> should equal 2
solve 7 [|4L;4L;5L;6L;6L;5L;5|] |> should equal 3
solve 4 [|1L;2L;3L;4L|] |> should equal 0
