@"https://atcoder.jp/contests/abc063/tasks/arc075_a
入力値はすべて整数である。
1 ≤ N ≤ 100
1 ≤ s_i ≤ 100"
#r "nuget: FsUnit"
open FsUnit

let N = 3
let Ss = [|5;10;15|]
Ss |> Array.forall (fun x -> x%10=0)
let sum = Array.sum Ss
let xa = Array.sort Ss

@"全てが10の倍数なら問答無用で結論は0.

100個の数があるので完全な全探索は不可能.
全ての数の和を取って10で割れないならそれが最大.
総和が10で割れる場合が問題.
総和から最小の数を引けばよいがそれが10の倍数だと無理."
let solve N Ss =
    let min Ss = Ss |> Array.filter (fun x -> x%10<>0) |> Array.sort |> fun x -> x.[0]
    if Ss |> Array.forall (fun x -> x%10=0) then 0
    else
        let sum = Array.sum Ss
        if sum%10 <> 0 then sum
        else sum - (min Ss)
let N = stdin.ReadLine() |> int
let Ss = [| for i in 1..N do (stdin.ReadLine() |> int) |]
solve N Ss |> stdout.WriteLine

let stoi (s: string) = s.Split(" ") |> Array.map int
let sstois (s: string) = s.Split("\n") |> Array.map stoi
"5 2 8 5 1 5" |> stoi |> should equal [|5L;2L;8L;5L;1L;5L|]
@"1 2
3 4
5 6" |> sstois |> should equal [|[|1L;2L|];[|3L;4L|];[|5L;6L|]|]

solve 3 [|5;10;15|] |> should equal 25
solve 3 [|10;10;15|] |> should equal 35
solve 3 [|10;20;30|] |> should equal 0
