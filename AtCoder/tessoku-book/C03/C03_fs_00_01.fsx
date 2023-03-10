#r "nuget: FsUnit"
open FsUnit

(*
let D,X,Aa,Q,Qa = 5,30,[|-10;20;-10;20;|],3,[|(1,2);(3,5);(1,4)|]
*)
let solve D X Aa Q Qa =
  let Sa = (X,Aa) ||> Array.scan (fun acc a -> acc+a)
  Qa |> Array.map (fun (s,t) -> let ps,pt = Sa.[s-1],Sa.[t-1] in if ps<pt then (string t) elif pt<ps then (string s) else "Same")

let D = stdin.ReadLine() |> int
let X = stdin.ReadLine() |> int
let Aa = Array.init (D-1) (fun _ -> stdin.ReadLine() |> int)
let Q = stdin.ReadLine() |> int
let Ia = Array.init Q (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve D X Aa Q Ia |> Array.iter stdout.WriteLine

solve 5 30 [|-10;20;-10;20;|] 3 [|(1,2);(3,5);(1,4)|] |> should equal [|"1";"5";"Same"|]
