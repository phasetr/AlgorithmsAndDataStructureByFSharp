(*
https://atcoder.jp/contests/abc086/tasks/arc089_a
https://qiita.com/kuuso1/items/606b75c172cafa1d07f6#%E7%AC%AC-10-%E5%95%8F-abc-086-c---traveling
*)
#nowarn "25"

// d <= dt は時間・距離・速度から来る制約
// 設定から毎秒 x+y の偶奇が変わり、それが時間の偶奇とも一致する必要がある：具体例で考えるとわかる
// そして上の注意の逆も成り立つのがポイント
let checkCoords (((t1, x1, y1), (t2, x2, y2))) =
    let dt: int = t2 - t1
    let d: int = (abs (x2 - x1)) + (abs (y2 - y1))
    d <= dt && (d % 2 = dt % 2)

let fc =
    Array.pairwise
    >> Array.map checkCoords
    >> Array.fold (&&) true
    >> fun x -> if x then "Yes" else "No"

//let input = [| [| (0, 0, 0); (3, 1, 2); (6, 1, 1) |]; [| (0,0,0); (2,100,100) |]; [| (0,0,0); (5,1,1); (100,1,1) |] |]
//for i in input do fc i |> printfn "%s"

[<EntryPoint>]
let main argv =
    let n = stdin.ReadLine() |> int
    let targetCoords: (int * int * int) [] = Array.zeroCreate (n + 1)
    targetCoords.[0] <- (0, 0, 0)
    for i in [ 1 .. n ] do
        let [| x; y; z |] = stdin.ReadLine().Split(' ') |> Array.map int
        targetCoords.[i] <- (x, y, z)
    targetCoords |> fc |> printfn "%s"
    0
