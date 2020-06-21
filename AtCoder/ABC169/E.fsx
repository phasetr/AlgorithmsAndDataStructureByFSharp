// https://atcoder.jp/contests/ABC169/tasks/abc169_e
// TLE になったので不適格
let pair =
    function
    | [| x; y |] -> x, y
    | _ -> failwith "Error in pair"

let median (xs: int array) =
    let n = xs |> Array.length
    let ys = Array.sort xs
    let m = n - 1 // 0 オリジンで計算する
    if n % 2 = 0 then (ys.[m / 2] + ys.[m / 2 + 1]) / 2 else ys.[(m + 1) / 2]

let countMedian n amed bmed =
    if n % 2 = 0
    then [| 2 * amed .. 2 .. 2 * bmed |] |> Array.length
    else [| amed .. bmed |] |> Array.length

let fe isDev =
    let n, a, b =
        if isDev then
            let n = 3
            let a = [| 100; 10; 1 |]
            let b = [| 100; 10000; 1000000000 |]
            n, a, b
        else
            let n = stdin.ReadLine() |> int

            let ab =
                [| for _ in 1 .. n -> stdin.ReadLine().Split() |> Array.map int |> pair |]

            n, ab |> Array.map fst, ab |> Array.map snd

    let amed = a |> median
    let bmed = b |> median
    countMedian n amed bmed |> printfn "%d"

fe false
