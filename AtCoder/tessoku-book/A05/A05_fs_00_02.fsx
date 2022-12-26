#r "nuget: FsUnit"
open FsUnit

(*
let N,K = 3,6
let N,K = 3000,4000
*)
let solve N K =
  [| for i in 1..N do for j in 1..N do let x=K-i-j in if 1<=x && x<=N then x |] |> Array.length

let N,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
solve N K |> stdout.WriteLine

solve 3 6 |> should equal 7
solve 3000 4000 |> should equal 6498498
