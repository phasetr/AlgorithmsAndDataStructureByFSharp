@"https://atcoder.jp/contests/agc035/tasks/agc035_a
* 入力は全て整数
* 3 \leq N \leq 10^{5}
* 0 \leq a_i \leq 10^{9}"
#r "nuget: FsUnit"
open FsUnit

@"端的に書けば,
「正しいかぶせ方は{a;b;c;a;b;c;a;...}かつa^^^b=cが成立」.

解説から:
条件は連続する3つの帽子に書かれた数のビットごとの排他的論理和が0と同値.
ここから円環上で連続する4つの数
xi, xi+1, xi+2, xi+3 に着目すると、
xi ⊕ xi+1 ⊕ xi+2 = xi+1 ⊕ xi+2 ⊕ xi+3 = 0によって
xi = xi+3 が成り立つ.

条件をみたすのは次の場合.
- 全ての帽子に書かれた数が 0
- x が書かれた帽子が 2N/3 枚、0 が書かれた数が N/3 枚
- x ⊕ y ⊕ z = 0 をみたす 3 つの相異なる整数 x, y, z が書かれた帽子がそれぞれ N/3 枚"
let solve N Aa =
    let chk (a,ia) (b,ib) (c,ic) =
        ([|ia;ib;ic|] |> Array.max) - ([|ia;ib;ic|] |> Array.min) = 0
        && a ^^^ b = c
    Aa |> Array.countBy id
    |> function
        | [|(0,ia)|] -> "Yes"
        | [|(a,ia);(b,ib);(c,ic)|] when chk (a,ia) (b,ib) (c,ic) -> "Yes"
        | [|(a,ia);(b,ib)|] ->
            match [|(a,ia);(b,ib)|] |> Array.sortBy fst with
            | [|(0,ia);(b,ib)|] when ib = 2 * ia -> "Yes"
            | _  -> "No"
        | _ -> "No"
let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> stdout.WriteLine

solve 3 [|1;2;3|] |> should equal "Yes"
solve 4 [|1;2;4;8|] |> should equal "No"
