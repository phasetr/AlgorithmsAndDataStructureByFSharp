@"https://atcoder.jp/contests/arc068/tasks/arc068_a
* 1 ≦ x ≦ 10^{15}
* x は整数"
#r "nuget: FsUnit"
open FsUnit

@"x点「以上」の制約とxが巨大なところに注意.
上の面がiだとするとiと7-i以外の点は必ず取れる.
目的の値になるまでは最大限取り続ける.
はまりどころはどこだ?
xが6以下ならば1回,
11以下ならば2回
17以下ならば3回,
22以下ならば4回,
28以下ならば5回,
33以下ならば6回と帰納的に考える."
let solve x =
    let r = x%11L
    let q = x/11L
    if r=0L then 2L*q elif r<=6L then 2L*q+1L else 2L*q+2L
let x = stdin.ReadLine() |> int64
solve x |> stdout.WriteLine

solve 6L |> should equal 1L
solve 7L |> should equal 2L
solve 11L |> should equal 2L
solve 17L |> should equal 3L
solve 22L |> should equal 4L
solve 28L |> should equal 5L
solve 149696127901L |> should equal 27217477801L
