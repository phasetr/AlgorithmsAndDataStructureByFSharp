#r "nuget: FsUnit"
open FsUnit

(*
let N,A,B = 8,2,3
let N,A,B = 6,2,3
*)
let solve N A B =
  let m = min A B
  let S = A+B
  let x = (N-A)%S
  let y = (N-B)%S
  if x<m||y<m then "First" else "Second"

let N,A,B = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1],x.[2])
solve N A B |> stdout.WriteLine

solve 8 2 3 |> should equal "First"
solve 6 2 3 |> should equal "Second"

