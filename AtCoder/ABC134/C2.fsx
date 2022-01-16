@"https://atcoder.jp/contests/abc134/submissions/7103926"
#r "nuget: FsUnit"
open FsUnit

let solve N As =
    let Bs = Array.scan max 0 As
    let Cs = Array.rev As |> Array.scan max 0 |> Array.rev |> Array.tail
    Seq.map2 max Bs Cs

let N = stdin.ReadLine() |> int
let As = [| for i in 1..N do (stdin.ReadLine() |> int) |]
solve N As |> Seq.map string |> String.concat "\n" |> printfn "%s"

solve 3 [|1; 4; 3|] |> should equal [|4;3;4|]
solve 2 [|5;5|] |> should equal [|5;5|]
