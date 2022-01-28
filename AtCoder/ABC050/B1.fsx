@"https://atcoder.jp/contests/abc050/tasks/abc050_b
問題文
joisinoお姉ちゃんは、あるプログラミングコンテストの決勝を控えています。
このコンテストでは、N 問の問題が用意されており、
それらには 1～N の番号がついています。
joisinoお姉ちゃんは、
問題 i(1≦i≦N) を解くのにかかる時間がT_i秒であることを知っています。

また、このコンテストでは、
M 種類のドリンクが提供されており、
1～M の番号がついています。
そして、ドリンク i(1≦i≦M) を飲むと、脳が刺激され、
問題Piを解くのにかかる時間がXi秒になります。
他の問題を解くのにかかる時間に変化はありません。

コンテスタントは、
コンテスト開始前にいずれかのドリンクを 1 本だけ飲むことができます。
joisinoお姉ちゃんは、それぞれのドリンクについて、
それを飲んだ際に、全ての問題を解くのに何秒必要なのかを知りたくなりました。
全ての問題を解くのに必要な時間とは、
それぞれの問題を解くのにかかる時間の合計です。
あなたの仕事は、
joisinoお姉ちゃんの代わりにこれを求めるプログラムを作成することです。

制約
入力は全て整数である
1≦N≦100
1≦T_i≦10^5
1≦M≦100
1≦Pi≦N
1≦X_i≦10^5"
#r "nuget: FsUnit"
open FsUnit

let solve N Ts M pxs =
    let calc p x Ts =
        let f acc (i,t) = if i+1 = p then acc+x else acc+t
        Ts |> Array.indexed
        |> Array.fold f 0
    pxs |> Array.map (fun (p,x) -> calc p x Ts)

let N = stdin.ReadLine() |> int
let Ts = stdin.ReadLine().Split() |> Array.map int
let M = stdin.ReadLine() |> int
let pxs = [| for i in 1..M do (stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0], x.[1]) |]
solve N Ts M pxs |> Array.map string |> String.concat "\n" |> stdout.WriteLine

solve 3 [|2;1;4|] 2 [|(1,1); (2,3)|] |> should equal [|6;9|]
solve 5 [|7;2;3;8;5|] 3 [|(4,2);(1,7);(4,13)|] |> should equal [|19;25;30|]
