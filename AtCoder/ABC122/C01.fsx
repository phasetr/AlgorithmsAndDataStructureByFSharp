@"https://atcoder.jp/contests/abc122/tasks/abc122_c
* 2 \leq N \leq 10^5
* 1 \leq Q \leq 10^5
* S は長さ N の文字列である。
* S の各文字は A, C, G, T のいずれかである。
* 1 \leq l_i < r_i \leq N"
#r "nuget: FsUnit"
open FsUnit

@"解説から:
範囲内の部分文字列 AC を数えるのではなく「右隣がCであるA」を数える.
文字列中のこのような A を a に置き換えると,
問 i は「li 文字目から ri − 1 文字目までの a を数えよ」に変わる.
ここで右端が 1 つ左に動いている点に注意する.
次にti =「S の 1 文字目から i 文字目までに出現する a の数」として,
数列 t = {t0, t1, . . . , tN } を考えれば,
問 i の答えは t_{ri−1} − t_{li−1} として求められる."
let N,Q,S,Aa = 8,3,"ACACTACG",[|(3,7);(2,3);(1,8)|]
let solve N Q S Aa =
    let ts =
        S
        |> Seq.pairwise
        |> Seq.map (fun (c1,c2) -> if (c1,c2) = ('A','C') then 'a' else 'Z')
        |> Seq.scan (fun acc c -> if c='a' then acc+1 else acc) 0
        |> Array.ofSeq
    Aa |> Array.map (fun (li,ri) -> ts.[ri-1] - ts.[li-1])
let N, Q = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let S = stdin.ReadLine()
let Aa = [| for i in 1..Q do (stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1]) |]
solve N Q S Aa |> Array.map string |> String.concat "\n" |> stdout.WriteLine

solve 8 3 "ACACTACG" [|(3,7);(2,3);(1,8)|] |> should equal [|2;0;3|]

@"TLEしたコード."
let TLESolver N Q S Aa =
    let sub i n = Seq.skip i >> Seq.take n
    let slice s e = sub s (e - s + 1)
    let toString (c1,c2) = [|string c1; string c2|] |> String.concat ""
    let chkSubstr (li,ri) =
        slice (li-1) (ri-1) S
        |> Seq.pairwise
        |> Seq.map toString
        |> Seq.filter ((=) "AC")
        |> Seq.length
    Aa |> Array.map chkSubstr
