// https://atcoder.jp/contests/abc161/submissions/27049206
// editorial
open System.Collections.Generic

let k = stdin.ReadLine() |> int

seq {
    let q = Queue { 1L .. 9L }
    while true do
        let lun = q.Dequeue()
        yield lun

        { lun % 10L - 1L .. lun % 10L + 1L }
        |> Seq.filter (fun d -> 0L <= d && d <= 9L)
        |> Seq.iter (fun d -> lun * 10L + d |> q.Enqueue)
}
|> Seq.item (k - 1)
|> stdout.WriteLine
