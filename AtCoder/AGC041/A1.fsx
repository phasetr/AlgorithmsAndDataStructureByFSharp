@"https://atcoder.jp/contests/agc041/tasks/agc041_a"
#r "nuget: FsUnit"
open FsUnit

@"
2≤N≤10^{18}
1≤A<B≤N
入力中のすべての値は整数である。

abs(A-B)=B-Aが偶数だったら左右に動いて真ん中で出会える.
abs(A-B)=B-Aが奇数だったら一度端に行かなければ出会えない.
ただし端で出会う必要はなく, 真ん中で落ち合った方が速い可能性がある.

左右の対称性があるのでまずは左に向かう方を考える.
一人が卓1まで移動してから改めて右へ向かう.
このときすぐに右に行くと偶奇が変わらないので一回負けて偶奇を調整する.
もう一人は卓1に移動し続けてお互いの真ん中に動く.
お互いの中央はどこかが問題: 端点が「真ん中」にあたる場合がある."
let solve N A B =
    if (A-B)%2L=0L then (B-A)/2L // 真ん中に向けて動くべき
    else (min (A-1L) (N-B)) + 1L + (B-A-1L)/2L
let N,A,B = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1], x.[2])
solve N A B |> stdout.WriteLine

solve 5L 2L 4L |> should equal 1L
solve 5L 2L 3L |> should equal 2L
