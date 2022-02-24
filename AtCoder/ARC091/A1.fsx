@"https://atcoder.jp/contests/arc091/tasks/arc091_a
1 \leq N,M \leq 10^9
入力は全て整数である"
#r "nuget: FsUnit"
open FsUnit

@"あるカードは隣接したカードと自分自身を加えた枚数分だけ裏表が変わる.
この自身を含めたカードの枚数を隣接数とすると,
各カードの隣接数を計算してその偶奇を見て奇数のカードの枚数を数えればよい.

議論を明確にするためにN<=Mを仮定する.
N=1, つまり1列しかないときは特殊な処理が必要で,
M=1のときはカードが一枚だけでこれが裏になって1,
一方1<Mなら両端は自分と隣の二枚,
それ以外は常に左右と自分自身の三枚で裏を向くのは中央部の(max N M) - 2枚.

四隅にあるカードの隣接数は4で最後に表を向き,
四隅以外の周上にあるカードの隣接数は6で最後に表を向き,
それ以外の「中央部」にあるカードの隣接数は9で最後に裏を向く.
したがって中央部のカードの枚数を数えばよい."
let solve N M =
    let n = min N M
    let m = max N M
    if n=1L then
        if m=1L then 1L else (max N M) - 2L
    else (N-2L)*(M-2L)
let N,M = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1])
solve N M |> stdout.WriteLine

solve 1L 1L |> should equal 1L
solve 2L 2L |> should equal 0L
solve 1L 7L |> should equal 5L
solve 314L 1592L |> should equal 496080L
