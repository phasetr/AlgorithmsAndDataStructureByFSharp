// https://atcoder.jp/contests/abc161/tasks/abc161_c
// 解説：https://img.atcoder.jp/abc161/editorial.pdf
// あっているかどうかは微妙だが、TLE で落とされたコード
let rec helper n k loopNum acc =
    if loopNum = k + 1L then  // k+1 回繰り返せば全て尽くせる：これが TLE の原因
        acc
    else
        let newN = (n - k) |> abs
        helper newN k (loopNum + 1L) (newN :: acc)

// n % k からはじめて最長 k 回繰り返せば計算で得られるすべての値が出る
let judge n k = helper (n % k) k 0L [] |> List.min

//let input = [| 7L, 4L; 2L, 6L; 1000000000000000000L, 1L |]
//for n, k in input do (judge n k |> List.min |> printfn "%d")
// expected 1; 2; 0

[<EntryPoint>]
let main argv =
    stdin.ReadLine().Split()
    |> Array.map int64
    |> fun x -> judge x.[0] x.[1]
    |> printfn "%d"
    0
