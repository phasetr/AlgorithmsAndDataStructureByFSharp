(*
問題 https://atcoder.jp/contests/abc169/tasks/abc169_f
公式の解説 https://img.atcoder.jp/abc169/editorial.pdf
参考 https://atcoder.jp/contests/abc169/submissions/14018589
C++ のコード、ABC169F.cpp も適宜参照すること。

動的計画法の走らせ方
- calcN の init は DP[0][0] = 1 (他は 0 で初期化) を表す。
- DP[i][j] を全て保持しているわけではなく j の分だけを保持していて i は都度上書きしているイメージ。
*)
let p = 998244353

// C++ のコードでの S のループ
let calcS a acc =
    // 記号は解説参照：a_i が T に選ばれている場合、または T に入るが U に入らない場合
    let bs = Array.map ((*) 2) acc
    // a_i が T にも U にも選ばれた場合
    let cs = Array.append (Array.zeroCreate a) acc.[0..(acc.Length - a - 1)]
    Array.map2 (fun x y -> (x + y) % p) bs cs

// C++ のコードでの N のループ
let calcN s a =
    let init = Array.append [| 1 |] (Array.zeroCreate s)
    Array.foldBack calcS a init |> Array.last

//for (_, s, a) in [| (3, 4, [| 2; 2; 4 |]); (5, 8, [| 9; 9; 9; 9; 9 |]); (10, 10, [| 3; 1; 4; 1; 5; 9; 2; 6; 5; 3 |]) |] do calcN s a |> printfn "%A"

[<EntryPoint>]
let main argv =
    let input1 = stdin.ReadLine().Split(' ')
    let s = input1.[1] |> int
    let a = stdin.ReadLine().Split(' ') |> Array.map int
    calcN s a |> printfn "%i"
    0
