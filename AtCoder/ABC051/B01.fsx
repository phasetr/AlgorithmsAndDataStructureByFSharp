@"https://atcoder.jp/contests/abc051/tasks/abc051_b
* 2≦K≦2500
* 0≦S≦3K
* K,S は整数である。"
#r "nuget: FsUnit"
open FsUnit

@"全探索は駄目で許されるのはx,yの自由度まで."
let K,S = 2,2
let solve K S =
    [|
     for x in 0..K do
     for y in 0..K do
     if 0<=S-x-y && S-x-y<=K then yield true|]
    |> Array.length
let K,S = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
solve K S |> stdout.WriteLine

solve 2 2 |> should equal 6
solve 5 15 |> should equal 1
