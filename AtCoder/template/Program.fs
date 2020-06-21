
(*
問題 https://atcoder.jp/contests/abc169/tasks/abc169_f
公式の解説 https://img.atcoder.jp/abc169/editorial.pdf
参考 https://atcoder.jp/contests/abc169/submissions/14018589
*)
let p = 998244353

let f s a =
    let ys = Array.map ((*) 2) a
    let zs = Array.zeroCreate (Array.length a)
    Array.map2 (fun x y -> (x+y) % p) ys zs

let g s xs =
    let init = Array.append [| 1 |] (Array.zeroCreate s)
    Array.foldBack f init xs |> Array.last

let input = [| (3, 4, [|2; 2 ; 4|]); (5, 8, [|9; 9 ; 9 ; 9; 9|]); (10, 10, [|3; 1; 4; 1; 5; 9; 2; 6; 5; 3|] ) |]
let n, s, a = input.[0]
for (n,s,a) in input do g s a |> printfn "%A"

[<EntryPoint>]
let main argv =
    let input1 = stdin.ReadLine().Split(' ')
    let n = input1.[0] |> int
    let s = input1.[1] |> int
    let a = stdin.ReadLine().Split(' ') |> Array.map int
    printfn "%A" a
    0
