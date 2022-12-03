// https://atcoder.jp/contests/abc099/submissions/8976622
open System.Collections.Generic

let n = stdin.ReadLine() |> int

let array6 =
    [|
        let mutable count = 1
        while count<= 100000 do
            yield count
            count <- count * 6
    |]
let array9 =
    [|
        let mutable count = 1
        while count<= 100000 do
            yield count
            count <- count * 9
    |]

/// メモ化再帰に用いる辞書
let cache = Dictionary<_,_>()
let memoize f =
    fun x ->
        if cache.ContainsKey(x) then cache.[x]
        else
        cache.[x] <- f x
        cache.[x]

/// メモ化再帰
let rec memCount n=
    let count n=
        if n <> 0 then
            let cand1 =
                n - (array6 |> Array.findBack (fun x -> x <= n))
            let cand2 =
                n - (array9 |> Array.findBack (fun x -> x <= n))
            min
                (memCount cand1)
                (memCount cand2)
            + 1
        else 0
    let memCount = memoize count
    memCount n

memCount n |> stdout.WriteLine
