// https://atcoder.jp/contests/abc86/tasks/abc085_b
// https://qiita.com/kuuso1/items/606b75c172cafa1d07f6#%E7%AC%AC-7-%E5%95%8F-abc-085-b---kagami-mochi

let bTest = [| 10; 8; 8; 6 |]
let fb: int [] -> int = Array.distinct >> Array.length
bTest |> fb |> printfn "%d"

let main =
    let readInt () = stdin.ReadLine() |> int
    let bN = stdin.ReadLine() |> int
    let b = Array.zeroCreate bN

    for i in [ 0 .. bN - 1 ] do
        b.[i] <- readInt ()

    b |> fb |> printfn "%d"
