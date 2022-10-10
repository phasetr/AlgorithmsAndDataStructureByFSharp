#r "nuget: FsUnit"
open FsUnit

let solve A B X = let f n = if n=(-1L) then 0L else n/X+1L in f B - f (A-1L)
let A,B,X = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0],x.[1],x.[2])
solve A B X |> stdout.WriteLine

solve 4L 8L 2L |> should equal 3L
solve 0L 5L 1L |> should equal 6L
solve 1L 1000000000000000000L 3L |> should equal 333333333333333333L
