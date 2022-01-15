@"問題文
N 枚の ID カードと M 個のゲートがあります。
i 番目のゲートは Li,L_{i+1},...,Ri番目の ID カードのうち,
どれか 1 枚を持っていれば通過できます。
1 枚だけで全てのゲートを通過できる ID カードは何枚あるでしょうか。

制約
入力は全て整数である。
1≤N≤10^5
1≤M≤10^5
1≤Li≤Ri ≤N"
#r "nuget: FsUnit"
open FsUnit

let solve N M Ks =
    Ks
    |> Array.reduce(fun (l1, r1) (l2, r2) -> (max l1 l2, min r1 r2))
    |> fun (l,r) -> (r-l+1)
    |> max 0

let N, M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Ks = [| for i in 1..M do stdin.ReadLine().Split() |> Array.map int |> (fun x -> (x.[0], x.[1])) |]
solve N M Ks |> printfn "%d"

solve 4 2 [|(1, 3); (2,4)|] |> should equal 2
solve 10 3 [|(3, 6); (5,7); (6,9)|] |> should equal 1
solve 100000 1 [|(1, 100000)|] |> should equal 100000
