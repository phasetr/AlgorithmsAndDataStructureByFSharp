@"https://atcoder.jp/contests/abc056/tasks/arc070_a
X は整数
1≦X≦10^9"
#r "nuget: FsUnit"
open FsUnit

@"解説PDFから抜粋.
1+2+...+t<Xなら目的地に辿り着けず,
1+2+...+t>=Xなら目的地に辿り着ける.
後者の場合和がXになる{1,2,..,t}の部分集合が取れ,
部分集合に選んだ長さのときだけ右にジャンプし,
それ以外のときはジャンプしなければよい."

let solve X =
    Seq.initInfinite id
    |> Seq.filter (fun i ->
        let j = int64 i
        X <= j*(j+1L)/2L)
    |> Seq.head
let X = stdin.ReadLine() |> int64
solve X |> stdout.WriteLine
let solve X =
    let rec f x i s =
        if i+s>=x then i else f x (i+1L) (i+s)
    f X 1L 0L

let X = stdin.ReadLine() |> int64
solve X |> stdout.WriteLine

solve 6L  |> should equal 3L
solve 2L  |> should equal 2L
solve 11L |> should equal 5L
