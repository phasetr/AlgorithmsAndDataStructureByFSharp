@"https://atcoder.jp/contests/abc055/tasks/abc055_b"
#r "nuget: FsUnit"
open FsUnit

let solve N =
    let rec fact acc n =
        if n = 0L then 0L
        elif n = 1L then acc
        else fact ((acc * n) % ((int64 (pown 10 9)) + 7L)) (n-1L)
    fact 1L N

let N = stdin.ReadLine() |> int64
solve N |> stdout.WriteLine

solve 3L |> should equal 6
solve 10L |> should equal 3628800
solve 100000L |> should equal 457992974
