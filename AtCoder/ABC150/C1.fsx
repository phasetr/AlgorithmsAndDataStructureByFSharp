@"
https://atcoder.jp/contests/abc150/tasks/abc150_c
大きさ N の順列 ((1, 2, ..., N) を並び替えてできる数列) P, Q があります。
大きさ N の順列は N! 通り考えられます。
このうち、P が辞書順で a 番目に小さく、
Q が辞書順で b 番目に小さいとして、∣a−b∣ を求めてください。

注記
2 つの数列 X, Y について、
ある整数 k が存在して Xi=Y (1≤i<k) かつ
Xk<Yk が成り立つとき、
X は Y より辞書順で小さいと定義されます。

制約
2≤N≤8
P, Q は大きさ N の順列である。
入力は全て整数である。
"
#r "nuget: FsUnit"
open System
open System.IO
open FsUnit

// F#ではList.collectで定義されていた
let concatMap f xs = List.map f xs |> List.concat
let rec choose xs =
    match xs with
    | [] -> []
    | x::xs -> (x, xs) :: List.map (fun (y, ys) -> (y, x::ys)) (choose xs)
let rec permutations xs =
    match xs with
    | [] -> [[]]
    | xs ->
        choose xs
        |> concatMap (fun (y, ys) -> List.map (fun zs -> y::zs) (permutations ys))
let solve N P Q =
    if P = Q then 0
    else
        permutations [1..N]
        |> List.mapi (fun i x -> (i+1,x)) // ここはpermutationsの中でできるはず
        |> List.filter (fun (i,x) -> x = P || x = Q)
        |> (fun [x;y] -> abs ((fst x) - (fst y)))

let N = stdin.ReadLine() |> int
let P = stdin.ReadLine().Split() |> Array.toList |> List.map int
let Q = stdin.ReadLine().Split() |> Array.toList |> List.map int
solve N P Q |> printfn "%A"

choose [1;2;3] |> should equal [(1, [2; 3]); (2, [1; 3]); (3, [1; 2])]
permutations [1;2] |> should equal [[1;2]; [2;1]]
permutations [1;2;3] |> should equal [[1; 2; 3]; [1; 3; 2]; [2; 1; 3]; [2; 3; 1]; [3; 1; 2]; [3; 2; 1]]
solve 3 [1; 3; 2] [3; 1; 2] |> should equal 3
solve 8 [7; 3; 5; 4; 2; 1; 6; 8] [3; 8; 2; 5; 4; 6; 7; 1]
|> should equal 17517
solve 3 [1;2;3] [1;2;3] |> should equal 0
