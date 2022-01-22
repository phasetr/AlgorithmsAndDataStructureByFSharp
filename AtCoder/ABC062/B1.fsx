"https://atcoder.jp/contests/abc062/tasks/abc062_b
縦 H ピクセル、横 W ピクセルの画像があります。
各ピクセルは英小文字で表されます。
上から i 番目、左から j 番目のピクセルは a_{ij}です。
この画像の周囲 1 ピクセルを # で囲んだものを出力してください。

制約
1≤H,W≤100
a_{ij}は英小文字である。"
#r "nuget: FsUnit"
open FsUnit

let solve H W (As: array<string>) =
    let onlySharp = String.replicate (W+2) "#"
    let f i =
        if i = 0 || i = H+1 then onlySharp
        else "#" + As.[i-1] + "#"
    [|0..H+1|] |> Array.map f
let H, W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let As = [| for i in 1..H do (stdin.ReadLine()) |]
solve H W As |> String.concat "\n" |> printfn "%s"

solve 2 3 [|"abc";"arc"|] |> should equal [|"#####";"#abc#";"#arc#";"#####"|]
solve 1 1 [|"z"|] |> should equal [|"###";"#z#";"###"|]
