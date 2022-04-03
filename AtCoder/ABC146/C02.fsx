@"https://atcoder.jp/contests/abc146/submissions/9299999"
#r "nuget: FsUnit"
open FsUnit

let solve a b x =
    let chk n = (a*n + b*(int64 (n.ToString().Length))) <= x
    let rec loop ok ng =
        if (abs (ok - ng)) = 1L then ok
        else
            let mid = (ok + ng) / 2L
            if (chk mid) then loop mid ng else loop ok mid
    loop 0L 1000000001L
let A,B,X = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1], x.[2])
solve A B X |> stdout.WriteLine

solve 10L 7L 100L |> should equal 9L
solve 2L 1L 100000000000L |> should equal 1000000000L
solve 1000000000L 1000000000L 100L |> should equal 0L
solve 1234L 56789L 314159265L |> should equal 254309L
