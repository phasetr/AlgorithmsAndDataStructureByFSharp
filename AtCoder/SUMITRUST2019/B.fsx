// https://atcoder.jp/contests/sumitrust2019/tasks/sumitb2019_b
let calc (n: int) =
    // 端数切り捨てで考えると該当する数 x は n \leq x * 1.08 < n + 1 をみたす
    let orig = (n |> float) / 1.08 |> ceil |> int
    if ((orig |> float) * 1.08) |> int = n then (orig |> string) else ":("

//let input = [| 432; 1079; 1001 |]
//for i in input do calc i |> printfn "%s"
// expected 400; :(; 927

[<EntryPoint>]
let main argv =
    let n = stdin.ReadLine() |> int
    calc n |> printfn "%s"
    0
