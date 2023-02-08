#r "nuget: FsUnit"
open FsUnit

(*
let N,Ia,Q,Qa = 5,[|(1,3);(2,5);(3,4);(2,6);(3,3)|],3,[|(1,3,3,6);(1,5,2,6);(1,3,3,5)|]
*)
let solve N Ia Q Qa =
  let K = 1500
  let Pa =
    (Array2D.create (K+1) (K+1) 0, Ia)
    ||> Array.fold (fun Pa (x,y) -> Pa.[x,y] <- Pa.[x,y]+1; Pa)
    |> fun Pa -> [| for i in 1..K do for j in 1..K do (i,j)|] |> Array.iter (fun (i,j) -> Pa.[i,j] <- Pa.[i,j-1]+Pa.[i,j]); Pa
    |> fun Pa -> [| for i in 1..K do for j in 1..K do (i,j)|] |> Array.iter (fun (i,j) -> Pa.[i,j] <- Pa.[i-1,j]+Pa.[i,j]); Pa
  Qa |> Array.map (fun (a,b,c,d) -> Pa.[c,d] - Pa.[c,b-1] - Pa.[a-1,d] + Pa.[a-1,b-1])

let N = stdin.ReadLine() |> int
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
let Q = stdin.ReadLine() |> int
let Qa = Array.init Q (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1],x.[2],x.[3])
solve N Ia Q Qa |> Array.iter stdout.WriteLine

solve 5 [|(1,3);(2,5);(3,4);(2,6);(3,3)|] 3 [|(1,3,3,6);(1,5,2,6);(1,3,3,5)|] |> should equal [|5;2;4|]
