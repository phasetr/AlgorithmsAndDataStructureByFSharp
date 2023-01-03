#r "nuget: FsUnit"
open FsUnit

(*
let N,X,Y,Aa = 2,2,3,[|5;8|]
let N,X,Y,Aa = 2,2,3,[|7;8|]
*)
let solve N X Y Aa =
  let M = 100000
  let Ga =
    (Array.create (M+1) 0, [|0..M|])
    ||> Array.fold (fun dp i ->
      let Va = Array.create 3 false
      if X<=i then Va.[dp.[i-X]] <- true
      if Y<=i then Va.[dp.[i-Y]] <- true
      dp.[i] <- if not Va.[0] then 0 elif not Va.[1] then 1 else 2
      dp)
  (0,Aa) ||> Array.fold (fun acc a -> acc^^^Ga.[a])
  |> fun x -> if x=0 then "Second" else "First"

let N,X,Y = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1],x.[2])
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N X Y Aa |> stdout.WriteLine

solve 2 2 3 [|5;8|] |> should equal "First"
solve 2 2 3 [|7;8|] |> should equal "Second"
