// https://atcoder.jp/contests/keyence2020/submissions/30836961
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

let n = cin () |> int

Seq.init n (fun _ ->
    let x, l = cin () |> int, cin () |> int
    x - l, x + l)
|> Seq.sortBy snd
|> Seq.fold
    (fun (ans, last) (left, right) ->
        match last <= left with
        | false -> ans, last
        | true -> ans + 1, right)
    (0, -1010101010)
|> fst
|> stdout.WriteLine
