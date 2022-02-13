@"https://atcoder.jp/contests/abc065/tasks/abc065_b
2 ≦ N ≦ 10^5
1 ≦ a_i ≦ N"
#r "nuget: FsUnit"
open FsUnit

@"辿っていってa_i=1になったらアウト.
辿っていってa_i=i \neq 2になったらアウトなどいろいろある.
アウト判定はシンプルにN回ボタンを押して,
その中に2があるかないかを見ればよい.
ネットワーク内探索は再帰を使えばよい."
let solve N (As: array<int>) =
    let Bs = Array.map (fun x -> x-1) As
    let rec f i count =
        match (i, count) with
        | (_, count) when count > N -> -1
        | (i, _) when Bs.[i] = 1 -> count + 1
        | _ -> f Bs.[i] (count + 1)
    f 0 0

let N = stdin.ReadLine() |> int
let As = [| for i in 1..N do (stdin.ReadLine() |> int) |]
solve N As |> stdout.WriteLine

solve 3 [|3;1;2|] |> should equal 2
solve 4 [|3;4;1;2|] |> should equal -1
solve 5 [|3;3;4;2;4|] |> should equal 3
