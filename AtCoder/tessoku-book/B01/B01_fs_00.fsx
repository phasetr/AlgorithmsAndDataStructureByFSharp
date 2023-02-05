#r "nuget: FsUnit"
open FsUnit

(*
let A,B = 1,2
*)
let solve A B = A+B
let A,B = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
solve A B |> stdout.WriteLine
