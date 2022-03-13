@"https://atcoder.jp/contests/abc118/tasks/abc118_c
- 入力は全て整数である。
- 2 \leq N \leq 10^5
- 1 \leq A_i \leq 10^9"
#r "nuget: FsUnit"
open FsUnit

@"解説から: 最大公約数が答え."
let solve N Aa =
    let rec gcd a b =
        let (s, l) = if a < b then (a, b) else (b, a)
        let r = l % s
        if r = 0 then s else gcd r s
    Aa |> Array.reduce gcd
let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> stdout.WriteLine

solve 4 [|2;10;8;40|] |> should equal 2
solve 4 [|5;13;8;1000000000|] |> should equal 1
solve 3 [|1000000000;1000000000;1000000000|] |> should equal 1000000000
