@"https://atcoder.jp/contests/arc098/tasks/arc098_a
- 2 \leq N \leq 3 \times 10^5
- |S| = N
- S_i は E または W である"
#r "nuget: FsUnit"
open FsUnit

@"向くべきはリーダーの方向であることに注意.
西か東ではない.
リーダーの番号をlとすると
リーダーより右(l<i)はW,
リーダーより左(i<l)はEでなければならないから,
この数を数えて最小化すればよい.

具体的にはまず累積和をscanで計算する.
lsは左からWを数え, rsは右からEを数える.
この和の最小値を計算すればよい."
let N,S = 5,"WEEWW"
let solve N S =
    let count c d = if c=d then 1 else 0
    let sa = S |> Array.ofSeq
    let ls = Array.scan (+) 0 (Array.map (count 'W') sa)
    let rs = Array.scanBack (+) (Array.map (count 'E') sa) 0
    Array.map2 (+) ls rs |> Array.min
let N = stdin.ReadLine() |> int
let S = stdin.ReadLine()
solve N S |> stdout.WriteLine

solve 5 "WEEWW" |> should equal 1
solve 12 "WEWEWEEEWWWE" |> should equal 4
solve 8 "WWWWWEEE" |> should equal 3
