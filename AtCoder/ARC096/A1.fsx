@"https://atcoder.jp/contests/abc095/tasks/arc096_a"
#r "nuget: FsUnit"
open FsUnit

@"ABは常に二枚買ってAとBに足し込むと思えばよい.
ABセットを何枚買ったか全数検索してしまう."
let solve A B C X Y =
    let AB = A + B
    let N = pown 10 5
    [|0..N|]
    |> Array.map (fun i -> (2*C)*i + A * (max 0 (X-i)) + B * (max 0 (Y-i)))
    |> Array.min
let [|A;B;C;X;Y|] = stdin.ReadLine().Split() |> Array.map int
solve A B C X Y |> stdout.WriteLine

solve 1500 2000 1600 3 2 |> should equal 7900
solve 1500 2000 1900 3 2 |> should equal 8500
solve 1500 2000 500 90000 100000 |> should equal 100000000
