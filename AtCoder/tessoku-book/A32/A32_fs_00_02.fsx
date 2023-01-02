#r "nuget: FsUnit"
open FsUnit

(*
let N,A,B = 8,2,3
let N,A,B = 6,2,3
*)
let solve N A B =
  let x,y = if A<B then A,B else B,A
  (Array.create (N+1) false, [|0..N|])
  ||> Array.fold (fun dp i ->
    if x<=i && i<y then dp.[i] <- not dp.[i-x]
    if y<=i then dp.[i] <- not (dp.[i-x] && dp.[i-y])
    dp)
  |> Array.last |> fun b -> if b then "First" else "Second"

let N,A,B = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1],x.[2])
solve N A B |> stdout.WriteLine

solve 8 2 3 |> should equal "First"
solve 6 2 3 |> should equal "Second"
