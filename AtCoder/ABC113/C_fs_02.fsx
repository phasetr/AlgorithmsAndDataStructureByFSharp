// https://atcoder.jp/contests/abc113/submissions/31061731
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

let prefs =
    Array.init n (fun _ -> System.Collections.Generic.List())

for i in 0 .. m - 1 do
    let p = (cin () |> int) - 1
    let y = cin () |> int
    prefs.[p].Add(y, i)

for pref in prefs do
    pref.Sort()

let res = Array.zeroCreate m

for i in 0 .. n - 1 do
    let pref = prefs.[i]
    for j in 0 .. pref.Count - 1 do
        let _, ind = pref.[j]
        res.[ind] <- sprintf "%06d%06d" (i + 1) (j + 1)

System.String.Join('\n', res) |> stdout.WriteLine
