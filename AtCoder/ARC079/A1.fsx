@"https://atcoder.jp/contests/abc068/tasks/arc079_a
3 ≦ N ≦ 200,000
1 ≦ M ≦ 200,000
1 ≦ a_i < b_i ≦ N
(a_i, b_i) \neq (1, N)
i \neq j ならば (a_i, b_i) \neq (a_j, b_j)"
#r "nuget: FsUnit"
open FsUnit

@"島 1 と島 i の間に辺があるか,
島 i と島 N の間に辺があるかを調べて畳む."
let solve N M Xa =
    let starts = Xa |> Array.choose (fun (a,b) -> if a=1 then Some b else None) |> Set.ofArray
    let ends = Xa |> Array.choose (fun (a,b) -> if b=N then Some a else None) |> Set.ofArray
    Set.intersect starts ends
    |> fun s -> if Set.isEmpty s then "IMPOSSIBLE" else "POSSIBLE"
let N, M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Xa = [| for i in 1..M do (stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])) |]
solve N M Xa |> stdout.WriteLine

solve 3 2 [|(1,2);(2,3)|] |> should equal "POSSIBLE"
solve 4 3 [|(1,2);(2,3);(3,4)|] |> should equal "IMPOSSIBLE"
solve 100000 1 [|(1,99999)|] |> should equal "IMPOSSIBLE"
solve 5 5 [|(1,3);(4,5);(2,3);(2,4);(1,4)|] |> should equal "POSSIBLE"
