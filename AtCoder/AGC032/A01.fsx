@"https://atcoder.jp/contests/agc032/tasks/agc032_a
* 入力は全て整数である。
* 1 \leq N \leq 100
* 1 \leq b_i \leq N"
#r "nuget: FsUnit"
open FsUnit

@"解説から:
問題は次のように言い換えられる.

数の書かれた N 個のボールが一列に並んでいる。
すぬけ君は左から k 番目のボールに k と書いてあるとき、
それを選んで取り除くことができる。
全てのボールを取り除くことは可能か？

二度と取り除くことができないボールが出てしまうため,
すぬけ君は取り除けるボールのうち最も右側にあるボールしか選べない.
O(N^2)かかるがいまの制約条件なら十分処理できる."
let solve N Ba =
    let bs = Ba |> Array.toList
    let check bs =
        bs |> List.mapi (fun i b -> (i+1,b))
        |> List.filter (fun (i,b) -> i=b)
        |> List.tryLast
        |> Option.map snd
    let rm bs i = List.take (i-1) bs @ List.skip i bs
    let rec f xs = function
        | [] -> xs
        | bs -> match check bs with
            | None -> [-1]
            | Some b -> f (b::xs) (rm bs b)
    f [] bs
let N = stdin.ReadLine() |> int
let Ba = stdin.ReadLine().Split() |> Array.map int
solve N Ba |> List.map stdout.WriteLine

solve 3 [|1;2;1|] |> should equal [1;1;2]
solve 2 [|2;2|] |> should equal [-1]
solve 9 [|1;1;1;2;2;1;2;3;2|] |> should equal [1;2;2;3;1;2;2;1;1]
