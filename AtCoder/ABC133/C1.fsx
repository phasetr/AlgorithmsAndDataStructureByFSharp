@"https://atcoder.jp/contests/abc133/tasks/abc133_c
入力は全て整数
0 \leq L < R \leq 2 \times 10^9"
#r "nuget: FsUnit"
open FsUnit

@"数が多いので全探索は無理.
もしLまたはRが2019より大きければその分は無視して計算できる."
let solve L R =
    let n = 2019L
    if n <= R-L then 0L
    else [| for i in [|L..R-1L|] do
          for j in [|i+1L..R|] do yield (i%n)*((j%n))%n |]
          |> Array.min
let L,R = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1])
solve L R |> stdout.WriteLine

solve 2020L 2040L |> should equal 2L
solve 4L 5L |> should equal 20L
