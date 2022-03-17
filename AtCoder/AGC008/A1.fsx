@"https://atcoder.jp/contests/agc008/tasks/agc008_a
- x, y は整数である。
- |x|, |y| ≤ 10^9
- x, y は相異なる。"
#r "nuget: FsUnit"
open FsUnit

@"場合分けして調べればよいが工夫しないと破滅する(実際破滅した).
解説から引用.

最短の操作列は次の形に限る.
(B を 0 or 1 回押す) → (A を 0 回以上押す) → (B を 0 or 1 回押す)
したがって「最初に B を押す・押さない」,
「最後に B を押す・押さない」の組み合わせを4通り試して最小値を取る.
最初にBを押す場合はxの符号を反転,
最後にBを押す場合はyの符号を反転する.
残りの操作は「A を 0 回以上押す」だけで,
x≤yならばAをy−x回押せばよく,
y<xならばAを|x-y|回押せばよい."
let solve x y =
    let diff = match (x >= 0 , y > 0, x > y) with
        | (true,true,true) | (false,false,true) -> 2
        | (true,false,_) | (false,true,_) -> 1
        | (_,_,false) -> 0
    abs(abs(y)-abs(x)) + diff
let x, y = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
solve x y |> stdout.WriteLine

solve 10 20 |> should equal 10
solve 10 -10 |> should equal 1
solve -10 -20 |> should equal 12
solve -708262244 708262244 |> should equal 1
solve 0 -191403770 |> should equal 191403771
solve 28056475 0 |> should equal 28056476
solve 1000000000 1 |> should equal 1000000001
solve 412682070 -641309189 |> should equal 228627120
