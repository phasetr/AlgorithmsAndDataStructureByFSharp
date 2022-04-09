// https://atcoder.jp/contests/code-festival-2017-quala/submissions/1617435
#r "nuget: FsUnit"
open FsUnit

let solve N M K =
    let allPairs s1 s2 = seq { for a in s1 do for b in s2 do yield (a, b) }
    let f (i,j) = i*(M-j) + (N-i)*j = K
    allPairs [0..N] [0..M]
    |> Seq.exists f
    |> fun b -> if b then "Yes" else "No"
let N,M,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1], x.[2])
solve N M K |> stdout.WriteLine

solve 2 2 2 |> should equal "Yes"
solve 2 2 1 |> should equal "No"
solve 3 5 8 |> should equal "Yes"
solve 7 9 20 |> should equal "No"
