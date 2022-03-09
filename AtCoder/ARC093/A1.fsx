@"https://atcoder.jp/contests/arc093/tasks/arc093_a
2 \leq N \leq 10^5
-5000 \leq A_i \leq 5000 (1 \leq i \leq N)
入力値はすべて整数である。"
#r "nuget: FsUnit"
open FsUnit

@"全体を計算してから必要な箇所だけ加減算すればよい."
let solve N Aa =
    let path = Array.concat [|[|0|];Aa;[|0|]|]
    let pairs = path |> Array.pairwise
    let total = pairs |> Array.sumBy (fun (a,b) -> abs (b-a))

    let f n = total - (abs (path.[n] - path.[n-1])) - (abs (path.[n+1] - path.[n])) + (abs (path.[n+1] - path.[n-1]))
    [|1..N|] |> Array.map f
let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> Array.map string |> String.concat "\n" |> stdout.WriteLine

solve 3 [|3;5;-1|] |> should equal [|12;8;10|]
solve 5 [|1;1;1;2;0|] |> should equal [|4;4;4;2;4|]
solve 6 [|-679;-2409;-3258;3095;-3291;-4462|] |> should equal [|21630;21630;19932;8924;21630;19288|]
