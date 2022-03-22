@"https://atcoder.jp/contests/abc065/tasks/arc076_a
- 1 ≦ N,M ≦ 10^5"
#r "nuget: FsUnit"
open FsUnit

@"N<=M+2またはM<=N+2のときは必ず犬同士または猿同士が隣り合うから0.
犬を並べてからその間に猿を並べればよい.
N=Mのとき先頭に犬が来るか猿が来るかで二通りある.
N=M+1のときは多い方が先頭に来なければならない."
let N,M = 2L,2L
let N,M = 3L,2L
let solve N M =
    let MOD = (pown 10 9 |> int64) + 7L
    let n, m = min N M, max N M
    let fact k =
        let rec f acc k = if k<=0L then 1L elif k=1L then acc else f (acc*k%MOD) (k-1L)
        (f 1L k)%l
    if m=n then 2L*(fact n * fact n)%MOD
    elif m=n+1L then (fact m * fact n)%MOD
    else 0L
let N,M = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1])
solve N M |> stdout.WriteLine

solve 2L 2L |> should equal 8L
solve 3L 2L |> should equal 12L
solve 1L 8L |> should equal 0L
solve 100000L 100000L |> should equal 530123477L
