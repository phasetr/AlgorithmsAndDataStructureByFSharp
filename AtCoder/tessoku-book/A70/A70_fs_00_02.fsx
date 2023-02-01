#r "nuget: FsUnit"
open FsUnit

(*
let N,M,Aa,Ia = 4,2,[|0;1;1;0|],[|(1,2,3);(2,3,4)|]
*)
open System.Collections.Generic
let solve N M Aa Ia =
  let conv k Xa = ((0,k-1), Xa) ||> Array.fold (fun (acc,n) x -> let l = x*pown 2 n in (acc+l,n-1)) |> fst
  let A = conv N Aa
  let Ba = Ia |> Array.map (fun (x,y,z) -> Array.create N 0 |> fun b -> b.[x-1]<-1; b.[y-1]<-1; b.[z-1]<-1; b |> conv N)

  let rec bfs (q:Queue<int>) Xa =
    match q.Count with
      | 0 -> Xa |> Array.last
      | _ ->
        let k = q.Dequeue()
        Ba |> Array.iter (fun i -> let l = k^^^i in if Xa.[l]=(-1) then Xa.[l] <- Xa.[k] + 1; q.Enqueue(l))
        bfs q Xa

  let Xa = Array.create (1<<<N) (-1) |> fun a -> a.[A] <- 0; a
  let q = Queue<int>() |> fun q -> q.Enqueue(A); q
  bfs q Xa

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int
let Ia = Array.init M (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1],x.[2])
solve N M Aa Ia |> stdout.WriteLine

solve 4 2 [|0;1;1;0|] [|(1,2,3);(2,3,4)|] |> should equal 2
