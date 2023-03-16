#r "nuget: FsUnit"
open FsUnit

(*
let N,M,K,Ia = 4,5,30L,[|(1L,100L,2L,180L);(2L,200L,3L,300L);(1L,80L,3L,360L);(3L,400L,3L,410L);(3L,450L,4L,600L)|]
*)
let solve N M K Ia =
  let D = System.Collections.Generic.Dictionary<_,_>()
  (ResizeArray<int64>(),Ia)
  ||> Array.fold (fun A (a,s,b,t) ->
    if not (D.ContainsKey(s)) then D.[s] <- ResizeArray<int64*int64*int64*int64>(); A.Add(s)
    D.[s].Add((0L,t,a-1L,b-1L))
    if not (D.ContainsKey(t+K)) then D.[t+K] <- ResizeArray<int64*int64*int64*int64>(); A.Add(t+K)
    A)
  |> Seq.distinct |> Seq.sort |> Seq.toArray
  |> fun A ->
    (Array.create N 0L, A)
    ||> Array.fold (fun dp a ->
      D.[a]
      |> Seq.sortBy (fun (x,_,_,_) -> x)
      |> Seq.iter (fun (d,t,p,q) -> if d=0L then D.[t+K].Add(1L,dp.[int p]+1L,p,q) else dp.[int q] <- max dp.[int q] t)
      dp)
    |> Array.max

let N,M,K = stdin.ReadLine().Split() |> (fun x -> int x.[0],int x.[1],int64 x.[2])
let Ia = Array.init M (fun _ -> stdin.ReadLine().Split() |> Array.map int64 |> fun x -> x.[0],x.[1],x.[2],x.[3])
solve N M K Ia |> stdout.WriteLine

solve 4 5 30L [|(1L,100L,2L,180L);(2L,200L,3L,300L);(1L,80L,3L,360L);(3L,400L,3L,410L);(3L,450L,4L,600L)|] |> should equal 3
