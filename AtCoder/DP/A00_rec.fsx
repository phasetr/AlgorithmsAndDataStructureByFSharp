#r "nuget: FsUnit"
open FsUnit

@"https://atcoder.jp/contests/dp/submissions/26333135
[i-2]のコスト
[i-1]のコスト
h[i-2]
h[i-1]
(h[i]:...)"
let solve N hs =
    let rec loop c2 c1 h2 h1 = function
    | [] -> c1
    | h::tail ->
        let c = min (c2 + abs(h2-h)) (c1 + abs(h1-h))
        loop c1 c h1 h tail
    let h2::h1::h3s = Array.toList hs
    loop 0 (abs (h2-h1)) h2 h1 h3s

let N = stdin.ReadLine() |> int
let hs = stdin.ReadLine().Split() |> Array.map int
solve N hs |> stdout.WriteLine

solve 4 [|10;30;40;20|] |> should equal 30
solve 2 [|10;10|] |> should equal 0
solve 6 [|30;10;60;10;60;50|] |> should equal 40
