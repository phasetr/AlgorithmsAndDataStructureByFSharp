@"問題文
N 個のレンガが横一列に並んでいます。

左から i (1≤i≤N) 番目のレンガには、整数 ai が書かれています。
あなたはこのうち N−1 個以下の任意のレンガを選んで砕くことができます。
その結果、K 個のレンガが残っているとします。
このとき、任意の整数 i (1≤i≤K) について、
残っているレンガの中で左から i 番目のものに書かれた整数が i であるとき、
すぬけさんは満足します。

すぬけさんが満足するために砕く必要のあるレンガの最小個数を出力してください。
もし、どのように砕いてもそれが不可能な場合、代わりに -1 を出力してください。

制約
入力は全て整数である。
1≤N≤200000
1≤ai≤N"
#r "nuget: FsUnit"
open FsUnit

@"左から1,2,3を順に拾っていけばよく,
これをnumとして積む.
numに一致しない場合はaccを+1して積んでいく.
numが初期値のままならどう砕いても不可能."
let solve N As =
    As
    |> Array.fold (fun (num, acc) a -> if a = num+1 then (a, acc) else (num, acc+1)) (0,0)
    |> fun (num,acc) -> if num = 0 then -1 else acc
let N = stdin.ReadLine() |> int
let As = stdin.ReadLine().Split() |> Array.map int
solve N As |> stdout.WriteLine

solve 3 [|2;1;2|] |> should equal 1
solve 3 [|2;2;2|] |> should equal -1
solve 10 [|3;1;4;1;5;9;2;6;5;3|] |> should equal 7
solve 1 [|1|] |> should equal 0
