// https://atcoder.jp/contests/tenka1-2017/submissions/8797272
[<AutoOpen>]
module Cin =
    let read f = stdin.ReadLine() |> f

[<EntryPoint>]
let main _ =
    let N = read int64

    seq {
        for h in 1L .. 3500L do
            for n in 1L .. 3500L do
                let numer = h * n * N
                let deno = (4L * h * n) - (n * N) - (h * N)
                if deno <> 0L && numer % deno = 0L then
                    let w = numer / deno
                    if w > 0L then yield (h, n, w)
    }
    |> Seq.head
    |> fun (h, n, w) -> printfn "%d %d %d" h n w
    0 // return an integer exit code
