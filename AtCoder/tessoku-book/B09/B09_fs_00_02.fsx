#r "nuget: FsUnit"
open FsUnit

(*
let N,Ia = 2,[|(1,1,3,3);(2,2,4,4)|]
*)
let solve N Ia =
  let K = 1500
  (Array2D.create (K+1) (K+1) 0, Ia)
  ||> Array.fold (fun Pa (xa,yb,xc,yd) ->
    Pa.[xa,yb] <- Pa.[xa,yb]+1
    Pa.[xa,yd] <- Pa.[xa,yd]-1
    Pa.[xc,yb] <- Pa.[xc,yb]-1
    Pa.[xc,yd] <- Pa.[xc,yd]+1
    Pa)
  |> fun Pa -> [| for i in [|0..K|] do for j in [|1..K|] do (i,j) |] |> Array.iter (fun (i,j) -> Pa.[i,j] <- Pa.[i,j]+Pa.[i,j-1]); Pa
  |> fun Pa -> [| for i in [|1..K|] do for j in [|0..K|] do (i,j) |] |> Array.iter (fun (i,j) -> Pa.[i,j] <- Pa.[i,j]+Pa.[i-1,j]); Pa
  |> Seq.cast<int> |> Seq.fold (fun acc i -> acc + if i>0 then 1 else 0) 0

let N = stdin.ReadLine() |> int
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1],x.[2],x.[3])
solve N Ia |> stdout.WriteLine

solve 2 [|(1,1,3,3);(2,2,4,4)|] |> should equal 7
