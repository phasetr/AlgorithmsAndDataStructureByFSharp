@"https://atcoder.jp/contests/abc134/tasks/abc134_c
問題文
長さ N の数列 A1,A2,...,ANが与えられます。
1 以上 N 以下の各整数 i に対し、次の問いに答えてください。

数列中の Ai を除く N−1 個の要素のうちの最大の値を求めよ。
制約
2≤N≤200000
1≤Ai≤200000
入力中のすべての値は整数である。"
#r "nuget: FsUnit"
open FsUnit

let solve N As =
    let Bs = As |> Array.sort |> Array.rev
    [|0..(N-1)|]
    |> Array.map (fun i -> if As.[i] = Bs.[0] then Bs.[1] else Bs.[0])

let N = stdin.ReadLine() |> int
let As = [| for i in 1..N do (stdin.ReadLine() |> int) |]
solve N As |> Array.map string |> String.concat "\n" |> printfn "%s"

solve 3 [|1; 4; 3|] |> should equal [|4;3;4|]
solve 2 [|5;5|] |> should equal [|5;5|]
