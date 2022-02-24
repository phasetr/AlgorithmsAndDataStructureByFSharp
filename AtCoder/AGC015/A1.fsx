@"https://atcoder.jp/contests/agc015/tasks/agc015_a
1 ≦ N,A,B ≦ 10^9
A,B は整数である"
#r "nuget: FsUnit"
open FsUnit

@"AとBの値自体はきちんと持っている必要があり,
入力としてはB<Aの場合すらある.
まずは不適な場合(0個の場合)を処理する.

不適なのはB<Aのとき,
A<BであってもN<(B-A+1)のとき.

適している場合, AとBに一つずつ消費するから,
N-2個を[A..B]から取る.
重複組み合わせの計算ではあるが,
必要なのは総和のありうる値だから最終的には総和をfilterする必要がある.

総和はN-2個の全てがA, 全てがBの場合の間にある.
例えば一つのAをA+1に変えると値が1増えるから,
総和はA*(N-2)からB*(N-2)の間にあり, この個数を数えればよい."
let solve N A B =
    if B<A then 0L
    elif N=1L then
        if A=B then 1L else 0L
    else (N-2L)*(B-A)+1L
let N,A,B = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1], x.[2])
solve N A B |> stdout.WriteLine

solve 4L 4L 6L |> should equal 5L
solve 5L 4L 3L |> should equal 0L
solve 1L 7L 10L |> should equal 0L
solve 1L 3L 3L |> should equal 1
