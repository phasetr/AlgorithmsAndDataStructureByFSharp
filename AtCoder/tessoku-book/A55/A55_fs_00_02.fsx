#r "nuget: FsUnit"
open FsUnit

(*
let Q,Qa = 3,[|[|1;77|];[|3;40|];[|3;80|]|]
let Q,Qa = 3,[|[|1;77|];[|1;40|];[|3;80|]|]
*)
let solve Q (Qa:int[][]) =
  let ls = System.Collections.Generic.List<int>()
  Qa |> Array.iter (fun qa ->
    match qa.[0] with
      | 1 ->
        if ls.Count=0 then ls.Add(qa.[1])
        else let j = ls.BinarySearch(qa.[1]) in ls.Insert(~~~j,qa.[1])
      | 2 -> ls.Remove(qa.[1]) |> ignore
      | _ ->
        let s = ls.BinarySearch(qa.[1]) |> fun x -> if 0<=x then x else ~~~x
        (if s<ls.Count then ls.[s] else -1) |> stdout.WriteLine)

let Q = stdin.ReadLine() |> int
let Qa = Array.init Q (fun _ -> stdin.ReadLine().Split() |> Array.map int)
solve Q Qa

(*
77
-1
*)
