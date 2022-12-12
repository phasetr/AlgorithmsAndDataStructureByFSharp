#r "nuget: FsUnit"
open FsUnit

(*
let H,W,A,B = 3,3,1,1
let H,W,A,B = 1,5,2,0
*)
let solve H W A B =
  List.init B (fun _ -> String.init A (fun _ -> "0") + String.init (W-A) (fun _ -> "1"))
  @ List.init (H-B) (fun _ -> String.init A (fun _ -> "1") + String.init (W-A) (fun _ -> "0"))

let H,W,A,B = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1],x.[2],x.[3])
solve H W A B |> List.iter stdout.WriteLine

solve 3 3 1 1
solve 1 5 2 0
