@"https://atcoder.jp/contests/abc093/tasks/arc094_a"
#r "nuget: FsUnit"
open FsUnit

let solve A B C =
    let rec f s m =
        let tar = 3*m
        if (s%2 = tar%2) then (tar-s) / 2
        else f s (m+1)

    let s = A+B+C
    let m = Array.max [|A;B;C|]
    f s m

let A,B,C = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1], x.[2])
solve A B C |> stdout.WriteLine

solve 2 5 4 |> should equal 2
solve 2 6 3 |> should equal 5
solve 31 41 5 |> should equal 23
