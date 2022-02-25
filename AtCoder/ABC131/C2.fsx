@"https://atcoder.jp/contests/abc131/submissions/11783080"
#r "nuget: FsUnit"
open FsUnit

let solve A B C D =
    let rec gcd a b =
        match (a, b) with
        | (x, 0L) -> x
        | (0L, y) -> y
        | (a, b) -> gcd b (a % b)
    let lcm a b = a * b / (gcd a b)
    let numbers x = x - x / C - x / D + x / (lcm C D)
    numbers B - numbers (A - 1L)

let A,B,C,D = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1], x.[2], x.[3])
solve A B C D |> stdout.WriteLine

solve 4L 9L 2L 3L |> should equal 2L
solve 10L 40L 6L 8L |> should equal 23L
solve 314159265358979323L 846264338327950288L 419716939L 937510582L |> should equal 532105071133627368L
