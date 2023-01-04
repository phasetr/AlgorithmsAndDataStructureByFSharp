#r "nuget: FsUnit"
open FsUnit

(*
let N,Ia = 3,[|(123,86399);(1,86400);(86399,86400)|]
*)
let solve N Ia =
  Ia |> Array.sortBy snd
  |> fun Xa -> ((0,0), Xa)
  ||> Array.fold (fun (k,e) (l,r) -> if e<=l then (k+1,r) else (k,e))
  |> fst

let N = stdin.ReadLine() |> int
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N Ia |> stdout.WriteLine

solve 3 [|(123,86399);(1,86400);(86399,86400)|] |> should equal 2
