@"https://atcoder.jp/contests/keyence2019/tasks/keyence2019_c
* 1 \leq N \leq 10^5
* 1 \leq A_i \leq 10^9
* 1 \leq B_i \leq 10^9
* A_i, B_i は整数"
#r "nuget: FsUnit"
open FsUnit

@"解説から:
Ai<Biをみたすiに対するBi-Aiの総和をSとしたとき,
Ai>=Biをみたすiに対してできるだけAi-Biを少なく選びつつ総和をS以上にする.
最初にSを計算し, Ai>=Biをみたすiに対してAi-Biを大きい順に見て,
総和がSになるまで計算する.
これがnum個だったとすると #{i|Ai<Bi}+num が解.

コード参考: https://atcoder.jp/contests/keyence2019/submissions/4012201"
let solve N Aa Ba =
    let Ca = Array.map2 max Aa Ba
    let x = Array.map2 (<>) Aa Ca |> Array.filter id |> Array.length
    let d = Array.sum Ca - Array.sum Aa
    Array.map2 (-) Ca Ba
    |> Array.sortDescending
    |> Array.scan (+) 0L
    |> Array.tryFindIndex ((<=) d)
    |> function
        | Some y -> x+y
        | None -> -1
let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int64
let Ba = stdin.ReadLine().Split() |> Array.map int64
solve N Aa Ba |> stdout.WriteLine

solve 3 [|2L;3L;5L|] [|3L;4L;1L|] |> should equal 3L
solve 3 [|2L;3L;3L|] [|2L;2L;1L|] |> should equal 0L
solve 3 [|17L;7L;1L|] [|25L;6L;14L|] |> should equal -1L
solve 12 [|757232153L;372327760L;440075441L;195848680L;354974235L;458054863L;463477172L;740174259L;615762794L;632963102L;529866931L;64991604L|] [|74164189L;98239366L;465611891L;362739947L;147060907L;118867039L;63189252L;78303147L;501410831L;110823640L;122948912L;572905212L|] |> should equal 5L
