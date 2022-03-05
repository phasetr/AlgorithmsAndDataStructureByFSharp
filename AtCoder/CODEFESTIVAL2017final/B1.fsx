@"https://atcoder.jp/contests/cf17-final/tasks/cf17_final_b
1 \leq |S| \leq 10^5
S は a、b、c 以外の文字を含まない。"
#r "nuget: FsUnit"
open FsUnit

@"解説から.
2⽂字以上の回⽂が含まれない
=2⽂字または3⽂字の回⽂が含まれなければよい.
偶数⽂字の回⽂には中⼼に2⽂字の回⽂が含まれ,
奇数⽂字の回⽂には中⼼に3⽂字の回⽂が含まれる.
同じ⽂字が2⽂字以上離れていればよい.
⽂字が3種類しかないため'abcabcabc...' のように3⽂字周期の⽂字列しかありえず,
各⽂字の出現回数の差が1以下であれば可能."
let S = "abac"
let solve S =
    S |> Seq.countBy id
    |> Seq.fold (fun acc (c,num) ->
        if c='a' then Array.set acc 0 num
        elif c='b' then Array.set acc 1 num
        else Array.set acc 2 num
        acc) [|0;0;0|]
    |> fun s -> [|abs (s.[0]-s.[1]); abs (s.[0]-s.[2]); abs (s.[1]-s.[2])|]
    |> Array.forall (fun x -> x <= 1)
    |> fun b -> if b then "YES" else "NO"
let S = stdin.ReadLine()
solve S |> stdout.WriteLine

solve "abac" |> should equal "YES"
solve "aba" |> should equal "NO"
solve "babacccabab" |> should equal "YES"
