@"https://atcoder.jp/contests/agc017/tasks/agc017_a
1 \leq N \leq 50
P = 0, 1
1 \leq A_i \leq 100"
#r "nuget: FsUnit"
open FsUnit

@"和の偶奇を見る.
全ての選び方は2^Nあり素直な全探索はできない.
P=0の場合, 奇数は取るとしても偶数回.
P=1の場合, 奇数を必ず奇数回取る.

解説から.
Ai がすべて偶数の場合,
どのように袋を選んでも食べるビスケットの枚数は偶数.
P = 0 の場合は答えは 2^N, P = 1 の場合は答えは 0.

Ai の中に奇数が含まれているとき,
Ak が奇数であるような k が取れる.
k 番目の袋以外の N −1個の袋の選び方は 2^{N−1} 通りある．
これらの N − 1 個の袋から選んだ袋のビスケットの枚数の合計を S とすると,
• S が奇数なら k 番目の袋を選ぶと合計は偶数, 選ばないと合計は奇数.
• S が偶数なら k 番目の袋を選ぶと合計は奇数, 選ばないと合計は偶数.
これら2^{N−1}通りの選び方のそれぞれについてk番目の袋を選ぶか選ばないかでちょうど 1 通り,
合計を偶数にする方法および奇数にする方法がある.
よって，この場合の答えは P によらず 2^{N−1} である."
let solve N P Aa =
    let powI (x:bigint) y =
        let rec f y acc = if y = 0L then acc else f (y-1L) (x*acc)
        f y 1I
    Aa |> Array.forall (fun x -> x%2L=0L)
    |> fun b ->
        if b then if P=0L then powI 2I N else 0I
        else powI 2I (N-1L)

let N, P = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int64
solve N P Aa |> stdout.WriteLine

solve 2L 0L [|1L;3L|] |> should equal 2I
solve 1L 1L [|50L|] |> should equal 0I
solve 3L 0L [|1L;1L;1L|] |> should equal 4I
solve 45L 1L [|17L;55L;85L;55L;74L;20L;90L;67L;40L;70L;39L;89L;91L;50L;16L;24L;14L;43L;24L;66L;25L;9L;89L;71L;41L;16L;53L;13L;61L;15L;85L;72L;62L;67L;42L;26L;36L;66L;4L;87L;59L;91L;4L;25L;26L|] |> should equal 17592186044416I
