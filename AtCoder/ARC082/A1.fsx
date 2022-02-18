@"https://atcoder.jp/contests/abc072/tasks/arc082_a
1≤N≤10^5
0≤a_i<10^5 (1≤i≤N)
a_i は整数"
#r "nuget: FsUnit"
open FsUnit

@"三パターンを試すのではなく,
Xとの差の絶対値が1以下かどうかを検出する形で考える.
各数の個数を数えておいてXとの差を取ればよい.

もしくは絶対値の差が \pm 1の値を全て作っておき,
その全値を持つ配列に対してXの個数を取る."
let solve N As =
    As |> Array.collect (fun a -> [|a-1L;a;a+1L|])
    |> Array.countBy id
    |> Array.maxBy snd
    |> snd
let N = stdin.ReadLine() |> int64
let As = stdin.ReadLine().Split() |> Array.map int64
solve N As |> stdout.WriteLine

solve 7L [|3L;1L;4L;1L;5L;9L;2L|] |> should equal 4L
solve 10L [|0L;1L;2L;3L;4L;5L;6L;7L;8L;9L|] |> should equal 3
solve 1L [|99999L|] |> should equal 1L
