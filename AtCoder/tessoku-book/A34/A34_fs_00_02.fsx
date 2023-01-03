#r "nuget: FsUnit"
open FsUnit

(*
let N,X,Y,Aa = 2,2,3,[|5;8|]
let N,X,Y,Aa = 2,2,3,[|7;8|]
*)
let solve N X Y Aa =
  let Ga = ResizeArray<int>()
  for i in 0..100000 do
    let Va = Array.create 3 false
    if X<=i then Va[Ga[i-X]] <- true
    if Y<=i then Va[Ga[i-Y]] <- true
    let g = if not Va.[0] then 0 elif not Va.[1] then 1 else 2
    Ga.Add(g)
  (0,Aa) ||> Array.fold (fun acc a -> acc^^^Ga.[a])
  |> fun x -> if x=0 then "Second" else "First"

let N,X,Y = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1],x.[2])
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N X Y Aa |> stdout.WriteLine

solve 2 2 3 [|5;8|] |> should equal "First"
solve 2 2 3 [|7;8|] |> should equal "Second"
