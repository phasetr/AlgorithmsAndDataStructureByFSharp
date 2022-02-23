@"https://atcoder.jp/contests/abc157/tasks/abc157_c
入力は全て整数
1 \leq N \leq 3
0 \leq M \leq 5
1 \leq s_i \leq N
0 \leq c_i \leq 9"
#r "nuget: FsUnit"
open FsUnit

let N,M,sc = 3,3,[|(1,'7');(3,'2');(1,'7')|]
let N,M,sc = 3,1,[|(1,'0');(3,'0')|]
let N,M,sc = 3,1,[|(1,'0')|]
@"https://atcoder.jp/contests/abc157/submissions/17687740
最大三桁の数なので全探索する.
数を文字列化して条件をみたすように書き換える.
まず桁が合わない数(文字列)を排除し,
次に不適な対象(先頭が0になってしまう数)を排除する.
条件をみたす数がない場合はtryHeadがNoneになる."
let solve N M sc =
    [|0..999|]
    |> Array.map string
    |> Array.filter (String.length >> (=) N)
    |> Array.filter (fun str ->
        sc |> Array.forall (fun (s, c) -> str.[s - 1] = c))
    |> Array.tryHead
    |> function
    | Some x -> int x
    | None -> -1

let N, M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let sc = [| for i in 1..M do (stdin.ReadLine().Split() |> fun x -> int x.[0], char x.[1]) |]
solve N M sc |> stdout.WriteLine

solve 3 3 [|(1,'7');(3,'2');(1,'7')|] |> should equal 702
solve 3 2 [|(2,'1');(2,'3')|] |> should equal -1
solve 3 1 [|(1,'0')|] |> should equal -1
solve 3 1 [|(1,'0');(3,'0')|] |> should equal -1
