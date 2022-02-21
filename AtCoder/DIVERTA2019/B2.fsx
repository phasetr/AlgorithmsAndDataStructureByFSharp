@"https://atcoder.jp/contests/diverta2019/tasks/diverta2019_b
入力は全て整数
1 \leq R,G,B,N \leq 3000"
#r "nuget: FsUnit"
open FsUnit

@"https://atcoder.jp/contests/diverta2019/submissions/18247984"
let solve R G B N =
    [| for r in [|0..N/R|] do for g in [|0..(N-R*r)/G|] do (r,g) |]
    |> Array.filter (fun (r,g) -> (N - R*r - G*g) % B = 0)
    |> Array.length

let R,G,B,N = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1], x.[2], x.[3])
solve R G B N |> stdout.WriteLine

solve 1 2 3 4 |> should equal 4
solve 13 1 4 3000 |> should equal 87058
