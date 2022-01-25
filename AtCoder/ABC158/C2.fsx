#r "nuget: FsUnit"
open FsUnit

let solve A B =
    seq { 0 .. 1009 }
    |> Seq.tryFind (fun price -> price * 8 / 100 = A && price / 10 = B)
    |> function
        | Some price -> price
        | None -> -1

let A, B = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
solve A B |> stdout.WriteLine

solve 2 2 |> should equal 25
solve 8 10 |> should equal 100
solve 19 99 |> should equal -1
