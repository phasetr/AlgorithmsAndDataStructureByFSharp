@"https://atcoder.jp/contests/abc073/tasks/abc073_c
1≦N≦100000
1≦A_i≦1000000000(=10^9)
入力は全て整数である。"
#r "nuget: FsUnit"
open FsUnit

@"いちいちチェックしていたら処理時間オーバーする?
groupbyして奇数回なら取り込む,
偶数回なら外すとすればよいか?

ここではgroupByにしたがcountByがよい.
C2.fsx参照."
let solve N As =
    As |> Array.groupBy id
    |> Array.fold (fun acc (_, na) ->
        if Array.length na % 2 = 1 then acc+1 else acc) 0

let N = stdin.ReadLine() |> int
let As = [| for i in 1..N do (stdin.ReadLine() |> int) |]
solve N As |> stdout.WriteLine

solve 3 [|6;2;6|] |> should equal 1
solve 4 [|2;5;5;2|] |> should equal 0
solve 6 [|12;22;16;22;18;12|] |> should equal 2
