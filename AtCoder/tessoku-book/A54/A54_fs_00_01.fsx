#r "nuget: FsUnit"
open FsUnit

(*
let Q,Qa = 3,[|[|"1";"tanaka";"49"|];[|"1";"suzuki";"50"|];[|"2";"tanaka"|]|]
*)
let solve Q (Qa:string[][]) =
  let m = System.Collections.Generic.Dictionary<string,int>()
  (System.Collections.Generic.Dictionary<string,int>(), Qa) ||> Array.fold (fun m qa ->
    match qa.[0] with
      | "1" -> m.Add(qa.[1], qa.[2] |> int); m
      | _ -> m.[qa.[1]] |> stdout.WriteLine; m)

let Q = stdin.ReadLine() |> int
let Qa = Array.init Q (fun _ -> stdin.ReadLine().Split())
solve Q Qa |> ignore

(*
49
*)
