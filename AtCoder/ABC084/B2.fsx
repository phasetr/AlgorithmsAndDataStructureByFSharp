#r "nuget: FsUnit"
open System
open System.IO
open FsUnit

let solve A B (S: string) =
    S.Split('-')
    |> function
        | [|sa; sb|] when sa.Length = A && sb.Length = B -> "Yes"
        | _ -> "No"

let A, B = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let S = stdin.ReadLine()
solve A B S |> printfn "%s"

solve 3 4 "269-6650" |> should equal "Yes"
solve 1 1 "---" |> should equal "No"
solve 1 2 "7444" |> should equal "No"
