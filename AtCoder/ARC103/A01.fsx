@"https://atcoder.jp/contests/abc111/tasks/arc103_a
* 2 \leq n \leq 10^5
* n は偶数
* 1 \leq v_i \leq 10^5
* v_i は整数"
#r "nuget: FsUnit"
open FsUnit

@"奇数番目と偶数番目の最頻値を取ってそれで置き換えればよい.
ただしそれが一致する場合は次の最頻値を取る必要がある."
let solve N (Va:array<int>) =
    let n = N/2
    let iVa = Va |> Array.indexed
    let modes f = iVa |> Array.choose (fun (i,v) -> if f i then Some v else None) |> Array.countBy id |> Array.sortByDescending snd
    let evenModes = modes (fun n -> n%2=0)
    let oddModes = modes (fun n -> n%2=1)
    if evenModes.[0] <> oddModes.[0] then 2*n - (snd evenModes.[0]) - (snd oddModes.[0])
    else
        if Array.length evenModes = 1 && Array.length oddModes = 1 then n
        elif Array.length evenModes = 1 then n - (snd oddModes.[1])
        elif Array.length oddModes = 1 then n - (snd evenModes.[1])
        else min (2*n - (snd oddModes.[0]) - (snd evenModes.[1])) (2*n - (snd oddModes.[1]) - (snd evenModes.[0]))
let N = stdin.ReadLine() |> int
let Va = stdin.ReadLine().Split() |> Array.map int
solve N Va |> stdout.WriteLine

solve 4 [|3;1;3;2|] |> should equal 1
solve 6 [|105;119;105;119;105;119|] |> should equal 0
solve 4 [|1;1;1;1|] |> should equal 2
