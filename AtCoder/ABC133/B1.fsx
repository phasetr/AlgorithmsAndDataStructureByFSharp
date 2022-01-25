@"https://atcoder.jp/contests/abc133/tasks/abc133_b
問題文
D 次元空間上に N 個の点があります。
i 番目の点の座標は (X_{i1},X_{i2},,...,X_{iD}) です。

座標 (y1,y2,...,yD) の点と座標 (z1,z2,...,zD) の点の距離はl^2ノルムで定義します.
i 番目の点と j 番目の点の距離が整数となるような組
(i,j) (i<j) はいくつあるでしょうか。

制約
入力は全て整数である。
2≤N≤10
1≤D≤10
−20≤X_{ij}≤20
同じ座標の点は与えられない。
すなわち、i \neq j ならばX_{ik} \neq X_{jk} なる k が存在する。"
#r "nuget: FsUnit"
open FsUnit

// From Reference.fsx
let isPerfectSquare n =
    let h = n &&& 0xF
    if (h > 9) then false
    else
        if ( h <> 2 && h <> 3 && h <> 5 && h <> 6 && h <> 7 && h <> 8 ) then
            let t = ((n |> double |> sqrt) + 0.5) |> floor|> int
            t*t = n
        else false
let distSq ys zs = Array.fold2 (fun acc y z -> acc + (pown (y-z) 2)) 0 ys zs

let solve N D (xss: array<array<int>>) =
    [|0..(N-1)|]
    |> Array.collect (fun i -> [|(i+1)..(N-1)|] |> Array.map (fun j -> (i,j)))
    |> Array.choose (fun (i,j) -> if isPerfectSquare (distSq xss.[i] xss.[j]) then Some (i,j) else None)
    |> Array.length

let N, D = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Xss = [| for i in 1..N do (stdin.ReadLine().Split() |> Array.map int) |]
solve N D Xss |> stdout.WriteLine

solve 3 2 [|[|1;2|]; [|5;5|]; [|-2;8|]|] |> should equal 1
solve 3 4 [|[|-3;7;8;2|]; [|-12;1;10;2|]; [|-2;8;9;3|]|] |> should equal 2
solve 5 1 [|[|1|]; [|2|]; [|3|]; [|4|]; [|5|]|] |> should equal 10
