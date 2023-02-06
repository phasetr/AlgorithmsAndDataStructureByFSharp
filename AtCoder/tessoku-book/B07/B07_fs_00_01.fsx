#r "nuget: FsUnit"
open FsUnit

(*
let T,N,Ia = 10,7,[|(0,3);(2,4);(1,3);(0,3);(5,6);(5,6);(5,6)|]
*)
let solve T N Ia =
  let Xa = (Array.create (T+1) 0, Ia) ||> Array.fold (fun Xa (l,r) ->
    Xa.[l] <- Xa.[l]+1; Xa.[r] <- Xa.[r]-1; Xa)
  (0,Xa) ||> Array.scan (+) |> Array.tail |> Array.take T

let T = stdin.ReadLine() |> int
let N = stdin.ReadLine() |> int
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve T N Ia |> Array.iter stdout.WriteLine

solve 10 7 [|(0,3);(2,4);(1,3);(0,3);(5,6);(5,6);(5,6)|] |> should equal [|2;3;4;1;0;3;0;0;0;0|]
