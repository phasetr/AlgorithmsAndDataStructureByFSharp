#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa,Q,K,Xa = 5,[|(1,2,1L);(1,3,1L);(2,4,1L);(3,5,1L)|],3,1,[|(2,4);(2,3);(4,5)|]
let N,Aa,Q,K,Xa = 7,[|(1,2,1L);(1,3,3L);(1,4,5L);(1,5,7L);(1,6,9L);(1,7,11L)|],3,2,[|(1,3);(4,5);(6,7)|]
let N,Aa,Q,K,Xa = 10,[|(1,2,1000000000L);(2,3,1000000000L);(3,4,1000000000L);(4,5,1000000000L);(5,6,1000000000L);(6,7,1000000000L);(7,8,1000000000L);(8,9,1000000000L);(9,10,1000000000L)|],1,1,[|(9,10)|]
*)
let solve N (Aa:(int*int*int64)[]) Q K Xa =
  let Ga =
    (Array.init N (fun _ -> []), Aa)
    ||> Array.fold (fun Ga (a,b,c) -> Ga.[a-1] <- (b-1,c)::Ga.[a-1]; Ga.[b-1] <- (a-1,c)::Ga.[b-1]; Ga)
  let rec dfs v p d Da =
    Array.set Da v d
    (Da, Ga.[v]) ||> List.fold (fun Da (u,c) -> if u=p then Da else dfs u v (d+c) Da)
  let Da = Array.zeroCreate N |> dfs (K-1) (-1) 0L
  Xa |> Array.map (fun (x,y) -> Da.[x-1]+Da.[y-1])

let N = stdin.ReadLine() |> int
let Aa = Array.init (N-1) (fun _ -> stdin.ReadLine().Split() |> fun x -> int x.[0], int x.[1], int64 x.[2])
let Q,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Xa = Array.init Q (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N Aa Q K Xa |> Array.iter stdout.WriteLine

solve 5 [|(1,2,1L);(1,3,1L);(2,4,1L);(3,5,1L)|] 3 1 [|(2,4);(2,3);(4,5)|] |> should equal [|3L;2L;4L|]
solve 7 [|(1,2,1L);(1,3,3L);(1,4,5L);(1,5,7L);(1,6,9L);(1,7,11L)|] 3 2 [|(1,3);(4,5);(6,7)|] |> should equal [|5L;14L;22L|]
solve 10 [|(1,2,1000000000L);(2,3,1000000000L);(3,4,1000000000L);(4,5,1000000000L);(5,6,1000000000L);(6,7,1000000000L);(7,8,1000000000L);(8,9,1000000000L);(9,10,1000000000L)|] 1 1 [|(9,10)|] |> should equal [|17000000000L|]
