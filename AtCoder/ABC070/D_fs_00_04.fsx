// https://atcoder.jp/contests/abc070/submissions/9907017
#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa,Q,K,Xa = 5,[|(1,2,1L);(1,3,1L);(2,4,1L);(3,5,1L)|],3,1,[|(2,4);(2,3);(4,5)|]
let N,Aa,Q,K,Xa = 7,[|(1,2,1L);(1,3,3L);(1,4,5L);(1,5,7L);(1,6,9L);(1,7,11L)|],3,2,[|(1,3);(4,5);(6,7)|]
let N,Aa,Q,K,Xa = 10,[|(1,2,1000000000L);(2,3,1000000000L);(3,4,1000000000L);(4,5,1000000000L);(5,6,1000000000L);(6,7,1000000000L);(7,8,1000000000L);(8,9,1000000000L);(9,10,1000000000L)|],1,1,[|(9,10)|]
*)
let dijkstra N k (Ga: (int * int64) list []) =
  let Da = Array.create N System.Int64.MaxValue
  Da.[k] <- 0L
  let rec loop (Da:int64[]) q =
    if Map.isEmpty q then (Da,q)
    else
      let ((c,v),_) = Map.minKeyValue q
      let q0 = Map.remove (c,v) q
      if c <= Da.[v] then
        ((Da,q0), Ga.[v]) ||> List.fold (fun (Da,q) (bi,ci) ->
          let s = Da.[v]+ci
          if s < Da.[bi] then Da.[bi] <- s; (Da, Map.add (s,bi) bi q) else (Da,q))
      else (Da,q0)
      |> fun (Da,q) -> loop Da q
  loop Da (Map [((0L,k),k)]) |> fst

let solve N (Aa:(int*int*int64)[]) Q K Xa =
  let Ga =
    (Array.init N (fun _ -> []), Aa)
    ||> Array.fold (fun Ga (a,b,c) -> Ga.[a-1] <- (b-1,c)::Ga.[a-1]; Ga.[b-1] <- (a-1,c)::Ga.[b-1]; Ga)
  let Da = dijkstra N (K-1) Ga
  Xa |> Array.map (fun (x,y) -> Da.[x-1]+Da.[y-1])

let N = stdin.ReadLine() |> int
let Aa = Array.init (N-1) (fun _ -> stdin.ReadLine().Split() |> fun x -> int x.[0], int x.[1], int64 x.[2])
let Q,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Xa = Array.init Q (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N Aa Q K Xa |> Array.iter stdout.WriteLine

solve 5 [|(1,2,1L);(1,3,1L);(2,4,1L);(3,5,1L)|] 3 1 [|(2,4);(2,3);(4,5)|] |> should equal [|3L;2L;4L|]
solve 7 [|(1,2,1L);(1,3,3L);(1,4,5L);(1,5,7L);(1,6,9L);(1,7,11L)|] 3 2 [|(1,3);(4,5);(6,7)|] |> should equal [|5L;14L;22L|]
solve 10 [|(1,2,1000000000L);(2,3,1000000000L);(3,4,1000000000L);(4,5,1000000000L);(5,6,1000000000L);(6,7,1000000000L);(7,8,1000000000L);(8,9,1000000000L);(9,10,1000000000L)|] 1 1 [|(9,10)|] |> should equal [|17000000000L|]
