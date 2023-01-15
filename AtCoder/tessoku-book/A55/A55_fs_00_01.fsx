#r "nuget: FsUnit"
open FsUnit

(*
let Q,Qa = 3,[|[|1;77|];[|3;40|];[|3;80|]|]
*)
let solveTLE Q (Qa:int[][]) =
  (Set.empty, Qa) ||> Array.fold (fun s qa ->
    match qa.[0] with
      | 1 -> s |> Set.add qa.[1]
      | 2 -> s |> Set.remove qa.[1]
      | _ ->
        s |> Set.filter ((<=) qa.[1]) |> (fun t -> if Set.isEmpty t then -1 else t |> Set.minElement) |> stdout.WriteLine
        s)

let Q = stdin.ReadLine() |> int
let Qa = Array.init Q (fun _ -> stdin.ReadLine().Split() |> Array.map int)
solve Q Qa

(*
77
-1
*)
