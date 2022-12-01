// https://atcoder.jp/contests/abc077/submissions/30018764
// [start, stop]の範囲で、cond x がtrueとなる最小のxを求める
// [start, stop]の範囲全てが満たす場合はstart-1, 全てが満たさない場合はstop+1
let lowerBound start stop cond =
    let left = start - 1
    let right = stop + 1
    let rec loop left right =
        // eprintfn "%d %d" left right
        if right - left <= 1 then right
        else
            let mid = left + (right - left) / 2
            if cond mid
                then loop left mid
                else loop mid right
    loop left right

#nowarn "25"

let getInt () = stdin.ReadLine() |> int
let getInts () = stdin.ReadLine().Split() |> Array.map int

let N = getInt()
let A = getInts() |> Array.sort
let B = getInts()
let C = getInts() |> Array.sort

seq {
    for ib in 0..(N-1) do
        let ia = lowerBound 0 (N-1) (fun ia -> A.[ia] >= B.[ib]) |> int64
        let ic = N - (lowerBound 0 (N-1) (fun ic -> B.[ib] < C.[ic])) |> int64
        yield ia * ic
} |> Seq.sum |> printfn "%d"
