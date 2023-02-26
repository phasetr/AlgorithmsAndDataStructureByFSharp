#r "nuget: FsUnit"
open FsUnit

(*
let N,K = 10,1
*)
let solveTLE N K =
  let mysum n = n |> string |> Seq.sumBy (fun c -> int c - 48)
  let rec frec acc k = if k=0 then acc else frec (acc - mysum acc) (k-1)
  [|1..N|] |> Array.map (fun i -> frec i K)

let N,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
solve N K |> Array.iter stdout.WriteLine

solve 10 1 |> should equal [|0;0;0;0;0;0;0;0;0;9|]
