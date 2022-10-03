#r "nuget: FsUnit"
open FsUnit

let solve (A:bigint) (B:bigint) = A+B

let A,B = stdin.ReadLine().Split() |> Array.map bigint |> (fun x -> x.[0],x.[1])
solve A B |> stdout.WriteLine

solve 5I 8I |> should equal 13I
solve 100I 25I |> should equal 125I
solve -1I 1I |> should equal 0I
solve 12I -3I |> should equal 9I
