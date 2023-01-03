#r "nuget: FsUnit"
open FsUnit

(*
let N,K = 5,10
*)
let solve N K = let n = 2*(N-1) in if n<=K && (K-n)%2=0 then "Yes" else "No"

let N,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
solve N K |> stdout.WriteLine

solve 5 10 |> should equal "Yes"
