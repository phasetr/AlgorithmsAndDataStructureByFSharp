@"https://atcoder.jp/contests/abc087/tasks/arc090_a"
#r "nuget: FsUnit"
open FsUnit

@"1<=N<=100だから全探索して最小値を取る.
動的計画法でもできる.
参考: https://atcoder.jp/contests/abc087/submissions/2228001"
let solve N As =
    let score path (As: int[][]) =
        path |> Array.fold (fun acc (i,j) -> acc + As.[i-1].[j-1]) 0
    let paths = [|for i in [|1..N|] do Array.append [|for j in [|1..i|] do (1,j)|] [|for j in [|i..N|] do (2,j)|]|]
    paths
    |> Array.fold (fun acc path -> max acc (score path As)) 0

let N = stdin.ReadLine() |> int
let A1s = stdin.ReadLine().Split() |> Array.map int
let A2s = stdin.ReadLine().Split() |> Array.map int
let As = [|A1s;A2s|]
solve N As |> stdout.WriteLine

solve 5 [|[|3; 2; 2; 4; 1|];[|1; 2; 2; 2; 1|]|] |> should equal 14
solve 4 [|[|1;1;1;1|];[|1;1;1;1|]|] |> should equal 5
solve 7 [|[|3; 3; 4; 5; 4; 5; 3|];[|5; 3; 4; 4; 2; 3; 2|]|] |> should equal 29
solve 1 [|[|2|];[|3|]|] |> should equal 5
