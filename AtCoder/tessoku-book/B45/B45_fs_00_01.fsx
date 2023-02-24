#r "nuget: FsUnit"
open FsUnit

(*
let A,B,C = 3L,(-4L),1L
*)
let solve A B C = if A+B+C = 0L then "Yes" else "No"
let A,B,C = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0],x.[1],x.[2])
solve A B C |> stdout.WriteLine

solve 3L (-4L) 1L |> should equal "Yes"
