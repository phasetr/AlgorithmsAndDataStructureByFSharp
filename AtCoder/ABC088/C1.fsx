@"https://atcoder.jp/contests/abc088/tasks/abc088_c
c_{i, j} \ (1 \leq i \leq 3, 1 \leq j \leq 3) は
0 以上 100 以下の整数"
#r "nuget: FsUnit"
open FsUnit

@"(𝑎1, 𝑎2, 𝑎3, 𝑏1, 𝑏2, 𝑏3) = (𝑝1, 𝑝2, 𝑝3, 𝑞1, 𝑞2, 𝑞3)
の値の組み合わせが条件に沿っているなら,
任意の数 𝑥 に対して
(𝑎1, 𝑎2, 𝑎3, 𝑏1, 𝑏2, 𝑏3) = (𝑝1 + 𝑥, 𝑝2 + 𝑥, 𝑝3 + 𝑥, 𝑞1 − 𝑥, 𝑞2 − 𝑥, 𝑞3 − 𝑥)
の値の組み合わせが正しい.
特に a1 = 0 を仮定でき,
これと c_{1,i} から b_i = c_{1,i} が決まる.
さらにこれから a_2, a_3 が決まる.

c_{1,1} c_{1,2} c_{1,3}
c_{2,1} c_{2,2} c_{2,3}
c_{3,1} c_{3,2} c_{3,3}"
let solve (ca: array<array<int>>) =
    // a_1 = 0 と仮定して c_{1,j} から b_j を決定
    let ba = ca.[0]
    // a_i = c_{i,1} - b_1 によって
    // c_{2,1}, c_{3,1} から a_2, a_3 を決定
    let aa = [|0; ca.[1].[0] - ba.[0]; ca.[2].[0] - ba.[0]|]
    // あとは右下のブロックにあたる
    // c_{2,2}, c_{2,3}, c_{3,2}, c_{3,3} の値が得られるか確認
    let truevals = [|ca.[1].[1]; ca.[1].[2]; ca.[2].[1]; ca.[2].[2]|]
    let candidates = [|aa.[1]+ba.[1]; aa.[1]+ba.[2]; aa.[2]+ba.[1]; aa.[2]+ba.[2]|]
    Array.map2 (=) truevals candidates
    |> Array.forall id
    |> fun x -> if x then "Yes" else "No"
let ca = [| for i in 1..3 do (stdin.ReadLine().Split() |> Array.map int) |]
solve ca |> stdout.WriteLine

solve [|[|1;0;1|];[|2;1;2|];[|1;0;1|]|] |> should equal "Yes"
solve [|[|2;2;2|];[|2;1;2|];[|2;2;2|]|] |> should equal "No"
solve [|[|0;8;8|];[|0;8;8|];[|0;8;8|]|] |> should equal "Yes"
solve [|[|1;8;6|];[|2;9;7|];[|0;7;7|]|] |> should equal "No"
