#r "nuget: FsUnit"
open FsUnit

(*
let N,K,Aa = 7,50,[|11;12;16;22;27;28;31|]
*)
let solve N K (Aa:int[]) =
  let rec frec p t = if p<N && t+Aa.[p]<=K then frec (p+1) (t+Aa.[p]) else (p,t)
  ((0,0,0), [|0..N-1|])
  ||> Array.fold (fun (p,t,c) i -> frec p t |> fun (q,s) -> (q,s-Aa.[i],c+q-i))
  |> fun (_,_,c) -> c
let N,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N K Aa |> stdout.WriteLine

solve 7 50 [|11;12;16;22;27;28;31|] |> should equal 13
