#r "nuget: FsUnit"
open FsUnit

let N,K,Xa = 5,3,[|-30;-10;10;20;50|]
let N,K,Xa = 8,5,[|-9;-7;-4;-3;1;2;3;4|]
let solve N K (Xa:int[]) =
  let f x y = y-x + (min (abs x) (abs y))
  (System.Int32.MaxValue,[|0..(N-K)|]) ||> Array.fold (fun acc i -> min acc (f Xa.[i] Xa.[i+K-1]))

let N,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Xa = stdin.ReadLine().Split() |> Array.map int
solve N K Xa |> stdout.WriteLine

solve 5 3 [|-30;-10;10;20;50|] |> should equal 40
solve 3 2 [|10;20;20|] |> should equal 20
solve 1 1 [|0|] |> should equal 0
solve 8 5 [|-9;-7;-4;-3;1;2;3;4|] |> should equal 10
