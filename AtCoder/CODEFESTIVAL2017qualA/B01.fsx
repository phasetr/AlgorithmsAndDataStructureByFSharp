@"https://atcoder.jp/contests/code-festival-2017-quala/tasks/code_festival_2017_quala_b"
#r "nuget: FsUnit"
open FsUnit

@"解説から:
行ボタンを k 個, 列ボタンを l 個を押すと,
黒マスの個数は k(M − l) + (N − k)l."
let solve N M K =
    let f (i,j) = i*(M-j) + (N-i)*j = K
    Array.allPairs [|0..N|] [|0..M|]
    |> Array.exists f
    |> fun b -> if b then "Yes" else "No"
let N,M,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1], x.[2])
solve N M K |> stdout.WriteLine

solve 2 2 2 |> should equal "Yes"
solve 2 2 1 |> should equal "No"
solve 3 5 8 |> should equal "Yes"
solve 7 9 20 |> should equal "No"

@"自分のオリジナル"
let solve2 N M K =
    let f i j = i*(M-j) + (N-i)*j
    Array.allPairs [|0..N|] [|0..M|]
    |> Array.filter (fun (i,j) -> f i j = K)
    |> fun x -> if x.Length=0 then "No" else "Yes"
let N,M,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1], x.[2])
solve2 N M K |> stdout.WriteLine

solve2 2 2 2 |> should equal "Yes"
solve2 2 2 1 |> should equal "No"
solve2 3 5 8 |> should equal "Yes"
solve2 7 9 20 |> should equal "No"
