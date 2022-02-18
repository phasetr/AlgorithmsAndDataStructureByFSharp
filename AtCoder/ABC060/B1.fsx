@"https://atcoder.jp/contests/abc060/tasks/abc060_b"
#r "nuget: FsUnit"
open FsUnit

@"Aの倍数の総和は何であれnAの形.
nA%B=Cをみたすnをチェックする.
少なくとも一つ整数を選ばなければならない条件があり,
Bによるあまりは最大B個までだから[|1..B|]で確認すればよい."
let solve A B C =
    [|1..B|]
    |> Array.choose (fun n -> if n*A%B = C then Some true else None)
    |> fun xa -> if Array.length xa = 0 then "NO" else "YES"
let A,B,C = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1], x.[2])
solve A B C |> stdout.WriteLine

solve 7 5 1 |> should equal "YES"
solve 2 2 1 |> should equal "NO"
solve 1 100 97 |> should equal "YES"
solve 40 98 58 |> should equal "YES"
solve 77 42 36 |> should equal "NO"
