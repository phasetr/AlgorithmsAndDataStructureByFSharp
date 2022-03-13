@"https://atcoder.jp/contests/abc072/tasks/arc082_b
- 2≤N≤10^5
- p_1,p_2,..,p_N は 1,2,..,N の順列である。"
#r "nuget: FsUnit"
open FsUnit

@"まず全体をチェックする.
条件をみたさない数が隣り合う場合は単純な入れ替えの一回で済む.
遠くにある場合はそれぞれを入れ替える.

解説から:
先頭から順番に見て箇所 i に x があったら i と i + 1
(i = N なら i − 1 と i) を swap すればよく,
この回数を数える."
let solve N Pa =
    let Ba = Pa |> Array.mapi (fun i p -> if i+1=p then true else false)
    ((0, Ba), [|0..(N-1)|])
    ||> Array.fold (fun (num,Aa) i ->
        if Aa.[i] then
            if i = N-1 then () else Array.set Aa (i+1) false
            (num+1, Aa)
        else (num, Aa))
    |> fst
let N = stdin.ReadLine() |> int
let Pa = stdin.ReadLine().Split() |> Array.map int
solve N Pa |> stdout.WriteLine

solve 5 [|1;4;3;5;2|] |> should equal 2
solve 2 [|1;2|] |> should equal 1
solve 2 [|2;1|] |> should equal 0
