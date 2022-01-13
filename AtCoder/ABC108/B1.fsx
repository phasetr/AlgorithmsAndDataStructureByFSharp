@"https://atcoder.jp/contests/abc108/tasks/abc108_b
問題文
xy 平面上に正方形があり、4 つの頂点の座標は反時計回りに順番に (x1, y1),(x2,y2),(x3,y3),(x4,y4) です。
なお、x 軸は右向きに、y 軸は上向きに取ることにします。
高橋君は、これら 4 つの座標のうち (x3,y3),(x4,y4) を忘れてしまいました。
x1,x2,y1,y2 が与えられるので、x3,y3,x4,y4を復元してください。
なお、これらの条件から、x3,y3,x4,y4 は一意に存在し、整数となることが証明できます。

制約
∣x1∣,∣y1∣,∣x2∣,∣y2∣≤100
(x1,y1) ≠ (x2,y2)
入力はすべて整数である"
#r "nuget: FsUnit"
open System
open System.IO
open FsUnit

let len x1 y1 x2 y2 =
    (pown (x2-x1) 2) + (pown (y2-y1) 2)
    |> float |> sqrt |> int
len 0 0 0 1 |> should equal 1
len 2 3 6 6 |> should equal 5
len 31 -41 -59 26 |> 112

// 計算は原点に平行移動してから
let toOrigin2 x1 y1 x2 y2 = (x2-x1, y2-y1)
// 平行移動してから90度回転
let rot90ToOrigin2 x1 y1 x2 y2 =
    toOrigin2 x1 y1 x2 y2
    |> fun p -> (- snd p, fst p)
// 平行移動した上で三番目のベクトルを計算
let get3ToOrigin2 x1 y1 x2 y2 =
    let v2 = toOrigin2 x1 y1 x2 y2
    let v4 = rot90ToOrigin2 x1 y1 x2 y2
    (fst v2 + fst v4, snd v2 + snd v4)
// 原点に平行移動してから計算して最後に平行移動で戻す
let solve x1 y1 x2 y2 =
    let v3 = get3ToOrigin2 x1 y1 x2 y2
    let v4 = rot90ToOrigin2 x1 y1 x2 y2
    [fst v3 + x1; snd v3 + y1; fst v4 + x1; snd v4 + y1]

let x1, y1, x2, y2 = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1], x.[2], x.[3])
solve x1 y1 x2 y2
|> List.map string |> String.concat " " |> printfn "%s"

toOrigin2 0 0 0 1 |> should equal (0,1)
toOrigin2 2 3 6 6 |> should equal (4,3)
toOrigin2 31 -41 -59 26 |> should equal (-90, 67)
rot90ToOrigin2 0 0 0 1 |> should equal (-1,0)
rot90ToOrigin2 2 3 6 6 |> should equal (-3,4)
rot90ToOrigin2 31 -41 -59 26 |> should equal (-67, -90)
get3ToOrigin2 0 0 0 1 |> should equal (-1,1)
get3ToOrigin2 2 3 6 6 |> should equal (1,7)
get3ToOrigin2 31 -41 -59 26 |> should equal (-157,-23)
solve 0 0 0 1 |> should equal [-1; 1; -1; 0]
solve 2 3 6 6 |> should equal [3; 10; -1; 7]
solve 31 -41 -59 26 |> should equal [-126; -64; -36; -131]
