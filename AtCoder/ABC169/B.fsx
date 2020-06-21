(*
https://atcoder.jp/contests/abc169/tasks/abc169_b

64bit 整数でそのまま掛け算を行うとオーバーフローします。
倍精度浮動小数点数で計算を行うと精度が足りません。
多倍長整数で最後まで計算すると TLE します。
したがって何らかの工夫が必要です。

cf. F# (.NET Core) にも BigInteger がある.
https://docs.microsoft.com/ja-jp/dotnet/api/system.numerics.biginteger?view=netcore-3.1
9223372036854775807
*)

let bTest =
    [| [| 1000000000L; 1000000000L |]
       [| 101L
          9901L
          999999000001L
          1000000000000000000L |]
       Array.concat
           [| [| 1L .. 9L |]
              [| 1L .. 9L |]
              [| 1L .. 9L |]
              [| 1L .. 3L |]
              [| 0L |] |]
       Array.create 10000 2L |]


/// 既定の値を超えたら true
/// 掛け算の代わりに割り算で判定
let checkOverFlow (x: int64) (y: int64) = x > 1000000000000000000L / y

// let rec の中で List.contains の判定を入れると重くて 2 秒を超える
let rec fb (x: int64) (xs: int64 list) =
    match xs with
    | y :: ys -> if checkOverFlow x y then -1L else fb (x * y) ys
    | [] -> x

let main =
    stdin.ReadLine() |> ignore
    let b = stdin.ReadLine().Split(' ') |> Array.map int64
    if Array.contains 0L b
    then printfn "%d" 0
    else b |> List.ofArray |> fb 1L |> printfn "%d"

bTest
|> Array.map (List.ofArray >> fb 1L >> printfn "%d")
