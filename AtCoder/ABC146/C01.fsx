@"https://atcoder.jp/contests/abc146/tasks/abc146_c
* 入力は全て整数である。
* 1 \leq A \leq 10^9
* 1 \leq B \leq 10^9
* 1 \leq X \leq 10^{18}"
#r "nuget: FsUnit"
open FsUnit

@"二分探索で求める."
let A,B,X = 10L,7L,100L
let solve A B X =
    let order n = n |> string |> String.length |> int64
    let cost n = A*n + B * (order n)
    let rec frec a b x lo hi =
        let mid = (lo+hi)/2L
        let res = a*mid + b*(order mid)
        if hi-lo<=1L then mid
        elif x<res then frec a b x lo mid
        else frec a b x mid hi
    let n = pown 10 9 |> int64
    if A*n + B*10L <= X then n else frec A B X 0L n
let A,B,X = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1], x.[2])
solve A B X |> stdout.WriteLine

solve 10L 7L 100L |> should equal 9L
solve 2L 1L 100000000000L |> should equal 1000000000L
solve 1000000000L 1000000000L 100L |> should equal 0L
solve 1234L 56789L 314159265L |> should equal 254309L
