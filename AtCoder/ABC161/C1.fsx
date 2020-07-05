// https://atcoder.jp/contests/abc161/tasks/abc161_c
// 解説：https://img.atcoder.jp/abc161/editorial.pdf
// 欲しいのは最小値なので議論をそこに絞る。
// N が大きくても引き算を続けると最終的には t = |n % k| までは落ちてくるので、
// ここから議論を始めればいい。
// いま t < K だから次は K-t が出て来て、次は Kにに戻る。
// つまり |K - (n % k)| か |n % k| のどちらかが最小値になる
let judge (n:int64) (k:int64) = List.min [n % k |> abs; (k - (n % k) |> abs)]
//let input = [| 7L, 4L; 2L, 6L; 1000000000000000000L, 1L |]
//for n, k in input do (judge n k |> printfn "%d")
// expected 1; 2; 0

[<EntryPoint>]
let main argv =
    stdin.ReadLine().Split()
    |> Array.map int64
    |> fun x -> judge x.[0] x.[1]
    |> printfn "%d"
    0
