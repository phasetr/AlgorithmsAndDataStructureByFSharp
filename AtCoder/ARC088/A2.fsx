@"https://atcoder.jp/contests/arc088/submissions/16473122"
#r "nuget: FsUnit"
open FsUnit

let solve X Y =
    let rec f x y =
        if y < x then []
        else [x] @ f (x*2L) y
    f X Y |> List.length

let X, Y = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1])
solve X Y |> stdout.WriteLine

solve 3L 20L |> should equal 3
solve 25L 100L |> should equal 3
solve 314159265L 358979323846264338L |> should equal 31
