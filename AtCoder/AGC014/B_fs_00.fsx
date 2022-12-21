#r "nuget: FsUnit"
open FsUnit

(*
let N,M,Ia = 4,4,[|(1,2);(2,4);(1,3);(3,4)|]
let N,M,Ia = 5,5,[|(1,2);(3,5);(5,1);(3,4);(2,3)|]
*)
let solve N M Ia =
  (Array.zeroCreate N, Ia)
  ||> Array.fold (fun Ga (a,b) -> Ga.[a-1]<-1+Ga.[a-1]; Ga.[b-1]<-1+Ga.[b-1]; Ga)
  |> Array.forall (fun x -> x%2=0)
  |> fun b -> if b then "YES" else "NO"

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = Array.init M (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N M Ia |> stdout.WriteLine

solve 4 4 [|(1,2);(2,4);(1,3);(3,4)|] |> should equal "YES"
solve 5 5 [|(1,2);(3,5);(5,1);(3,4);(2,3)|] |> should equal "NO"
