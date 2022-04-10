@"https://atcoder.jp/contests/dp/submissions/26866015"
#r "nuget: FsUnit"
open FsUnit

let solve N hs =
    let f [|h2;c2;h1;c1|] h0 =
        [|h1; c1; h0; min (c2 + abs(h0-h2)) (c1 + abs(h0-h1))|]
    hs
    |> Array.fold f [|0;0;hs.[0];0|]
    |> Array.last
let N = stdin.ReadLine() |> int
let hs = stdin.ReadLine().Split() |> Array.map int
solve N hs |> stdout.WriteLine

solve 4 [|10;30;40;20|] |> should equal 30
solve 2 [|10;10|] |> should equal 0
solve 6 [|30;10;60;10;60;50|] |> should equal 40
