#r "nuget: FsUnit"
open FsUnit

(*
let D,N,Ia = 8,5,[|(2,3);(3,6);(5,7);(3,7);(1,5)|]
*)
let solve D N Ia =
  (Array.create (D+1) 0, Ia)
  ||> Array.fold (fun Xa (l,r) -> Xa.[l-1] <- Xa.[l-1]+1; Xa.[r] <- Xa.[r]-1; Xa)
  |> Array.scan (+) 0
  |> fun Xa -> Xa.[1..(Xa.Length-2)]

let D = stdin.ReadLine() |> int
let N = stdin.ReadLine() |> int
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve D N Ia |> Array.iter stdout.WriteLine

solve 8 5 [|(2,3);(3,6);(5,7);(3,7);(1,5)|] |> should equal [|1;2;4;3;4;3;2;0|]
