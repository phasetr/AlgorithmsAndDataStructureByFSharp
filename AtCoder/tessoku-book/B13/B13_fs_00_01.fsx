#r "nuget: FsUnit"
open FsUnit

(*
let N,K,Aa = 7,50,[|11;12;16;22;27;28;31|]
*)
let solve N K (Aa:int[]) =
  let mutable p,t,c = 0,0,0
  for i in 0..N-1 do
    while p<N && t+Aa.[p]<=K do
      p <- p+1
      t <- t+Aa.[p]
    t <- t-Aa.[i]
    c <- c+p-i
  c
let N,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N K Aa |> stdout.WriteLine

solve 7 50 [|11;12;16;22;27;28;31|] |> should equal 13
