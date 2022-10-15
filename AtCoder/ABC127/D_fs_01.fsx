// https://atcoder.jp/contests/abc127/submissions/31819298
// ---------- Lib --------------
[<AutoOpen>]
module Cin =
    let private q = System.Collections.Generic.Queue()

    let cin _ =
        while q.Count = 0 do
            for s in stdin.ReadLine().Split() do
                if s <> "" then q.Enqueue s
        q.Dequeue()
// ---------- End Lib ----------

let n, m = cin () |> int, cin () |> int

let a = Seq.init n (fun _ -> 1, cin () |> int64)

let b =
    Seq.init m (fun _ -> cin () |> int, cin () |> int64)

let rec solve sum k lst =
    match k, lst with
    | 0, _ -> sum
    | k, (c, v) :: tail when k < c -> solve (sum + int64 k * v) 0 tail
    | k, (c, v) :: tail -> solve (sum + int64 c * v) (k - c) tail

Seq.append a b
|> Seq.sortByDescending snd
|> Seq.toList
|> solve 0L n
|> stdout.WriteLine
