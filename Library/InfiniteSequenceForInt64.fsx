/// https://atcoder.jp/contests/abc169/tasks/abc169_d
/// return! を使った再帰ではなく mutable を使っているのは return! で生成されるステートマシンのコストが（数を出して1増やすだけの処理より）普通に高いため
let initInfinite64 f =
    seq {
        let mutable i = 0L
        while true do
            yield f i
            i <- i + 1L
    }

let initInfiniteBigInteger f =
    seq {
        let mutable i = 0I
        while true do
            yield f i
            i <- i + 1I
    }