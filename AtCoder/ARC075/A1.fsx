@"https://atcoder.jp/contests/abc063/tasks/arc075_a
入力値はすべて整数である。
1 ≤ N ≤ 100
1 ≤ s_i ≤ 100"
#r "nuget: FsUnit"
open FsUnit

let solve Xs = 1L

let N = stdin.ReadLine() |> int
let Ss = [| for i in 1..N do (stdin.ReadLine() |> int) |]
solve N Ss |> stdout.WriteLine

let stoi (s: string) = s.Split(" ") |> Array.map int
let sstois (s: string) = s.Split("\n") |> Array.map stoi
"5 2 8 5 1 5" |> stoi |> should equal [|5L;2L;8L;5L;1L;5L|]
@"1 2
3 4
5 6" |> sstois |> should equal [|[|1L;2L|];[|3L;4L|];[|5L;6L|]|]

solve As |> should equal 1L
