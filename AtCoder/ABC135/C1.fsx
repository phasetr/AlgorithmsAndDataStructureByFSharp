@"https://atcoder.jp/contests/abc135/tasks/abc135_c"
#r "nuget: FsUnit"
open FsUnit

@"左端から考える.
勇者は左からP_iと呼ぶことにする.
A1はP1が処理するしかなく最大の労力を割く.
余りをA2にあてる.
P2は残りのA2を処理し, 余ればA3にあてる."
let solve N As Bs =
    // 後ろではなく前に足す
    let BsAdd = Array.append [|0L|] Bs
    ((0L,0L), As, BsAdd)
    |||> Array.fold2 (
        fun (accN, accRem) a b ->
        let kill1 = min b accRem
        let bRem = max (b - accRem) 0L
        let kill2 = min a bRem
        let rem = max (a - bRem) 0L
        (accN + kill1 + kill2, rem))
    |> fun (accN, _) -> accN
let N = stdin.ReadLine() |> int
let As = stdin.ReadLine().Split() |> Array.map int64
let Bs = stdin.ReadLine().Split() |> Array.map int64
solve N As Bs |> stdout.WriteLine

solve 2 [|3L;5L;2L|] [|4L;5L|] |> should equal 9L
solve 3 [|5L;6L;3L;8L|] [|5L;100L;8L|] |> should equal 22L
solve 2 [|100L;1L;1L|] [|1L;100L|] |> should equal 3L
