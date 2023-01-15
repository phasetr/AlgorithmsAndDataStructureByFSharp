#r "nuget: FsUnit"
open FsUnit

let solve A B =
  let a,b = if A<B then (A,B) else (B,A)
  match a,b with
    | 1,2 | 1,3 | 2,4 | 2,5 | 3,6 | 3,7 | 4,8 | 4,9 | 5,10 | 5,11 | 6,12 | 6,13 | 7,14 | 7,15 -> "Yes"
    | _ -> "No"

let A,B = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
solve A B |> stdout.WriteLine

solve 1 2 |> should equal "Yes"
solve 2 8 |> should equal "No"
solve 14 15 |> should equal "No"
