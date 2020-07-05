// https://atcoder.jp/contests/abc132/tasks/abc132_c
// 解説：https://img.atcoder.jp/abc132/editorial.pdf
// まず問題の条件と同値な条件を考える
// 「ARC 用の問題と ABC 用の問題が同数」
// ⇔「（0 オリジンで）N/2 番目に難しい問題が ARC 用、（N/2 - 1）番目が ABC」
// d.[N/2] と d.[N/2 - 1] の間の数ならどれも 2 分割できる
let judge n =
    Array.sort >> fun x -> x.[n / 2] - x.[n / 2 - 1]

//let input = [| 6, [|9; 1; 4; 4; 6; 7|]; 8, [| 9; 1; 14; 5; 5; 4; 4; 14 |]; 14, [| 99592; 10342; 29105; 78532; 83018; 11639; 92015; 77204; 30914; 21912; 34519; 80835; 100000; 1 |] |]
//for n, ds in input do (judge n ds |> printfn "%d")
// expected 2; 0; 42685

[<EntryPoint>]
let main argv =
    let n = stdin.ReadLine() |> int
    stdin.ReadLine().Split()
    |> Array.map int
    |> judge n
    |> printfn "%d"
    0
