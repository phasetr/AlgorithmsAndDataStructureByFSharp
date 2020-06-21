// https://atcoder.jp/contests/ABC169/tasks/abc169_e
let pair =
    function
    | [| x; y |] -> x, y
    | _ -> failwith "Error in pair"

let input isDev =
    if isDev then
        //let n = 2
        //let a = [| 1; 2 |]
        //let b = [| 2; 3 |]
        let n = 3
        let a = [| 100; 10; 1 |]
        let b = [| 100; 10000; 1000000000 |]
        n, a, b
    else
        let n = stdin.ReadLine() |> int

        let ab =
            [| for _ in 1 .. n -> stdin.ReadLine().Split() |> Array.map int |> pair |]

        n, ab |> Array.map fst |> Array.sort, ab |> Array.map snd |> Array.sort

let n, a, b = input false

let cnt =
    if n % 2 = 0 then
        // 変数なしで配列の添え字にそのまま入れると
        // 2 回計算することになるのではじめに計算しておく
        let i = n / 2 - 1
        let j = n / 2
        // 0 オリジンで計算していることに注意
        // 本来のメジアンの定義はこの 1/2 だが求める個数の勘定で 2 倍する
        // そこではじめから 1/2 をつけずに計算している
        let amed2 = a.[i] + a.[j]
        let bmed2 = b.[i] + b.[j]
        bmed2 - amed2 + 1
    else
        let i = n / 2
        let amed = a.[i]
        let bmed = b.[i]
        bmed - amed + 1

cnt |> printfn "%d"
