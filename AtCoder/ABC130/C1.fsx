@"https://atcoder.jp/contests/abc130/tasks/abc130_c
1 \leq W,H \leq 10^9
0\leq x\leq W
0\leq y\leq H
入力はすべて整数である"
#r "nuget: FsUnit"
open FsUnit

@"面積が大きくない方の最大値だから最大で半分.
元が長方形だから素直にx軸かy軸に平行な直線で切ればいいか?
長方形であっても(x,y)が短軸・長軸どちらかが偶数でその真ん中にあれば半分にわけられる.

複数判定はどうする?
例2を見ると真ん中の点に来たとき縦横どちらでも切れて複数判定ができる.
正方形の中心の場合斜めもあって確かに半分にわけられる.
ただし(x,y)は格子点だから辺の長さが偶数の正方形の場合だけ
長方形の場合, 複数の分割法はない."
let solve W H x y =
    let area = (W*H |> float) / 2.0
    let mult = if x+x=W && y+y=H then 1 else 0
    (area,mult)
let W,H,x,y = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1], x.[2], x.[3])
solve W H x y |> fun (a,b) -> printfn "%f %d" a b

solve 2 3 1 2 |> should equal (3.000000,0)
solve 2 2 1 1 |> should equal (2.000000,1)
