@"https://atcoder.jp/contests/abc066/tasks/arc077_a
1 \leq n \leq 2\times 10^5
0 \leq a_i \leq 10^9
n,a_i は整数である。"
#r "nuget: FsUnit"
open FsUnit

@"解説から:
毎回逆向きの並び替えをしていると時間がかかりすぎる: (O(n^2)).
入力例を参考に考えると数列の最初と最後に交互にa_iを追加していると答えが求まる.
最後に追加した項は最初に来るはずで
1. i と n の偶奇が一致していれば数列の前に ai を追加.
2. i と n の偶奇が一致していなければ数列の後ろに ai を追加.
cf. https://atcoder.jp/contests/abc066/submissions/28096651"
let solve N (Aa: array<int>) =
    let indices N =
        if N%2=0 then Array.append [|N..(-2)..2|] [|1..2..N-1|]
        else Array.append [|N..(-2)..1|] [|2..2..(N-1)|]
    indices N |> Array.map (fun i -> Aa.[i-1])
let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> Array.map string |> String.concat " " |> stdout.WriteLine

solve 4 [|1;2;3;4|] |> should equal [|4;2;1;3|]
solve 3 [|1;2;3|] |> should equal [|3;1;2|]
solve 1 [|1000000000|] |> should equal [|1000000000|]
solve 6 [|0;6;7;6;7;0|] |> should equal [|0;6;6;0;7;7|]
