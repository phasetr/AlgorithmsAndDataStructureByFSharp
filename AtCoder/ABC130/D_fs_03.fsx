// https://atcoder.jp/contests/abc130/submissions/7721346
let [| n; k; |] = stdin.ReadLine().Split() |> Array.map int64
let a = stdin.ReadLine().Split() |> Array.map int64


let rec f (from: int) (_to: int) (totalBefore: int64) (count: int64) : int64 =
    let total = totalBefore + a.[_to]
    let n = int n
    match  n - from - 1, n - _to - 1, total - k >= 0L ,from = _to with
    | 0, _, false, _ -> count
    | 0, _, true, _ -> count + 1L
    | _, 0, false, _ -> count
    | _, 0, true, _ -> f (from + 1) _to (total - a.[_to] - a.[from] ) (count + 1L)
    | _, _, false, _ -> f from (_to + 1) total count
    | _, _, true, false -> f (from + 1) _to (total - a.[_to] - a.[from]) (count + int64 (n - _to))
    | _, _, true, true -> f (from + 1) (from + 1) 0L (count + int64 (n - _to))

f 0 0 0L 0L |> string |> stdout.WriteLine
