@"https://atcoder.jp/contests/dp/submissions/14841505"
#r "nuget: FsUnit"
open FsUnit

let solve N (hs: array<int>) =
    let f (h1,c1,h2,c2) t =
        let m = min (c1 + (abs (t - h1))) (c2 + (abs (t - h2)))
        (h2, c2, t, m)
    hs.[2..(N-1)]
    |> Array.scan f (hs.[0], 0, hs.[1], abs (hs.[1] - hs.[0]))
    |> Array.last
    |> fun (_,_,_,c2) -> c2

let N = stdin.ReadLine() |> int
let hs = stdin.ReadLine().Split() |> Array.map int
solve N hs |> stdout.WriteLine

solve 4 [|10;30;40;20|] |> should equal 30
solve 2 [|10;10|] |> should equal 0
solve 6 [|30;10;60;10;60;50|] |> should equal 40
