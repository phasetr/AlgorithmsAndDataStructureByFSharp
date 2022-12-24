#r "nuget: FsUnit"
open FsUnit

(*
let H,W,Ia = 2,3,[|[|1;2;3|];[|0;1;1|]|]
let H,W,Ia = 3,2,[|[|1;0|];[|2;1|];[|1;0|]|]
let H,W,Ia = 1,5,[|[|9;9;9;9;9|]|]
*)
let solve H W (Ia:int[][]) =
  let toStr i j k l = sprintf "%d %d %d %d" i j k l
  let Ja =
    Ia |> Array.mapi (fun i Ra ->
      if i%2=0 then Ra |> Array.mapi (fun j v -> ((i+1,j+1),v))
      else Ra |> Array.mapi (fun j v -> ((i+1,j+1),v)) |> Array.rev)
    |> Array.concat
  (([],true,(0,0)), Ja) ||> Array.fold (fun (acc,b,(i,j)) ((k,l), v) ->
      match (b, v%2=0) with
        | (true,true)  -> (acc,true,(k,l))
        | (true,false) -> (acc,false,(k,l))
        | (false,true) -> ((toStr i j k l)::acc,false,(k,l))
        | _            -> ((toStr i j k l)::acc,true,(k,l)))
  |> fun (s,_,_) -> (List.length s |> string)::(List.rev s)

let H,W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = Array.init H (fun _ -> stdin.ReadLine().Split() |> Array.map int)
solve H W Ia |> List.iter stdout.WriteLine

solve 2 3 [|[|1;2;3|];[|0;1;1|]|]
(*
3
2 2 2 3
1 1 1 2
1 3 1 2
*)
solve 3 2 [|[|1;0|];[|2;1|];[|1;0|]|]
(*
3
1 1 1 2
1 2 2 2
3 1 3 2
*)
solve 1 5 [|[|9;9;9;9;9|]|]
(*
2
1 1 1 2
1 3 1 4
*)
