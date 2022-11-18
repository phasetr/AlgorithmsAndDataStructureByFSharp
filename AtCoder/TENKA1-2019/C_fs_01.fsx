// https://atcoder.jp/contests/tenka1-2019/submissions/35806883
stdin.ReadLine()
let s = stdin.ReadLine().ToCharArray()

let b =
    Seq.scan (fun p c -> p + (if c = '#' then 1 else 0)) 0 s

let w =
    Seq.rev s
    |> Seq.scan (fun p c -> p + (if c = '.' then 1 else 0)) 0
    |> Seq.rev

Seq.map2 (+) b w |> Seq.min |> stdout.WriteLine
