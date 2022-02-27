@"https://atcoder.jp/contests/abc116/tasks/abc116_c
1 \leqq N \leqq 100
0 \leqq h_i \leqq 100
入力はすべて整数である。"
#r "nuget: FsUnit"
open FsUnit

@"高々100までしか列がないのである程度重い処理をかけても問題ない.
全ての花の高さがちょうどh_jになるような処理が必要なわけではなく,
最小の水やり回数さえわかればよいことに注意する.
先頭から順次処理していけばよい."
let solve N Hs =
    let rec f acc = function
        | [] -> 0
        | h::hs -> (max (h-acc) 0) + f h hs
    f 0 (List.ofArray Hs)
let N = stdin.ReadLine() |> int
let Hs = stdin.ReadLine().Split() |> Array.map int
solve N Hs |> stdout.WriteLine

solve 4 [|1;2;2;1|] |> should equal 2
solve 5 [|3;1;2;3;1|] |> should equal 5
solve 8 [|4;23;75;0;23;96;50;100|] |> should equal 221
