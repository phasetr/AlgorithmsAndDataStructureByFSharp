#r "nuget: FsUnit"
open FsUnit

(*
let N,K,Aa = 8,2,[|2;3|]
let N,K,Aa = 6,2,[|2;3|]
let N,K,Aa = 20,3,[|6;1;3|]
*)
let solve N K Aa =
  Array.create (N+1) false
  |> fun dp ->
   for i in 1..N do dp.[i] <- Aa |> Array.choose (fun a -> if a<=i then Some dp.[i-a] else None) |> Array.exists not
   if dp.[N] then "First" else "Second"
let N,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N K Aa |> stdout.WriteLine

solve 8 2 [|2;3|] |> should equal "First"
solve 6 2 [|2;3|] |> should equal "Second"
solve 20 3 [|6;1;3|] |> should equal "Second"
