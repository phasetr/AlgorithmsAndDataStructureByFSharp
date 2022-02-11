@"https://atcoder.jp/contests/arc088/tasks/arc088_a"
#r "nuget: FsUnit"
open FsUnit

let solve X Y =
    seq {
        let mutable i = X
        while i <= Y do
            yield i
            i <- 2L*i
    }
    |> Seq.length

let X, Y = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1])
solve X Y |> stdout.WriteLine

solve 3L 20L |> should equal 3L
solve 25L 100L |> should equal 3
solve 314159265L 358979323846264338L |> should equal 31
